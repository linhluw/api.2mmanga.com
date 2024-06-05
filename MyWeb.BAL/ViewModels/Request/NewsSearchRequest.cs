using MyWeb.COM.Utilities;

namespace MyWeb.BAL.ViewModels.Requests
{
    public class NewsSearchRequest : SimpleCommand
    {
        /// <summary>
        /// Trạng thái phát hành
        /// </summary>
        public bool? IsPublish { get; set; }

        /// <summary>
        /// Danh mục bài viết
        /// </summary>
        public string? GroupNewsId { get; set; }

        /// <summary>
        /// Trạng thái hoạt động
        /// </summary>
        public bool? IsActive { get; set; }
    }
}
