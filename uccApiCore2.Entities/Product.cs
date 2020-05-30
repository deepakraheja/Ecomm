using System;
using System.Collections.Generic;
using System.Text;

namespace uccApiCore2.Entities
{
    public class Product : ProductImage
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public string ShortDetails { get; set; } = "";
        public string Description { get; set; } = "";

        public int SupplierID { get; set; }

        public int BrandId { get; set; } = 0;
        public int StockQty { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public bool AvailableSize { get; set; }
        public bool AvailableColors { get; set; }
        public string Size { get; set; }

        public string Color { get; set; }
        public decimal Discount { get; set; }
        public bool DiscountAvailable { get; set; }
        public bool ProductAvailable { get; set; }

        public int CreatedBy { get; set; }
        public int Modifiedby { get; set; }
        public bool Featured { get; set; }
        public bool Latest { get; set; }

        public bool OnSale { get; set; }
        public bool TopSelling { get; set; }
        public bool HotOffer { get; set; }

        public bool Active { get; set; }

        public string Subcatecode { get; set; } = "";

        public string SubcategoryName { get; set; } = "";


    }
}

