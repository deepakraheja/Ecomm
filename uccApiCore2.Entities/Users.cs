using System;
using System.Collections.Generic;
using System.Text;

namespace uccApiCore2.Entities
{
    public class Users
    {
        public int UserID { get; set; } = 0;
        public bool IsActive { get; set; } = false;
        public string LoginId { get; set; }
        public string password { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public int UserType { get; set; } = 0;
        public string email { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public int IsApproval { get; set; } = 0;
        public int ApprovedBy { get; set; } = 0;
        public string ApprovedDate { get; set; }
        public string ApprovedByUserName { get; set; }
    }
}
