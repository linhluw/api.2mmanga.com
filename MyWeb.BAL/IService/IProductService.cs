using MyWeb.BAL.ViewModels.Requests;
using MyWeb.BAL.ViewModels.Response;
using MyWeb.COM.Utilities;
using MyWeb.DAL.Models;
using System.Collections.Generic;

namespace MyWeb.BAL.Service
{
    public interface IProductService : IBaseService<Product>
    {
        bool CreatedDataSapo(string adminSesionId);

        PaginatedItem<ProductSearchResponse> GetProductPaginated(ProductSearchRequest rq);

        ProductDetailResponse GetDetail(string tag);

        List<CartResponse> GetCart(string userid);

        bool Order(OrderCreatedOrUpdatedRequest item);
    }
}