using System;

namespace MyWeb.DAL.Models
{
    public class GroupNews
    {
        public string PK_GroupNewsId { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;

        public string TagName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Order { get; set; } = 0;

        public bool IsActive { get; set; } = false;
    }
}