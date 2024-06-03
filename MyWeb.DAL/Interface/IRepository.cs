using MyWeb.DAL.Models;
using System.Collections.Generic;

namespace MyWeb.DAL.Interface
{
    public interface IRepository<T>
    {
        bool CreateOrUpdate(T _object);

        bool Delete(string Id);

        List<T> GetAll();

        T GetById(string Id);
    }
}