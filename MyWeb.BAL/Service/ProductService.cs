﻿using MyWeb.BAL.Cache;
using MyWeb.COM.Helper;
using MyWeb.COM.Utilities;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using MyWeb.BAL.ViewModels.Response;
using MyWeb.BAL.ViewModels.Requests;

namespace MyWeb.BAL.Service
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly ICartRepository _repoCart;

        private readonly ICategoryService _categoryService;
        private readonly IPublishedService _publishedService;

        public ProductService(IRepository<Product> repo, ICacheData memoryCache, ICategoryService categoryService, IPublishedService publishedService, ICartRepository repoCart) : base(repo, memoryCache)
        {
            _categoryService = categoryService;
            _publishedService = publishedService;
            _repoCart = repoCart;
            //_repo = repo;
        }

        //public override bool CreateOrUpdate(Product item)
        //{
        //    item.TagName = StringClass.NameToTag(item.Name);
        //    item.SignName = StringClass.NameToSign(item.Name);
        //    return base.CreateOrUpdate(item);
        //}

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

                    // phân trang dữ liệu
                    data = data.Skip((rq.PageIndex - 1) * rq.PageSize).Take(rq.PageSize).ToList();
                    if (data != null && data.Count > 0)
                    {
                        var dataRespone = new List<ProductSearchResponse>();
                        data.ForEach(item =>
                        {
                            dataRespone.Add(new ProductSearchResponse
                            {
                                PK_ProductId = item.PK_ProductId,
                                Name = item.Name,
                                TagName = item.TagName,
                                Images = item.Images.Length > 0 ? item.Images.Split(',')[0].Trim() : string.Empty,
                                Quantity = item.Quantity,
                                Price = item.Price,
                                Discount = item.Discount,
                                Payments = (int)(item.Price * ((100 - item.Discount) / 100)),
                                PublishedName = _publishedService.GetById(item.FK_PublishedId)?.Name ?? string.Empty,
                                CategoryName = _categoryService.GetById(item.FK_CategoryId)?.Name ?? string.Empty,
                                ReleaseDate = item.ReleaseDate,
                                IsSoldAll = item.IsSoldAll
                            });
                        });

                        response = new PaginatedItem<ProductSearchResponse>(
                        totals, totals % rq.PageSize == 0 ? totals / rq.PageSize : totals / rq.PageSize + 1,
                        dataRespone);
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
            var lst = _repoCart.GetCartByUserId(userid);
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
    }
}