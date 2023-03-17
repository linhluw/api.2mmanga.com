using MyWeb.DAL.Data;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.DAL.Repository
{
    public class HoaDonNhapRepository : IRepository<HoaDonNhap>
    {
        private ApplicationDbContext _dbContext;

        public HoaDonNhapRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<HoaDonNhap> Create(HoaDonNhap _object)
        {
            var obj = await _dbContext.HoaDonNhap.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(HoaDonNhap _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<HoaDonNhap> GetAll()
        {
            try
            {
                return _dbContext.HoaDonNhap;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public HoaDonNhap GetById(string MaHoaDonNhap)
        {
            return _dbContext.HoaDonNhap.FirstOrDefault(x => x.MaHoaDon == MaHoaDonNhap);
        }

        public void Update(HoaDonNhap _object)
        {
            _dbContext.HoaDonNhap.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}