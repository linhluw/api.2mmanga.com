using MyWeb.BAL.Cache;
using MyWeb.COM.Cache;
using MyWeb.COM.Helper.Cache;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.BAL.Service
{
    public class HoaDonNhapService : IHoaDonNhapService
    {
        private readonly IRepository<HoaDonNhap> _repo;
        private readonly ICacheData _memoryCache;

        public HoaDonNhapService(IRepository<HoaDonNhap> repo, ICacheData memoryCache)
        {
            _repo = repo;
            _memoryCache = memoryCache;
        }

        //GET All
        public List<HoaDonNhap> GetAll()
        {
            var data = new List<HoaDonNhap>();
            try
            {
                data = _repo.GetAll().ToList();
            }
            catch (Exception e)
            {

            }
            return data;
        }

        //Get By Id
        public HoaDonNhap GetById(string MaHoaDon)
        {
            return GetAll().FirstOrDefault(x => x.MaHoaDon == MaHoaDon);
        }

        //Add
        public async Task<HoaDonNhap> Add(HoaDonNhap item)
        {
            var data = await _repo.Create(item);
            return data;
        }

        //Delete
        public bool Delete(string MaHoaDon)
        {
            try
            {
                var item = _repo.GetAll().FirstOrDefault(x => x.MaHoaDon == MaHoaDon);
                if (item != null)
                {
                    _repo.Delete(item);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Update
        public bool Update(HoaDonNhap item)
        {
            try
            {
                _repo.Update(item);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}