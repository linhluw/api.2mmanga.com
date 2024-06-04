using MyWeb.DAL.Models;
using System.Collections.Generic;

namespace MyWeb.DAL.Interface
{
    public interface IRepository<T>
    {
        bool CreateOrUpdate(T _object);

        bool Delete(T _object);

        List<T> GetAll();

        T GetById(string Id);
    }
}