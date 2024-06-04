using System;

namespace MyWeb.DAL.Models
{
    public class Order
    {
        public string PK_OrderId { get; set; } = Guid.NewGuid().ToString();

        public string FK_UserId { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public int TotalPrice { get; set; } = 0;

        public int Status { get; set; } = 0;

        public bool IsCancel { get; set; } = false;
    }

    public enum NameStatus
    {
        KhoiTaoDon = 0,
        XacNhanDon = 1,
        DaThanhToan = 2,
        DangChuanBi = 3,
        DaVanChuyen = 4,
        HoanThanh = 5
    }
}