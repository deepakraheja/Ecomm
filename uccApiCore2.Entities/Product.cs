using System;
using System.Collections.Generic;
using System.Text;

namespace uccApiCore2.Entities
{
    public class Product : ProductImage
    {
        public int ProductID { get; set; } = 0;
        public string ProductName { get; set; }
        public string ShortDetails { get; set; } = "";
        public string Description { get; set; } = "";
        public int SupplierID { get; set; } = 0;
        public int BrandId { get; set; } = 0;
        public int StockQty { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public decimal SalePrice { get; set; } = 0;
        public bool AvailableSize { get; set; } = false;
        public bool AvailableColors { get; set; } = false;
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal Discount { get; set; } = 0;
        public bool DiscountAvailable { get; set; } = false;
        public bool ProductAvailable { get; set; } = false;
        public int CreatedBy { get; set; } = 0;
        public int Modifiedby { get; set; } = 0;
        public bool Featured { get; set; } = false;
        public bool Latest { get; set; } = false;
        public bool OnSale { get; set; } = false;
        public bool TopSelling { get; set; } = false;
        public bool HotOffer { get; set; } = false;
        public bool Active { get; set; } = false;
        public string Subcatecode { get; set; }
        public string Large { get; set; }
        public string SubcategoryName { get; set; }
        public int SubCategoryID { get; set; } = 0;
        public int CategoryID { get; set; } = 0;
        public string BrandName { get; set; }
        public string[] BannerImg { get; set; }
        public string[] SmallImg { get; set; }
        public string[] ProductImg { get; set; }
    }
}

