using System;
using System.Collections.Generic;
using System.Text;

namespace uccApiCore2.Entities
{
    public class Cart
    {
        public int CartId { get; set; } = 0;
        public int UserID { get; set; } = 0;
        public int ProductSizeColorId { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public string ProductName { get; set; } = "";
        public int Price { get; set; } = 0;
        public int SalePrice { get; set; } = 0;
        public int Discount { get; set; } = 0;
        public int Qty { get; set; } = 0;
        public string FrontImage { get; set; } = "";
    }
}
