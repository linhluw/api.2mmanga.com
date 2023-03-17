using MyWeb.DAL.Data;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.DAL.Repository
{
    public class SanPhamRepository : IRepository<SanPham>
    {
        private ApplicationDbContext _dbContext;

        public SanPhamRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<SanPham> Create(SanPham _object)
        {
            _object.Id = 0;//gán = 0
            var obj = await _dbContext.SanPham.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(SanPham _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<SanPham> GetAll()
        {
            try
            {
                return _dbContext.SanPham;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public SanPham GetById(int Id)
        {
            return _dbContext.SanPham.FirstOrDefault(x => x.Id == Id);
        }

        public void Update(SanPham _object)
        {
            _dbContext.SanPham.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}