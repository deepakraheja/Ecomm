using System;
using System.Collections.Generic;
using System.Text;

namespace uccApiCore2.Entities
{
    public class ProductSizeColor
    {
        public int ProductSizeColorId { get; set; } = 0;
        public int ProductId { get; set; } = 0;
        public string RowID { get; set; }
        public int Qty { get; set; } = 0;
        public int Price { get; set; } = 0;
        public int SalePrice { get; set; } = 0;
        public bool AvailableSize { get; set; } = false;
        public bool AvailableColors { get; set; } = false;
        public string Size { get; set; }
        public string Color { get; set; }
        public int Discount { get; set; } = 0;
        public bool DiscountAvailable { get; set; } = false;
        public int CreatedBy { get; set; } = 0;
        public int Modifiedby { get; set; } = 0;
        public string[] ProductImg { get; set; }
        public int LookupColorId { get; set; }
    }
}
