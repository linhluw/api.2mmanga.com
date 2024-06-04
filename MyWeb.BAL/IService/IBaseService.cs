using System.Collections.Generic;

namespace MyWeb.BAL.Service
{
    public interface IBaseService<T>
    {
        List<T> GetAll();

        T GetById(string Id);

        bool CreateOrUpdate(T item, bool isCreate = true);

        bool Delete(T item);
    }
}