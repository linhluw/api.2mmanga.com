using System;

namespace MyWeb.DAL.Models
{
    public class News
    {
        /// <summary>
        /// ID bài viết
        /// </summary>
        public string PK_NewsId { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Tên bài viết
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Url bài viết
        /// </summary>
        public string TagName { get; set; } = string.Empty;

        /// <summary>
        /// Tên bài viết không dấu
        /// </summary>
        public string SignName { get; set; } = string.Empty;

        /// <summary>
        /// ID nhóm bài viết
        /// </summary>
        public string FK_GroupNewsId { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả ngắn
        /// </summary>
        public string ShortDetail {  get; set; } = string.Empty;

        /// <summary>
        /// Nội dung bài viết
        /// </summary>
        public string Detail { get; set; } = string.Empty;

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

        /// <summary>
        /// Ngày khởi tạo
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Người khởi tạo
        /// </summary>
        public string CreatedByUser { get; set; } = string.Empty;

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Người cập nhật
        /// </summary>
        public string UpdatedByUser { get; set; } = string.Empty;

        /// <summary>
        /// Trạng thái phát hành
        /// </summary>
        public bool IsPublish { get; set; } = false;

        /// <summary>
        /// Trạng thái hoạt động
        /// </summary>
        public bool IsActive { get; set; } = false;
    }
}