using MyWeb.BAL.Cache;
using MyWeb.COM.Helper;
using MyWeb.COM.Utilities;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using MyWeb.BAL.ViewModels.Response;
using MyWeb.BAL.ViewModels.Requests;
using System.Net;
using Azure.Core;
using Azure;
using Newtonsoft.Json;
using System.IO;
using MyWeb.BAL.ViewModels.Sapo;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;
using System.Linq.Expressions;

namespace MyWeb.BAL.Service
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly ICategoryService _categoryService;
        private readonly IPublishedService _publishedService;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IOrderProductService _orderProductService;

        public ProductService(IRepository<Product> repo, ICacheData memoryCache, ICategoryService categoryService,
            IPublishedService publishedService, ICartService cartService, IOrderService orderService, IOrderProductService orderProductService) : base(repo, memoryCache)
        {
            _categoryService = categoryService;
            _publishedService = publishedService;
            _cartService = cartService;
            _orderService = orderService;
            _orderProductService = orderProductService;
            //_repo = repo;
        }


        /// <summary>
        /// lấy dữ liệu từ sapo
        /// </summary>
        /// <param name="adminSesionId"></param>
        /// <returns></returns>
        public bool CreatedDataSapo(string adminSesionId)
        {
            var url = "https://2mmanga.mysapogo.com/admin/products.json?page=1&limit=250";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                httpRequest.Method = "GET";
                httpRequest.ContentType = "application/json; charset=utf-8";
                httpRequest.CookieContainer = new CookieContainer();
                httpRequest.CookieContainer.Add(new Cookie("_admin_session_id", adminSesionId) { Domain = "2mmanga.mysapogo.com" });
                httpRequest.Timeout = 1800 * 1000; // 1800s = 30 phút

                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var res = JsonConvert.DeserializeObject<RootSapo>(streamReader.ReadToEnd());
                    if (res != null && res.products.Count > 0)
                    {
                        foreach (var product in res.products)
                        {
                            var info = product.variants.FirstOrDefault();

                            if (int.TryParse(info.sku.Replace("PVN", string.Empty), out int sku) && (int.TryParse(GetAll().FirstOrDefault()?.SapoCode.Replace("PVN", string.Empty), out int sapoCode)))
                            {
                                if(sku > sapoCode)
                                {
                                    var image = string.Join(",", product.images.Select(x => x.full_path));
                                    var createdDate = product.created_on;
                                    var quantity = (int)info.inventories.FirstOrDefault().available;
                                    var item = new Product
                                    {
                                        Name = info.product_name,
                                        Images = image,
                                        Quantity = quantity,
                                        Price = (int)info.variant_retail_price,
                                        Weight = (int)info.weight_value == 0 ? 300 : (int)info.weight_value,
                                        BarCode = info.sku,
                                        SapoCode = info.sku,
                                        FK_PublishedId = GetPublishedIdSapo(info.brand_id),
                                        FK_CategoryId = GetCategoriesIdSapo(info.category_id),
                                        ReleaseDate = createdDate.Date,
                                        CreatedDate = createdDate,
                                        IsSoldAll = quantity > 0 ? false : true,

                                    };

                                    CreateOrUpdate(item);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                httpRequest = null;
            }
            catch (Exception ex)
            {
                httpRequest = null;
                return false;
            }
            return true;
        }

        private string GetCategoriesIdSapo(int categories_id)
        {
            var code = string.Empty;
            switch (categories_id)
            {
                case (int)CategoriesID.VanPhongPham:
                    code = ReturnCodeId<CategoriesID>(CategoriesID.VanPhongPham);
                    break;
                case (int)CategoriesID.LightNovel:
                    code = ReturnCodeId<CategoriesID>(CategoriesID.LightNovel);
                    break;
                case (int)CategoriesID.Comic:
                    code = ReturnCodeId<CategoriesID>(CategoriesID.Comic);
                    break;
            }

            return _categoryService.GetByName(code).PK_CategoryId;
        }

        private string GetPublishedIdSapo(int brand_id)
        {
            var code = string.Empty;
            switch (brand_id)
            {
                case (int)BrandID.AMAK:
                    code = ReturnCodeId<BrandID>(BrandID.AMAK);
                    break;
                case (int)BrandID.IPM:
                    code = ReturnCodeId<BrandID>(BrandID.AMAK);
                    break;
                case (int)BrandID.Tre:
                    code = ReturnCodeId<BrandID>(BrandID.Tre);
                    break;
                case (int)BrandID.KimDong:
                    code = ReturnCodeId<BrandID>(BrandID.KimDong);
                    break;
            }

            return _publishedService.GetByName(code).PK_PublishedId;
        }

        public static string ReturnCodeId<T>(T vaule)
        {
            FieldInfo field = vaule.GetType().GetField(vaule.ToString());

            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

            return attribute.Description;
        }

        public override bool CreateOrUpdate(Product item, bool isCreate = true)
        {
            item.TagName = StringClass.NameToTag(item.Name);
            item.SignName = StringClass.NameToSign(item.Name);
            return base.CreateOrUpdate(item);
        }

        public override Product GetById(string Id)
        {
            return GetAll()?.FirstOrDefault(x => x.PK_ProductId == Id);
        }

        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public PaginatedItem<ProductSearchResponse> GetProductPaginated(ProductSearchRequest rq)
        {
            var response = new PaginatedItem<ProductSearchResponse>(0, 0, new List<ProductSearchResponse>());
            try
            {
                var cachedData = GetAll();
                if (cachedData != null && cachedData.Count > 0)
                {
                    // lọc theo từ khóa
                    var data = cachedData.Where(x => ((x.Name.ToLower().Contains(rq.KeySearch.ToLower())) || (x.SignName.ToLower().Contains(rq.KeySearch.ToLower())))).ToList();

                    // lọc theo danh mục
                    if (!string.IsNullOrEmpty(rq.CategoryId))
                    {
                        data = data.Where(x => x.FK_CategoryId == rq.CategoryId).ToList();
                    }

                    // lọc theo nhà xuất bản
                    if (!string.IsNullOrEmpty(rq.PublishedId))
                    {
                        data = data.Where(x => x.FK_PublishedId == rq.PublishedId).ToList();
                    }

                    // lọc theo trạng thái bán hết hay không
                    if (rq.IsSoldAll != null)
                    {
                        data = data.Where(x => x.IsSoldAll == rq.IsSoldAll).ToList();
                    }

                    var totals = data.Count();

                    // sắp xếp lại
                    data = data.OrderBy(c => c.IsSoldAll).ThenByDescending(n => n.ReleaseDate).ToList();

                    // phân trang dữ liệu
                    data = data.Skip((rq.PageIndex - 1) * rq.PageSize).Take(rq.PageSize).ToList();
                    if (data != null && data.Count > 0)
                    {
                        var groupPublished = _publishedService.GetAll();
                        var groupCategory = _categoryService.GetAll();

                        var dataRespone = from item in data
                                          join published in groupPublished on item.FK_PublishedId equals published.PK_PublishedId
                                          join category in groupCategory on item.FK_CategoryId equals category.PK_CategoryId
                                          select new ProductSearchResponse
                                          {
                                              PK_ProductId = item.PK_ProductId,
                                              Name = item.Name,
                                              TagName = item.TagName,
                                              Images = item.Images.Length > 0 ? item.Images.Split(',')[0].Trim() : string.Empty,
                                              Quantity = item.Quantity,
                                              Price = item.Price,
                                              Discount = item.Discount,
                                              Payments = (int)(item.Price * ((100 - item.Discount) / 100)),
                                              PublishedName = published.Name,
                                              CategoryName = category.Name,
                                              ReleaseDate = item.ReleaseDate,
                                              IsSoldAll = item.IsSoldAll,
                                              IsType = item.IsType,
                                              IsLimited = item.IsLimited
                                          };

                        response = new PaginatedItem<ProductSearchResponse>(
                        totals, totals % rq.PageSize == 0 ? totals / rq.PageSize : totals / rq.PageSize + 1,
                        dataRespone.ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("GetProductPaginated", ex);
                return null;
            }
            return response;
        }

        /// <summary>
        /// Lấy chi tiết sản phẩm theo TagName
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public ProductDetailResponse GetDetail(string tag)
        {
            var response = new ProductDetailResponse();
            var item = GetAll()?.FirstOrDefault(x => x.TagName == tag);
            if (item != null)
            {
                response.PK_ProductId = item.PK_ProductId;
                response.Name = item.Name;
                response.TagName = item.TagName;
                var lstImg = item.Images.Split(',');
                if (lstImg.Length > 0)
                {
                    response.Images = lstImg[0].Trim();
                    foreach (var img in lstImg)
                    {
                        response.LstImage.Add(img);
                    }
                }
                response.Quantity = item.Quantity;
                response.Price = item.Price;
                response.Discount = item.Discount;
                response.Payments = (int)(item.Price * ((100 - item.Discount) / 100));
                response.PublishedName = _publishedService.GetById(item.FK_PublishedId)?.Name ?? string.Empty;
                response.CategoryName = _categoryService.GetById(item.FK_CategoryId)?.Name ?? string.Empty;
                response.ReleaseDate = item.ReleaseDate;
                response.IsSoldAll = item.IsSoldAll;
            }
            return response;
        }

        /// <summary>
        /// Lấy thông tin giỏ hàng theo user ID
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public List<CartResponse> GetCart(string userid)
        {
            var response = new List<CartResponse>();
            var lst = _cartService.GetCartByUserId(userid);
            if (lst != null && lst.Count > 0)
            {
                foreach (var item in lst)
                {
                    var re = new CartResponse();
                    re.FK_ProductId = item.FK_ProductId;
                    var product = GetById(item.FK_ProductId);
                    if (product != null)
                    {
                        re.Name = product.Name;
                        re.TagName = product.TagName;
                        re.Images = product.Images.Length > 0 ? product.Images.Split(',')[0].Trim() : string.Empty;
                        re.Price = product.Price;
                        re.Discount = product.Discount;
                        re.Payments = (int)(product.Price * ((100 - product.Discount) / 100));
                        re.IsSoldAll = product.IsSoldAll;
                    }
                    response.Add(re);
                }
            }
            return response;
        }

        /// <summary>
        /// Lên đơn
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Order(OrderCreatedOrUpdatedRequest item)
        {
            // kiểm tra xem là insert hay update
            var isCreated = string.IsNullOrEmpty(item.PK_OrderId) && Guid.Parse(item.PK_OrderId) != Guid.Empty;

            // Tính giá sau discount
            if (item != null && item.LstProducts != null && item.LstProducts.Count > 0)
            {
                // khởi tạo đơn hàng
                var order = new Order
                {
                    PK_OrderId = Guid.NewGuid().ToString(),
                    FK_UserId = item.FK_UserId,
                    Phone = item.Phone,
                    Address = item.Address,
                    Status = (int)NameStatus.KhoiTaoDon,
                    IsCancel = false
                };

                var totalPrice = 0;

                var lstOrderProduct = new List<OrderProduct>();
                foreach (var product in item.LstProducts)
                {
                    var result = GetById(product.FK_ProductId);
                    if (result != null)
                    {
                        var payments = (int)(result.Price * ((100 - result.Discount) / 100));

                        lstOrderProduct.Add(new OrderProduct
                        {
                            FK_OrderId = order.PK_OrderId,
                            FK_ProductId = result.PK_ProductId,
                            Quantity = product.Quantity,
                            Price = result.Price,
                            Discount = result.Discount,
                            Payments = payments
                        });

                        totalPrice += payments;
                    }
                }
                // Tổng tiền đơn hàng
                order.TotalPrice = totalPrice;

                // Thực hiện insert dữ liệu
                _orderService.CreateOrUpdate(order, isCreated);

                foreach (var pd in lstOrderProduct)
                {
                    _orderProductService.CreateOrUpdate(pd, isCreated);
                }
            }
            return true;
        }
    }
}