using Microsoft.Extensions.Logging;
using MyWeb.BAL.Service;
using System;
using System.Threading.Tasks;

namespace MyWeb.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ILogger<DbInitializer> _logger;
        private readonly IChiTietHoaDonBanService _chiTietHoaDonBanService;
        private readonly IChiTietHoaDonNhapService _chiTietHoaDonNhapService;
        private readonly IDanhMucService _danhMucService;
        private readonly IHoaDonBanService _hoaDonBanService;
        private readonly IHoaDonNhapService _hoaDonNhapService;
        private readonly INhaXuatBanService _nhaXuatBanService;
        private readonly ISanPhamService _sanPhamService;

        public DbInitializer(ILogger<DbInitializer> logger, 
            IChiTietHoaDonBanService chiTietHoaDonBanService,
            IChiTietHoaDonNhapService chiTietHoaDonNhapService,
            IDanhMucService danhMucService,
            IHoaDonBanService hoaDonBanService,
            IHoaDonNhapService hoaDonNhapService,
            INhaXuatBanService nhaXuatBanService,
            ISanPhamService sanPhamService)
        {
            _logger = logger;
            _chiTietHoaDonBanService = chiTietHoaDonBanService;
            _chiTietHoaDonNhapService = chiTietHoaDonNhapService;
            _danhMucService = danhMucService;
            _hoaDonBanService = hoaDonBanService;
            _hoaDonNhapService = hoaDonNhapService;
            _nhaXuatBanService = nhaXuatBanService;
            _sanPhamService = sanPhamService;
        }

        public async Task SeedFromServiceCacheToInstanceCache()
        {
            try
            {
                ////Lấy lại cache bảng Hướng
                //_directionService.RemoveCache();
                //_directionService.GetAll();
                ////Lấy lại cache bảng nhóm tin
                //_groupNewsService.RemoveCache();
                //_groupNewsService.GetAll();
                ////Lấy lại cache bảng giấy tờ pháp lý
                //_legalDocumentsService.RemoveCache();
                //_legalDocumentsService.GetAll();
                ////Lấy lại cache bảng tin
                //_newsService.RemoveCache();
                //_newsService.GetAll();
                ////Lấy lại cache bảng người dùng
                //_personsService.RemoveCache();
                //_personsService.GetAll();
                ////Lấy lại cache bảng kiểu bds
                //_serviceTypeService.RemoveCache();
                //_serviceTypeService.GetAll();
                ////Lấy lại cache bảng trạng thái bds
                //_statusHomeService.RemoveCache();
                //_statusHomeService.GetAll();

                await Task.Delay(0);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi thực thi SeedFromServiceCacheToInstanceCache: {ex}");
            }
        }
    }
}
