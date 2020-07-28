using System;
using System.Collections.Generic;
using System.Text;

namespace uccApiCore2.Entities
{
    public class MainCategory
    {
        public string Title { get; set; }

        public string Type { get; set; }

        public bool MegaMenu { get; set; } = true;

        public bool Active { get; set; } = true;

        public List<Category> Children { get; set; }
    }
}
