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
    public class NhaXuatBanService : INhaXuatBanService
    {
        private readonly IRepository<NhaXuatBan> _repo;
        private readonly ICacheData _memoryCache;

        public NhaXuatBanService(IRepository<NhaXuatBan> repo, ICacheData memoryCache)
        {
            _repo = repo;
            _memoryCache = memoryCache;
        }

        //GET All
        public List<NhaXuatBan> GetAll()
        {
            var data = new List<NhaXuatBan>();
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
        public NhaXuatBan GetById(int Id)
        {
            return GetAll().FirstOrDefault(x => x.Id == Id);
        }

        //Add
        public async Task<NhaXuatBan> Add(NhaXuatBan item)
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
        public bool Update(NhaXuatBan item)
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