using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWeb.DAL.Models
{
    [Table("ChiTietHoaDonNhap", Schema = "dbo")]
    public class ChiTietHoaDonNhap
    {
        [Key]
        [Display(Name = "IdMaHoaDon")]
        public string IdMaHoaDon { get; set; } = string.Empty;

        [Key]
        [Display(Name = "IdSanPham")]
        public int IdSanPham { get; set; }

        [Required]
        [Display(Name = "SoLuong")]
        public int SoLuong { get; set; } = 0;

        [Required]
        [Display(Name = "GiaNhap")]
        public int GiaNhap { get; set; } = 0;
    }
}