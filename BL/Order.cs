using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Order : EntityBase
    {
        public Order() { }
        public Order(int orderID)
        {
            OrderID = orderID;
            OrderItems = new List<Product>();
        }
        //properties
        public DateTimeOffset? OrderDate { get; set; }
        public int OrderID { get; private set; }
        public List<Product> OrderItems { get; set; }

        //methods
        public override bool Validate()
        {
            var errorsCount = 0;
            if (OrderDate == null) errorsCount++;
            if (OrderID <= 0) errorsCount++;

            //validates errorsCount
            if (errorsCount > 0) return false;
            else return true;
        }
        


    }
}
