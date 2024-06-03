using System;
using System.Collections.Generic;

namespace MyWeb.BAL.ViewModels.Response
{
    public class CartResponse
    {
        /// <summary>
        /// ID sản phẩm
        /// </summary>
        public string FK_ProductId { get; set; } = string.Empty;

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
        /// Đã bán hết
        /// </summary>
        public bool IsSoldAll { get; set; } = false;
    }
}