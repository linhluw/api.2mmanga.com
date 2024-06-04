using System.Collections.Generic;

namespace MyWeb.BAL.ViewModels.Requests
{
    public class OrderCreatedOrUpdatedRequest
    {
        public string PK_OrderId { get; set; } = string.Empty;

        public string FK_UserId { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public List<OrderProductRequest> LstProducts { get; set; } = new List<OrderProductRequest>();
    }

    public class OrderProductRequest
    {
        public string FK_ProductId { get; set; } = string.Empty;

        public int Quantity { get; set; } = 0;
    }
}
