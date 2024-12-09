using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.BAL.ViewModels.Sapo
{
    public class ImageSapo
    {
        public string path { get; set; }
        public string full_path { get; set; }
        public string file_name { get; set; }
        public int position { get; set; }
    }

    public class InventorySapo
    {

        public double available { get; set; } // còn bán được
        public double committed { get; set; } // đã đặt

    }

    public class MetadataSapo
    {
        public int total { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
    }

    public class ProductSapo
    {
        public List<VariantSapo> variants { get; set; }
        public List<ImageSapo> images { get; set; }
        public DateTime created_on { get; set; } // ngày tạo
    }

    public class RootSapo
    {
        public MetadataSapo metadata { get; set; }
        public List<ProductSapo> products { get; set; }
    }

    public class VariantSapo
    {
        public int category_id { get; set; } // thể loại
        public int brand_id { get; set; } // nhãn hiệu
        public int product_id { get; set; } //id sản phẩm 194542853
        public double variant_retail_price { get; set; } // giá bán lẻ
        public double variant_import_price { get; set; } // giá nhập
        public string product_name { get; set; } // Tên sản phẩm
        public string sku { get; set; } // PVN1518
        public double weight_value { get; set; } // trọng lượng
        public string weight_unit { get; set; } // kiểu trọng lượng g , kg
        public List<InventorySapo> inventories { get; set; }
        public List<ImageSapo> images { get; set; }
    }

    public enum BrandID
    {
        [Description("AMAK")]
        AMAK = 1826158,

        [Description("IPM")]
        IPM = 1708650,

        [Description("NXB Trẻ")]
        Tre = 1708647,

        [Description("NXB Kim Đồng")]
        KimDong = 1708549,
    }

    public enum CategoriesID
    {
        [Description("Văn Phòng Phẩm")]
        VanPhongPham = 2412883,

        [Description("Tiểu Thuyết")]
        LightNovel = 2387914,

        [Description("Truyện Tranh")]
        Comic = 2387619,
    }
}
