using MyWeb.BAL.ViewModels.Requests;
using MyWeb.BAL.ViewModels.Response;
using MyWeb.COM.Utilities;
using MyWeb.DAL.Models;

namespace MyWeb.BAL.Service
{
    public interface INewsService : IBaseService<News>
    {
        PaginatedItem<NewsSearchResponse> GetNewsPaginated(NewsSearchRequest rq);

        NewsDetailResponse GetDetail(string tag);
    }
}