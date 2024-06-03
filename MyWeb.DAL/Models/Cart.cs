using System;

namespace MyWeb.DAL.Models
{
    public class Cart
    {
        public string FK_ProductId { get; set; } = string.Empty;

        public int Quantity { get; set; } = 0;

        public string FK_UserId { get; set; } = string.Empty;
    }
}