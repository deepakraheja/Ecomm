using System;
using System.Collections.Generic;
using System.Text;

namespace uccApiCore2.Entities
{
    public class ProductSizeSet
    {
        public int SetNo { get; set; } = 0;
        public int Qty { get; set; } = 1;
        public int SelectedQty { get; set; } = 1;
        public Boolean IsSelected { get; set; } = false;
        public string Details { get; set; }

        public int ProductSizeId { get; set; } = 0;

        public string[] ProductImg { get; set; }

        public int Piece { get; set; }

        public double AveragePrice
        {
            get { return Convert.ToDouble(((SalePrice / Piece).ToString("0.00"))); }

        }

        public int Price { get; set; } = 0;
        public int SalePrice { get; set; } = 0;

        public Double Discount
        {
            get { return Convert.ToDouble((((Price - SalePrice) * 100) / Price).ToString("0.00")); }

        }
    }
}
