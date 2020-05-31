﻿using System;

namespace uccApiCore2.Entities
{
    public class Category
    {

        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = "";
        public string Description { get; set; } = "";
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public int Modifiedby { get; set; }

        public string Name { get; set; } = "";
        public int SubCategoryID { get; set; }

    }
}