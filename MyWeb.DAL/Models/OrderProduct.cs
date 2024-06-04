namespace MyWeb.DAL.Models
{
    public class OrderProduct
    {
        public string FK_OrderId { get; set; } = string.Empty;

        public string FK_ProductId { get; set; } = string.Empty;

        public int Quantity { get; set; } = 0;

        public int Price { get; set; } = 0;

        public int Discount { get; set; } = 0;

        public int Payments { get; set; } = 0;
    }
}