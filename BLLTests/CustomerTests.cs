using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BL;

namespace BLTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            //arrange
            Customer customer = new Customer
            {
                FName = "John",
                LName = "Doe"
            };
            string expected = "John Doe";

            //act
            string actual = customer.FullName;

            //assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            //arrange
            Customer customer = new Customer
            {
                LName = "Doe"
            };
            string expected = "Doe";

            //act
            string actual = customer.FullName;

            //assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            //arrange
            Customer customer = new Customer
            {
                FName = "John"
            };
            string expected = "John";

            //act
            string actual = customer.FullName;

            //assert
            Assert.AreEqual(expected, actual);

        }
        
        [TestMethod]
        public void SuccessfulValidationTest()
        {
            //arrange
            Customer customer = new Customer(1)
            {
                FName = "John",
                LName = "Doe",
                Email = "Kenn7575@gmail.com",
                Phone = "123-456-7890"

            };
            Address address = new Address
            {
                AddressType = "home",
                StreetLine1 = "123 Main St",
                StreetLine2 = "Apt 1",
                City = "Seattle",
                State = "WA",
                Country = "USA",
                PostalCode = "98101"
            };
            customer.AddressList.Add(address);
            bool expected = true;
            //act
            bool actual = customer.Validate();
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FaliedValidationTest1()
        {
            //arrange
            Customer customer = new Customer(1)
            {
                FName = "John",
                LName = "",
                Email = "Kenn7575@gmail.com",
                Phone = "123-456-7890"

            };
            Address address = new Address
            {
                AddressType = "home",
                StreetLine1 = "123 Main St",
                StreetLine2 = "Apt 1",
                City = "Seattle",
                State = "WA",
                Country = "USA",
                PostalCode = "98101"
            };
            customer.AddressList.Add(address);
            bool expected = false;
            //act
            bool actual = customer.Validate();
            //assert
            Assert.AreEqual(expected, actual);
        }
        public void FaliedValidationTest2()
        {
            //arrange
            Customer customer = new Customer
            {
                FName = "John",
                LName = "Jhonson",
                Email = "Kenn7575@gmail.com",
                Phone = "123-456-7890",
                //missing CustomerID
            };
            Address address = new Address
            {
                AddressType = "home",
                StreetLine1 = "123 Main St",
                StreetLine2 = "Apt 1",
                City = "Seattle",
                State = "WA",
                Country = "USA",
                PostalCode = "98101"
            };
            customer.AddressList.Add(address);
            bool expected = false;
            //act
            bool actual = customer.Validate();
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValidateConstructorTest()
        {
            //arrange
            Customer customer = new Customer(1);
            int expected = 1;
            //act
            int actual = customer.CustomerID;
            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}
 