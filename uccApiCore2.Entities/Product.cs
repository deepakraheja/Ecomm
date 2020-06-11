using System;
using System.Collections.Generic;
using System.Data;
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
        //public string Large { get; set; }
        public string SubcategoryName { get; set; }
        public int SubCategoryID { get; set; } = 0;
        public int CategoryID { get; set; } = 0;
        public string BrandName { get; set; }
        public string[] BannerImg { get; set; }
        public string[] SmallImg { get; set; }
        public string[] ProductImg { get; set; }

        public string RowID { get; set; }
        public string Type { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string BannerImage { get; set; }
        public string FrontImage { get; set; }
        public string SupplierName { get; set; }
        public decimal price { get; set; }
    }
}

