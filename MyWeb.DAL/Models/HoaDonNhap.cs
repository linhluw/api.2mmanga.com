using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWeb.DAL.Models
{
    [Table("HoaDonNhap", Schema = "dbo")]
    public class HoaDonNhap
    {
        [Key]
        [Display(Name = "MaHoaDon")]
        public string MaHoaDon { get; set; } = string.Empty;

        [Display(Name = "NoiDung")]
        public string NoiDung { get; set; } = string.Empty;

        [Required]
        [Display(Name = "ThanhTien")]
        public int ThanhTien { get; set; } = 0;

        [Required]
        [Display(Name = "NgayTao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}