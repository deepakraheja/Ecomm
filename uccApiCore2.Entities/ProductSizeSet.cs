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
        public Boolean IsSelected { get; set; } = true;
        public string Details { get; set; }

        public int ProductSizeId { get; set; } = 0;


    }
}
