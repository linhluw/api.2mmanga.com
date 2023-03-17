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
    public class SanPhamService : ISanPhamService
    {
        private readonly IRepository<SanPham> _repo;
        private readonly ICacheData _memoryCache;

        public SanPhamService(IRepository<SanPham> repo, ICacheData memoryCache)
        {
            _repo = repo;
            _memoryCache = memoryCache;
        }

        //GET All
        public List<SanPham> GetAll()
        {
            var data = new List<SanPham>();
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
        public SanPham GetById(int Id)
        {
            return GetAll().FirstOrDefault(x => x.Id == Id);
        }

        //Add
        public async Task<SanPham> Add(SanPham item)
        {
            var data = await _repo.Create(item);
            return data;
        }

        //Delete
        public bool Delete(int Id)
        {
            try
            {
                var item = _repo.GetAll().FirstOrDefault(x => x.Id == Id);
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
        public bool Update(SanPham item)
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