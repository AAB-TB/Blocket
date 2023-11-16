using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocket
{
    public class Ad
    {
        public int AdID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public string FrontImagePath { get; set; }
        public Category Category { get; set; }
    }
}
