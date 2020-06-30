using System;
using System.Collections.Generic;
using System.Text;

namespace uccApiCore2.Entities
{
    public class BillingAddress
    {
        public int BillingAddressId { get; set; } = 0;
        public int UserId { get; set; } = 0;
        public string FName { get; set; }
        public string LName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string emailId { get; set; }
        public string Phone { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
    }
}
