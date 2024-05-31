using MyWeb.DAL.Models;
using System.Collections.Generic;

namespace MyWeb.DAL.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Delete(string Id);

        Category GetById(string Id);
    }
}