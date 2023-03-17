using MyWeb.BAL.Cache;
using MyWeb.BAL.ViewModels.Requests;
using MyWeb.BAL.ViewModels.Response;
using MyWeb.COM.Cache;
using MyWeb.COM.Helper;
using MyWeb.COM.Helper.Cache;
using MyWeb.COM.Utilities;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyWeb.BAL.Service
{
    public class NewsService : INewsService
    {
        private readonly ICacheData _memoryCache;
        private readonly ISanPhamService _sanPhamService;
        private readonly IDanhMucService _danhMucService;
        private readonly INhaXuatBanService _nhaXuatBanService;

        public NewsService(ICacheData memoryCache, ISanPhamService sanPhamService, IDanhMucService danhMucService, INhaXuatBanService nhaXuatBanService)
        {
            _memoryCache = memoryCache;
            _sanPhamService = sanPhamService;
            _danhMucService = danhMucService;
            _nhaXuatBanService = nhaXuatBanService;
        }

        

        ////Get By Id
        //public News GetById(int Id)
        //{
        //    return GetAll().FirstOrDefault(x => x.Id == Id);
        //}

        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public PaginatedItem<NewsSerchResponse> GetPaginated(GetListNewsQuery rq)
        {
            var response = new PaginatedItem<NewsSerchResponse>(0, 0, new List<NewsSerchResponse>());
            try
            {
                var data = _sanPhamService.GetAll();
                if (data != null && data.Count > 0)
                {
                    switch (rq.TypeSearch)
                    {
                        case (int)TypeSearch.MaVach:
                            data = data.Where(x => (x.MaVach.ToLower().Contains(rq.KeySearch.ToLower()))).ToList();
                            break;
                        case (int)TypeSearch.TenSanPham:
                            data = data.Where(x => (x.TenSanPham.ToLower().Contains(rq.KeySearch.ToLower()))).ToList();
                            break;
                    }

                    var totals = data.Count();

                    // phân trang dữ liệu
                    data = data.Skip((rq.PageIndex - 1) * rq.PageSize).Take(rq.PageSize).ToList();
                    if (data != null && data.Count > 0)
                    {
                      
                        var danhMuc = _danhMucService.GetAll();
                       
                        var nhaxuatban = _nhaXuatBanService.GetAll();

                        var dataJoin = (from emp in data

                                        join empdanhMuc in danhMuc
                                        on emp.IdDanhMuc equals empdanhMuc.Id

                                        join empnhaxuatban in nhaxuatban
                                        on emp.IdNhaXuatBan equals empnhaxuatban.Id

                                        select new NewsSerchResponse
                                        {
                                            Id = emp.Id,
                                            TenSanPham = emp.TenSanPham,
                                            SoLuong = emp.SoLuong,
                                            GiaSanPham = emp.GiaSanPham,
                                            MaVach = emp.MaVach,
                                            NhaXuatBan = empnhaxuatban.TenNhaXuatBan,
                                            DanhMuc = empdanhMuc.TenDanhMuc,
                                            HinhAnh = emp.HinhAnh,
                                            NgayPhatHanh = emp.NgayPhatHanh,
                                            SoNgayHoatDong = DateTime.Now.Date > emp.NgayPhatHanh.Date ? DateTime.Now.Date.Subtract(emp.NgayPhatHanh.Date).TotalDays : 0,
                                            KhoOffline = emp.KhoOffline,
                                            KhoShopee = emp.KhoShopee,
                                            KhoLazada = emp.KhoLazada
                                        }).ToList();

                        response = new PaginatedItem<NewsSerchResponse>(
                        totals, totals % rq.PageSize == 0 ? totals / rq.PageSize : totals / rq.PageSize + 1,
                        dataJoin);
                    }


                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return response;
        }


        ////Add
        //public async Task<News> Add(News item)
        //{
        //    item.Code = RandomTextGenerator.GenerateText(false, true, true, false, 9);
        //    var data = await _repo.Create(item);
        //    if (data != null && data.Id > 0)
        //    {
        //        //Xóa key
        //        RemoveCache();
        //        //Gọi lại hàm để tạo lại cache
        //        GetAll();
        //    }
        //    return data;
        //}

        ////Delete
        //public bool Delete(int Id)
        //{
        //    try
        //    {
        //        var item = _repo.GetAll().FirstOrDefault(x => x.Id == Id);
        //        if (item != null)
        //        {
        //            _repo.Delete(item);
        //            //Xóa key
        //            RemoveCache();
        //            //Gọi lại hàm để tạo lại cache
        //            GetAll();
        //        }

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        ////Update
        //public bool Update(News item)
        //{
        //    try
        //    {
        //        var data = GetById(item.Id);
        //        if (item != null)
        //        {
        //            data.Name = item.Name;
        //            data.TagName = item.TagName;
        //            data.SignName = item.SignName;
        //            data.Acreage = item.Acreage;
        //            data.InternalName = item.InternalName;
        //            data.SignInternalName = item.SignInternalName;
        //            data.Price = item.Price;
        //            data.BedroomsNumber = item.BedroomsNumber;
        //            data.ToiletNumber = item.ToiletNumber;
        //            data.FloorNumber = item.FloorNumber;
        //            data.DoorDirection = item.DoorDirection;
        //            data.BalconyDirection = item.BalconyDirection;
        //            data.ServiceTypeId = item.ServiceTypeId;
        //            data.GroupNewsId = item.GroupNewsId;
        //            data.LegalDocumentsId = item.LegalDocumentsId;
        //            data.Detail = item.Detail;
        //            data.InternalDetail = item.InternalDetail;
        //            data.Images = item.Images;
        //            data.IsStatusHome = item.IsStatusHome;
        //            data.IsMySource = item.IsMySource;
        //            data.IsInvest = item.IsInvest;
        //            data.Description = item.Description;
        //            data.UpdatedByUser = item.UpdatedByUser;
        //            data.UpdatedDate = item.UpdatedDate;
        //            data.IsActive = item.IsActive;
        //            _repo.Update(data);
        //            //Xóa key
        //            RemoveCache();
        //            //Gọi lại hàm để tạo lại cache
        //            GetAll();
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        ////Update
        //public bool UpdateIsActive(int id, bool isactive)
        //{
        //    try
        //    {
        //        var item = GetById(id);
        //        if (item != null)
        //        {
        //            item.IsActive = isactive;
        //            _repo.Update(item);
        //            //Xóa key
        //            RemoveCache();
        //            //Gọi lại hàm để tạo lại cache
        //            GetAll();
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public void RemoveCache()
        //{
        //    //Xóa key
        //    _memoryCache.Remove(ManagerCacheString.ConstructCacheKey(CacheKey.News, "ALL"));
        //}
    }
}