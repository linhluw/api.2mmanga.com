using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWeb.DAL.Models
{
    [Table("SanPham", Schema = "dbo")]
    public class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "TenSanPham")]
        public string TenSanPham { get; set; } = string.Empty;

        [Display(Name = "HinhAnh")]
        public string HinhAnh { get; set; } = string.Empty;

        [Required]
        [Display(Name = "SoLuong")]
        public int SoLuong { get; set; } = 0;

        [Required]
        [Display(Name = "GiaSanPham")]
        public int GiaSanPham { get; set; } = 0;

        [Display(Name = "MaVach")]
        public string MaVach { get; set; } = string.Empty;

        [Required]
        [Display(Name = "IdNhaXuatBan")]
        public int IdNhaXuatBan { get; set; }

        [Required]
        [Display(Name = "IdDanhMuc")]
        public int IdDanhMuc { get; set; }

        [Display(Name = "NgayPhatHanh")]
        public DateTime NgayPhatHanh { get; set; } = DateTime.Now;

        /// <summary>
        /// Số lượng sản phẩm trong kho
        /// </summary>
        [Required]
        [Display(Name = "KhoOffline")]
        public int KhoOffline { get; set; } = 0;

        /// <summary>
        /// Số lượng sản phẩm trong kho
        /// </summary>
        [Required]
        [Display(Name = "KhoShopee")]
        public int KhoShopee { get; set; } = 0;

        /// <summary>
        /// Số lượng sản phẩm trong kho
        /// </summary>
        [Required]
        [Display(Name = "KhoLazada")]
        public int KhoLazada { get; set; } = 0;

        [Display(Name = "NgayTao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}