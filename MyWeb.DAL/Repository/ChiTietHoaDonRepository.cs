using MyWeb.DAL.Data;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.DAL.Repository
{
    public class ChiTietHoaDonBanRepository : IRepository<ChiTietHoaDonBan>
    {
        private ApplicationDbContext _dbContext;

        public ChiTietHoaDonBanRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<ChiTietHoaDonBan> Create(ChiTietHoaDonBan _object)
        {
            var obj = await _dbContext.ChiTietHoaDonBan.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(ChiTietHoaDonBan _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ChiTietHoaDonBan> GetAll()
        {
            try
            {
                return _dbContext.ChiTietHoaDonBan;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ChiTietHoaDonBan GetById(string MaHoaDon)
        {
            return _dbContext.ChiTietHoaDonBan.FirstOrDefault(x => x.IdMaHoaDon == MaHoaDon);
        }

        public void Update(ChiTietHoaDonBan _object)
        {
            _dbContext.ChiTietHoaDonBan.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}