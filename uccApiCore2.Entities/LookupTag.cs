using System;
using System.Collections.Generic;
using System.Text;

namespace uccApiCore2.Entities
{
    public class LookupTag
    {
        public int TagId { get; set; } = 0;
        public string TagName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; } = false;
        public int CreatedBy { get; set; } = 0;
        public string CreatedDate { get; set; }
        public int ModifiedBy { get; set; } = 0;
        public string ModifiedDate { get; set; }
    }
}
