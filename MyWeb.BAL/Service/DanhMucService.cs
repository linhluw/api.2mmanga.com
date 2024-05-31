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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly ICacheData _memoryCache;

        public CategoryService(ICategoryRepository repo, ICacheData memoryCache)
        {
            _repo = repo;
            _memoryCache = memoryCache;
        }

        //GET All
        public List<Category> GetAll()
        {
            var data = new List<Category>();
            try
            {
                data = _repo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                data = null;
            }
            return data;
        }

        //Get By Id
        public Category GetById(string Id)
        {
            return _repo.GetById(Id);
        }

        //Add
        public bool Add(Category item)
        {
            try
            {
                _repo.Create(item);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Delete
        public bool Delete(string Id)
        {
            try
            {
                _repo.Delete(Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Update
        public bool Update(Category item)
        {
            try
            {
                _repo.Update(item);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}