using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace BL
{
    public class CustomerRepository
    {
        public CustomerRepository()
        {
            addressRepository = new AddressRepository();
        }
        private AddressRepository addressRepository { get; set; }
        
        //retrieve one customer
        public Customer Retrieve(int customerId)
        {
            //create instance of customer class
            Customer customer = new Customer(customerId);
            //code that retrieves defined customer
            
            //temporary hard coded values to return a populated customer
            if (customerId == 1)
            {
                customer.Email = "example@gmail.com";
                customer.FName = "John";
                customer.LName = "Doe";
                customer.AddressList = new List<Address>()
                {
                    new Address()
                    {
                        AddressType = "home",
                        StreetLine1 = "123 Main St",
                        StreetLine2 = "Apt 1",
                        City = "Seattle",
                        State = "WA",
                        Country = "USA",
                        PostalCode = "98101"
                    },
                    new Address()
                    {
                        AddressType = "work",
                        StreetLine1 = "456 Main St",
                        StreetLine2 = "Apt 2",
                        City = "Seattle",
                        State = "WA",
                        Country = "USA",
                        PostalCode = "98101"
                    }
                };
            }
            return customer;
        }
        //retrieve all customers
        public List<Customer> Retrieve()
        {
            //code that retrieves all of the customers
            return new List<Customer>();
        }
        //saves the current customer
        public bool Save(Customer customer)
        {
            bool success = true;
            if (customer.HasChanges)
            {
                if (customer.IsValid)
                {
                    if (customer.IsNeW)
                    {
                        
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
