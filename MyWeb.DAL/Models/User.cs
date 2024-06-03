using System;

namespace MyWeb.DAL.Models
{
    public class User
    {
        public string PK_UserId { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public bool Active { get; set; } = false;

        public int PermissionId { get; set; } = 0;
    }
}