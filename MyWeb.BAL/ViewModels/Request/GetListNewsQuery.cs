using MyWeb.COM.Utilities;

namespace MyWeb.BAL.ViewModels.Requests
{
    public class GetListNewsQuery : SimpleCommand
    {
        /// <summary>
        /// Từ Khóa
        /// </summary>
        public string KeySearch { get; set; } = string.Empty;

        /// <summary>
        /// Kiểu Search
        /// </summary>
        public int TypeSearch { get; set; } = 0;
    }

    public enum TypeSearch
    {
        MaVach = 0,
        TenSanPham = 1
    }

}
