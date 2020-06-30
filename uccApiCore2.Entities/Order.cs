using System;
using System.Collections.Generic;
using System.Text;

namespace uccApiCore2.Entities
{
    public class Order : BillingAddress
    {
        public int OrderId { get; set; } = 0;
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public int PaymentId { get; set; } = 0;
        public int Tax { get; set; } = 0;
        public int Total { get; set; } = 0;
        public string Notes { get; set; }
        public int UserID { get; set; } = 0;
        public int OrderDetailsID { get; set; } = 0;
        public int ProductSizeColorId { get; set; } = 0;
        public int Price { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public int Discount { get; set; } = 0;
    }
}
