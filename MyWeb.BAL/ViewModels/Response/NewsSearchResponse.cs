using System;

namespace MyWeb.BAL.ViewModels.Response
{
    public class NewsSearchResponse
    {
        /// <summary>
        /// ID bài viết
        /// </summary>
        public string PK_NewsId { get; set; } = string.Empty;

        /// <summary>
        /// Tên bài viết
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Url bài viết
        /// </summary>
        public string TagName { get; set; } = string.Empty;

        /// <summary>
        /// Tên nhóm bài viết
        /// </summary>
        public string GroupNewsName { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả ngắn
        /// </summary>
        public string ShortDetail { get; set; } = string.Empty;

        /// <summary>
        /// Ảnh bài viết
        /// </summary>
        public string Images { get; set; } = string.Empty;

        /// <summary>
        /// Tag
        /// </summary>
        public string TagIDs { get; set; } = string.Empty;

        /// <summary>
        /// Cấu hình ngày phát hành
        /// </summary>
        public DateTime CreatedPush { get; set; } = DateTime.Now;
    }

    public class NewsDetailResponse : NewsSearchResponse
    {
        /// <summary>
        /// Nội dung bài viết
        /// </summary>
        public string Detail { get; set; } = string.Empty;
    }

}