using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWeb.DAL.Models
{
    [Table("ChiTietHoaDonBan", Schema = "dbo")]
    public class ChiTietHoaDonBan
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
    }
}