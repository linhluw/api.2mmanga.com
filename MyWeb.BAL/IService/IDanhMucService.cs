using MyWeb.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWeb.BAL.Service
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        Category GetById(string Id);

        bool Add(Category item);

        bool Delete(string Id);

        bool Update(Category item);
    }
}