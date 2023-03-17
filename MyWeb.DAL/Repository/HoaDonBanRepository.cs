using MyWeb.DAL.Data;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.DAL.Repository
{
    public class HoaDonBanRepository : IRepository<HoaDonBan>
    {
        private ApplicationDbContext _dbContext;

        public HoaDonBanRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<HoaDonBan> Create(HoaDonBan _object)
        {
            var obj = await _dbContext.HoaDonBan.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(HoaDonBan _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<HoaDonBan> GetAll()
        {
            try
            {
                return _dbContext.HoaDonBan;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public HoaDonBan GetById(string MaHoaDonBan)
        {
            return _dbContext.HoaDonBan.FirstOrDefault(x => x.MaHoaDon == MaHoaDonBan);
        }

        public void Update(HoaDonBan _object)
        {
            _dbContext.HoaDonBan.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}