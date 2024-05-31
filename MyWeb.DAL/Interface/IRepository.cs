using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MyWeb.DAL.Interface
{
    public interface IRepository<T>
    {
        public void Create(T _object);

        public void Update(T _object);

        public List<T> GetAll();
    }
}