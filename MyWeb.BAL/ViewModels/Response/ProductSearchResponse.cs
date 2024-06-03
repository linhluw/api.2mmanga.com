using System;
using System.Collections.Generic;

namespace MyWeb.BAL.ViewModels.Response
{
    public class ProductSearchResponse
    {
        /// <summary>
        /// ID sản phẩm
        /// </summary>
        public string PK_ProductId { get; set; } = string.Empty;

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Url sản phẩm
        /// </summary>
        public string TagName { get; set; } = string.Empty;

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
        /// Giá bản
        /// </summary>
        public int Payments { get; set; } = 0;

        /// <summary>
        /// ID nhà xuất bản
        /// </summary>
        public string PublishedName { get; set; } = string.Empty;

        /// <summary>
        /// ID danh mục sản phẩm
        /// </summary>
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>
        /// Ngày phát hành
        /// </summary>
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Đã bán hết
        /// </summary>
        public bool IsSoldAll { get; set; } = false;
    }

    public class ProductDetailResponse : ProductSearchResponse
    {
        /// <summary>
        /// Nội dung
        /// </summary>
        public string Details { get; set; } = string.Empty;

        /// <summary>
        /// Danh sách ảnh
        /// </summary>
        public List<string> LstImage { get; set; } = new List<string>();
    }

}