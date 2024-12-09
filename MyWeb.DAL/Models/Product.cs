using System;

namespace MyWeb.DAL.Models
{
    public class Product
    {
        /// <summary>
        /// ID sản phẩm
        /// </summary>
        public string PK_ProductId { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Url sản phẩm
        /// </summary>
        public string TagName { get; set; } = string.Empty;

        /// <summary>
        /// Tên sản phẩm không dấu
        /// </summary>
        public string SignName { get; set; } = string.Empty;

        /// <summary>
        /// Ảnh sản phẩm
        /// </summary>
        public string Images { get; set; } = string.Empty;

        /// <summary>
        /// Số lượng
        /// </summary>
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// Giá sản phẩm
        /// </summary>
        public int Price { get; set; } = 0;

        /// <summary>
        /// Chiết khấu % giá
        /// </summary>
        public int Discount { get; set; } = 0;

        /// <summary>
        /// Trọng lượng
        /// </summary>
        public int Weight { get; set; } = 0;

        /// <summary>
        /// Nội dung
        /// </summary>
        public string Details {  get; set; } = string.Empty;

        /// <summary>
        /// BarCode
        /// </summary>
        public string BarCode { get; set; } = string.Empty;

        /// <summary>
        /// SapoCode
        /// </summary>
        public string SapoCode { get; set; } = string.Empty;

        /// <summary>
        /// ID nhà xuất bản
        /// </summary>
        public string FK_PublishedId { get; set; } = string.Empty;

        /// <summary>
        /// ID danh mục sản phẩm
        /// </summary>
        public string FK_CategoryId { get; set; } = string.Empty;

        /// <summary>
        /// Ngày phát hành
        /// </summary>
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Ngày khởi tạo
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Đã bán hết
        /// </summary>
        public bool IsSoldAll { get; set; } = false;

        /// <summary>
        /// Kiểu Type: HOT, TOP, NORMAL
        /// </summary>
        public int IsType { get; set; } = 0;

        /// <summary>
        /// Phiên bản Lim
        /// </summary>
        public bool IsLimited { get; set; } = false;
    }
}