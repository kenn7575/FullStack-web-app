using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class AddressRepository
    {
        public Address Retrieve(int addressId)
        {
            //create instance of Address class
            Address address = new Address(addressId);

            //code that retrieves the defined address

            //temporary hard-coded values to return
            //a populated address
            if (addressId == 1)
            {
                address.AddressType = "Home";
                address.StreetLine1 = "123 Main St";
                address.StreetLine2 = "Apt 1";
                address.City = "Seattle";
                address.State = "WA";
                address.Country = "USA";
                address.PostalCode = "98052";
            }
            return address;
        }
        //retrieve by customer id
        public IEnumerable<Address> RetrieveByCustomerId(int customerId)
        {
            //code that retrieves the defined addresses for the customer
            
            //temporary hard-coded values to return
            //a set of addresses for the customer
            var addressList = new List<Address>();
            Address address = new Address(1)
            {
                AddressType = "Home",
                StreetLine1 = "123 Main St",
                StreetLine2 = "Apt 1",
                City = "Seattle",
                State = "WA",
                Country = "USA",
                PostalCode = "98052"
            };
            addressList.Add(address);

            address = new Address(2)
            {
                AddressType = "Work",
                StreetLine1 = "456 Main St",
                City = "Seattle",
                State = "WA",
                Country = "USA",
                PostalCode = "98052"
            };
            addressList.Add(address);
            return addressList;
        }
        //save the current address
        public bool Save(Address address)
        {
            bool success = true;
            if (address.HasChanges)
            {
                if (address.IsValid)
                {
                    if (address.IsNeW)
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
