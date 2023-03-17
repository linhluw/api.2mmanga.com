using MyWeb.DAL.Data;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.DAL.Repository
{
    public class DanhMucRepository : IRepository<DanhMuc>
    {
        private ApplicationDbContext _dbContext;

        public DanhMucRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<DanhMuc> Create(DanhMuc _object)
        {
            _object.Id = 0;//gán = 0
            var obj = await _dbContext.DanhMuc.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(DanhMuc _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<DanhMuc> GetAll()
        {
            try
            {
                return _dbContext.DanhMuc;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public DanhMuc GetById(int Id)
        {
            return _dbContext.DanhMuc.FirstOrDefault(x => x.Id == Id);
        }

        public void Update(DanhMuc _object)
        {
            _dbContext.DanhMuc.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}