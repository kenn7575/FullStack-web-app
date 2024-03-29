﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Product : EntityBase
    {
        public Product()
        {
            
        }
        public Product(int productID)
        {
            ProductId = productID;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? CurrentPrice { get; set; }
        public int QuantityInStock { get; set; }

        public override bool Validate()
        {
            var errorsCount = 0;
            if (string.IsNullOrWhiteSpace(ProductName)) errorsCount++;
            if (string.IsNullOrWhiteSpace(Description)) errorsCount++;
            if (CurrentPrice <= 0 || CurrentPrice == null) errorsCount++;
            if (ProductId <= 0) errorsCount++;
            if (QuantityInStock <= 0) errorsCount++;
            if (errorsCount > 0) return false;
            else return true;
        }
        
    }
}
