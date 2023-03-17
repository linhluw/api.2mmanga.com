using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWeb.DAL.Models
{
    [Table("NhaXuatBan", Schema = "dbo")]
    public class NhaXuatBan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Display(Name = "TenNhaXuatBan")]
        public string TenNhaXuatBan { get; set; } = string.Empty;

        [Required]
        [Display(Name = "ChietKhauNhaXuatBan")]
        public int ChietKhauNhaXuatBan { get; set; } = 0;
    }
}