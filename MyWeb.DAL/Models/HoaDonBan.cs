using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWeb.DAL.Models
{
    [Table("HoaDonBan", Schema = "dbo")]
    public class HoaDonBan
    {
        [Key]
        [Display(Name = "MaHoaDon")]
        public string MaHoaDon { get; set; } = string.Empty;

        [Display(Name = "IdKho")]
        public int IdKho { get; set; }

        [Required]
        [Display(Name = "ThanhTien")]
        public int ThanhTien { get; set; } = 0;

        [Required]
        [Display(Name = "NgayTao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}