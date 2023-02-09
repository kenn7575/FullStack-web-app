using System;
using BL;
using System.Collections.Generic;


namespace BLTests
{
 
    public class CustomerRepositoryTest
    {
        [Fact]
        public void RetrieveValid()
        {
            //arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1)
            {
                Email = "example@gmail.com",
                FName = "John",
                LName = "Doe"
            };

            //act
            var actual = customerRepository.Retrieve(1);

            //assert
            Assert.Equal(expected.CustomerID, actual.CustomerID);
            Assert.Equal(expected.Email, actual.Email);
            Assert.Equal(expected.FName, actual.FName);
            Assert.Equal(expected.LName, actual.LName);
        }
        [Fact]
        //test save method
        public void SaveTestValid()
        {
            //arrange
            var customerRepository = new CustomerRepository();
            var updatedCustomer = new Customer(1)
            {
                Email = "example@gmail.com",
                FName = "John",
                LName = "Doe",
                Phone = "123-456-7890",
                HasChanges = true
            };
            Address address = new Address
            {
                AddressType = "Home",
                StreetLine1 = "123 Main St",
                StreetLine2 = "Apt 1",
                City = "Seattle",
                State = "WA",
                Country = "USA",
                PostalCode = "98052"
            };
            updatedCustomer.AddressList.Add(address);
            var expected = true;
            //act
            var actual = customerRepository.Save(updatedCustomer);
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        //test save methon with invalid name
        public void SaveTestMissing()
        {
            //arrange
            var customerRepository = new CustomerRepository();
            var updatedCustomer = new Customer(1)
            {
                Email = "example@gmail.com",
                //missing first name
                LName = "Doe",
                HasChanges = true
            };
            var expected = false;
            //act
            
            var actual = customerRepository.Save(updatedCustomer);
            
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        //retrieve customer with invalid id
        public void RetrieveExistingWithInvalidId()
        {
            //arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(2)
            {
                Email = "example@gmail.com",
                FName = "John",
                LName = "Doe"
            };
            //act
            var actual = customerRepository.Retrieve(10);
            //assert
            Assert.NotEqual(expected.CustomerID, actual.CustomerID);
            Assert.NotEqual(expected.Email, actual.Email);
            Assert.NotEqual(expected.FName, actual.FName);
            Assert.NotEqual(expected.LName, actual.LName);
        }
        [Fact]
        public void RetrieveExistingWithAddress()
        {
            //arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1)
            {
                Email = "example@gmail.com",
                FName = "John",
                LName = "Doe",
                AddressList = new List<Address>()
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
                }
            };
            //act
            var actual = customerRepository.Retrieve(1);
            //assert
            Assert.Equal(expected.CustomerID, actual.CustomerID);
            Assert.Equal(expected.Email, actual.Email);
            Assert.Equal(expected.FName, actual.FName);
            Assert.Equal(expected.LName, actual.LName);

            for (int i = 0; i < 1; i++)
            {
                Assert.Equal(expected.AddressList[i].AddressType, actual.AddressList[i].AddressType);
                Assert.Equal(expected.AddressList[i].StreetLine1, actual.AddressList[i].StreetLine1);
                Assert.Equal(expected.AddressList[i].StreetLine2, actual.AddressList[i].StreetLine2);
                Assert.Equal(expected.AddressList[i].City, actual.AddressList[i].City);
                Assert.Equal(expected.AddressList[i].State, actual.AddressList[i].State);
                Assert.Equal(expected.AddressList[i].Country, actual.AddressList[i].Country);
                Assert.Equal(expected.AddressList[i].PostalCode, actual.AddressList[i].PostalCode);
            }
        }
    }
}