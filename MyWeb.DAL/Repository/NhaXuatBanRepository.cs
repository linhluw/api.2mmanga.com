using MyWeb.DAL.Data;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.DAL.Repository
{
    public class NhaXuatBanRepository : IRepository<NhaXuatBan>
    {
        private ApplicationDbContext _dbContext;

        public NhaXuatBanRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<NhaXuatBan> Create(NhaXuatBan _object)
        {
            _object.Id = 0;//gán = 0
            var obj = await _dbContext.NhaXuatBan.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(NhaXuatBan _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<NhaXuatBan> GetAll()
        {
            try
            {
                return _dbContext.NhaXuatBan;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public NhaXuatBan GetById(int Id)
        {
            return _dbContext.NhaXuatBan.FirstOrDefault(x => x.Id == Id);
        }

        public void Update(NhaXuatBan _object)
        {
            _dbContext.NhaXuatBan.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}