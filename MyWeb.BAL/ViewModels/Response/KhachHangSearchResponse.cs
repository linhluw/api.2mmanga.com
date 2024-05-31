using System;

namespace MyWeb.BAL.ViewModels.Response
{
    public class KhachHangSearchResponse
    {
        public int Id { get; set; }

        public string TenKhachHang { get; set; } = string.Empty;

        public string SoDienThoai { get; set; } = string.Empty;

        public string DiaChi { get; set; } = string.Empty;
    }
}