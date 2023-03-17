using System.ComponentModel;

namespace MyWeb.ApiController
{
    public enum ResponseCodeEnums
    {
        [Description("Thành công")]
        Success = 0,

        [Description("Lỗi cấu trúc dữ liệu đầu vào")]
        ErrorTypeParams = 1,

        [Description("Dịch vụ đang tạm dừng")]
        ServiceStop = 2,

        [Description("Sai thông tin key")]
        ErrorKey,

        [Description("Địa chỉ IP không có quyền truy xuất")]
        IpUnAuthorize,

        [Description("Không có quyền sử dụng phương thức")]
        UnAuthorize,

        [Description("Các lỗi khác")]
        Other,

        [Description("Đã tồn tại")]
        AlreadyExist,

        [Description("Lỗi không hợp lệ đầu vào")]
        Novalidate
    }
}
