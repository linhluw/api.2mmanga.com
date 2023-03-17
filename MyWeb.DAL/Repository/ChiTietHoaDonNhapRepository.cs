using MyWeb.DAL.Data;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.DAL.Repository
{
    public class ChiTietHoaDonNhapRepository : IRepository<ChiTietHoaDonNhap>
    {
        private ApplicationDbContext _dbContext;

        public ChiTietHoaDonNhapRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<ChiTietHoaDonNhap> Create(ChiTietHoaDonNhap _object)
        {
            var obj = await _dbContext.ChiTietHoaDonNhap.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(ChiTietHoaDonNhap _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ChiTietHoaDonNhap> GetAll()
        {
            try
            {
                return _dbContext.ChiTietHoaDonNhap;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ChiTietHoaDonNhap GetById(string MaHoaDon)
        {
            return _dbContext.ChiTietHoaDonNhap.FirstOrDefault(x => x.IdMaHoaDon == MaHoaDon);
        }

        public void Update(ChiTietHoaDonNhap _object)
        {
            _dbContext.ChiTietHoaDonNhap.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}