using System;

namespace MyWeb.BAL.ViewModels.Response
{
    public class SanPhamSearchResponse
    {
        public int Id { get; set; }

        public string TenSanPham { get; set; } = string.Empty;

        public int SoLuong { get; set; } = 0;

        public int GiaSanPham { get; set; } = 0;

        public string MaVach { get; set; } = string.Empty;

        public string NhaXuatBan { get; set; } = string.Empty;

        public string DanhMuc { get; set; } = string.Empty;

        public string HinhAnh { get; set; } = string.Empty;

        /// <summary>
        /// Ngày phát hành
        /// </summary>
        public DateTime NgayPhatHanh { get; set; } = DateTime.Now;

        /// <summary>
        /// Số ngày hoạt động sản phẩm được tính từ ngày phát hành đến ngày hiện tại
        /// </summary>
        public double SoNgayHoatDong { get; set; } = 0;
    }
}