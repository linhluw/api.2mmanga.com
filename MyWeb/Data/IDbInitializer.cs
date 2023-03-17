using System.Threading.Tasks;

namespace MyWeb.Data
{
    public interface IDbInitializer
    {
        Task SeedFromServiceCacheToInstanceCache();
    }
}
