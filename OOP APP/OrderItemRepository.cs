using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class OrderItemRepository
    {
        //retreive one customer
        public OrderItem Retrieve(int orderItemId)
        {
            //create instance of the customer class
            //pass in the requested id
            OrderItem orderItem = new OrderItem(orderItemId);
            //code that retrieves the defined customer
            
            //temporary hard coded values to return
            //a populated customer
            if (orderItemId == 1)
            {
                orderItem.ProductId = 1;
                orderItem.Quantity = 1;
                orderItem.ActualPrice = 15.96M;
            }
            return orderItem;
        }
        //retrive all customers
        public IEnumerable<OrderItem> Retrieve()
        {
            //code that retrieves all of the customers
            //temporary hard coded values to return
            //a set of customers
            return new List<OrderItem>();
        }
        //saves the current customer
        public bool Save(OrderItem orderItem)
        {
            bool success = true;
            if (orderItem.HasChanges)
            {
                if (orderItem.IsValid)
                {
                    if (orderItem.IsNeW)
                    {
                        //call an insert stored procedure
                    }
                    else
                    {
                        //call an update stored procedure
                    }
                }
                else
                {
                    success = false;
                }
            }
            return success;
        }
    }
}
