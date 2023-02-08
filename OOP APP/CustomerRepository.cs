using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_APP;

namespace OOP_APP
{
    public class CustomerRepository
    {
        public CustomerRepository()
        {
            addressRepository = new AddressRepository();
        }
        private AddressRepository addressRepository { get; set; }
        //retrieve customer
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
