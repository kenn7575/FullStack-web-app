using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Product : EntityBase
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double? CurrentPrice { get; set; }
        public int QuantityInStock { get; set; }
        //public bool isValid => Validate();

        public override bool Validate()
        {
            int errorsCount = 0;
            if (string.IsNullOrWhiteSpace(ProductName)) errorsCount++;
            if (string.IsNullOrWhiteSpace(Description)) errorsCount++;
            if (CurrentPrice is <= 0 or null) errorsCount++;
            if (ProductId <= 0) errorsCount++;
            if (QuantityInStock <= 0) errorsCount++;
            if (errorsCount > 0) return false;
            else return true;
        }
        
    }
}
