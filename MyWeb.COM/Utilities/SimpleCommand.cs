using System;

namespace MyWeb.COM.Utilities
{
    public abstract class SimpleCommand
    {
        /// <summary>
        /// Từ Khóa
        /// </summary>
        public string KeySearch { get; set; } = string.Empty;

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
