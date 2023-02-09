using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BL;
using System.Collections.Generic;


namespace BLTests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
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
            Assert.AreEqual(expected.CustomerID, actual.CustomerID);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.FName, actual.FName);
            Assert.AreEqual(expected.LName, actual.LName);
        }
        [TestMethod]
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
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
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
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
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
            Assert.AreNotEqual(expected.CustomerID, actual.CustomerID);
            Assert.AreNotEqual(expected.Email, actual.Email);
            Assert.AreNotEqual(expected.FName, actual.FName);
            Assert.AreNotEqual(expected.LName, actual.LName);
        }
        [TestMethod]
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
            Assert.AreEqual(expected.CustomerID, actual.CustomerID);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.FName, actual.FName);
            Assert.AreEqual(expected.LName, actual.LName);

            for (int i = 0; i < 1; i++)
            {
                Assert.AreEqual(expected.AddressList[i].AddressType, actual.AddressList[i].AddressType);
                Assert.AreEqual(expected.AddressList[i].StreetLine1, actual.AddressList[i].StreetLine1);
                Assert.AreEqual(expected.AddressList[i].StreetLine2, actual.AddressList[i].StreetLine2);
                Assert.AreEqual(expected.AddressList[i].City, actual.AddressList[i].City);
                Assert.AreEqual(expected.AddressList[i].State, actual.AddressList[i].State);
                Assert.AreEqual(expected.AddressList[i].Country, actual.AddressList[i].Country);
                Assert.AreEqual(expected.AddressList[i].PostalCode, actual.AddressList[i].PostalCode);
            }
        }
    }
}