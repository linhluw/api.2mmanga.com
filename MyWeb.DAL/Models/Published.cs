using System;

namespace MyWeb.DAL.Models
{
    public class Category
    {
        public string PK_CategoryId { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;
    }
}