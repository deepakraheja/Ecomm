using System;
using System.Collections.Generic;
using System.Text;

namespace uccApiCore2.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public int Modifiedby { get; set; }


    }
}

