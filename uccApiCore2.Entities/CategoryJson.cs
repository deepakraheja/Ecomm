using System;
using System.Collections.Generic;
using System.Text;

namespace uccApiCore2.Entities
{
    public class CategoryJson
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        
        public bool Active { get; set; } = true;
        public List<SubCategoryJson> Children { get; set; }
    }
}
