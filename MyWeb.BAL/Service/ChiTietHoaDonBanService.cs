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
    public class ChiTietHoaDonBanService : IChiTietHoaDonBanService
    {
        private readonly IRepository<ChiTietHoaDonBan> _repo;
        private readonly ICacheData _memoryCache;

        public ChiTietHoaDonBanService(IRepository<ChiTietHoaDonBan> repo, ICacheData memoryCache)
        {
            _repo = repo;
            _memoryCache = memoryCache;
        }

        //GET All
        public List<ChiTietHoaDonBan> GetAll()
        {
            var data = new List<ChiTietHoaDonBan>();
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
        public ChiTietHoaDonBan GetById(string MaHoaDon)
        {
            return GetAll().FirstOrDefault(x => x.IdMaHoaDon == MaHoaDon);
        }

        //Add
        public async Task<ChiTietHoaDonBan> Add(ChiTietHoaDonBan item)
        {
            var data = await _repo.Create(item);
            return data;
        }

        //Delete
        public bool Delete(string MaHoaDon)
        {
            try
            {
                var item = _repo.GetAll().FirstOrDefault(x => x.IdMaHoaDon == MaHoaDon);
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
        public bool Update(ChiTietHoaDonBan item)
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