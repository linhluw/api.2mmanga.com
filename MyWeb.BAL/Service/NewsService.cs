using MyWeb.BAL.Cache;
using MyWeb.COM.Helper;
using MyWeb.COM.Utilities;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using MyWeb.BAL.ViewModels.Response;
using MyWeb.BAL.ViewModels.Requests;
using System.Net;

namespace MyWeb.BAL.Service
{
    public class NewsService : BaseService<News>, INewsService
    {
        private readonly IGroupNewsService _groupNewsService;

        public NewsService(IRepository<News> repo, ICacheData memoryCache, IGroupNewsService groupNewsService) : base(repo, memoryCache)
        {
            _groupNewsService = groupNewsService;
        }

        public override bool CreateOrUpdate(News item, bool isCreate = true)
        {
            item.TagName = StringClass.NameToTag(item.Name);
            item.SignName = StringClass.NameToSign(item.Name);
            return base.CreateOrUpdate(item);
        }

        public override News GetById(string Id)
        {
            return GetAll()?.FirstOrDefault(x => x.PK_NewsId == Id);
        }

        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public PaginatedItem<NewsSearchResponse> GetNewsPaginated(NewsSearchRequest rq)
        {
            var response = new PaginatedItem<NewsSearchResponse>(0, 0, new List<NewsSearchResponse>());
            try
            {
                var cachedData = GetAll();
                if (cachedData != null && cachedData.Count > 0)
                {
                    // lọc theo từ khóa
                    var data = cachedData.Where(x => ((x.Name.ToLower().Contains(rq.KeySearch.ToLower())) || (x.SignName.ToLower().Contains(rq.KeySearch.ToLower())))).ToList();

                    // lọc theo danh mục
                    if (!string.IsNullOrEmpty(rq.GroupNewsId))
                    {
                        data = data.Where(x => x.FK_GroupNewsId == rq.GroupNewsId).ToList();
                    }

                    // lọc theo trạng thái phát hành
                    if (rq.IsPublish != null)
                    {
                        data = data.Where(x => x.IsPublish == rq.IsPublish).ToList();
                    }

                    // lọc theo trạng thái sản phẩm
                    if (rq.IsActive != null)
                    {
                        data = data.Where(x => x.IsActive == rq.IsActive).ToList();
                    }

                    var totals = data.Count();

                    // phân trang dữ liệu
                    data = data.Skip((rq.PageIndex - 1) * rq.PageSize).Take(rq.PageSize).ToList();
                    if (data != null && data.Count > 0)
                    {
                        var groupnews = _groupNewsService.GetAll();

                        var dataRespone = from post in data
                                    join groupn in groupnews on post.FK_GroupNewsId equals groupn.PK_GroupNewsId
                                    select new NewsSearchResponse
                                    {
                                        PK_NewsId = post.PK_NewsId,
                                        Name = post.Name,
                                        TagName = post.TagName,
                                        GroupNewsName = groupn.Name,
                                        ShortDetail = post.ShortDetail,
                                        Images = post.Images,
                                        TagIDs = post.TagIDs,
                                        CreatedPush = post.CreatedPush
                                    };

                        response = new PaginatedItem<NewsSearchResponse>(
                        totals, totals % rq.PageSize == 0 ? totals / rq.PageSize : totals / rq.PageSize + 1,
                        dataRespone.ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("GetNewsPaginated", ex);
                return null;
            }
            return response;
        }

        /// <summary>
        /// Lấy chi tiết sản phẩm theo TagName
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public NewsDetailResponse GetDetail(string tag)
        {
            var response = new NewsDetailResponse();
            var item = GetAll()?.FirstOrDefault(x => x.TagName == tag);
            if (item != null)
            {
                response.PK_NewsId = item.PK_NewsId;
                response.Name = item.Name;
                response.TagName = item.TagName;
                response.GroupNewsName = _groupNewsService.GetById(item.FK_GroupNewsId).Name;
                response.ShortDetail = item.ShortDetail;
                response.Images = item.Images;
                response.TagIDs = item.TagIDs;
                response.CreatedPush = item.CreatedPush;
                response.Detail = item.Detail;
            }
            return response;
        }
    }
}