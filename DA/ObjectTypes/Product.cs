using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    
    internal class Product
    {
      
        public int? ProductId { get;  set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double? CurrentPrice { get; set; }
        public int? QuantityInStock { get; set; }
    }
}
