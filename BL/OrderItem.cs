using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace BL
{
    public class OrderItem : EntityBase
    {
        public OrderItem()
        {

        }
        public OrderItem(int orderItemId)
        {
            OrderItemId = orderItemId;
        }
        public int OrderItemId { get; private set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? ActualPrice { get; set; }
        public override bool Validate()
        {
            var errorsCount = 0;
            if (Quantity <= 0) errorsCount++;
            if (ActualPrice <= 0 || ActualPrice == null) errorsCount++;
            if (ProductId <= 0) errorsCount++;
            if (OrderItemId <= 0) errorsCount++;
            if (errorsCount > 0) return false;
            else return true;
        }
    }
}
