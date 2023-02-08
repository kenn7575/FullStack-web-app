using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_APP
{
    public class Customer : EntityBase
    {
        public Customer() : this(0)
        {
            
        }
        public Customer(int customerID)
        {
            CustomerID = customerID;
            AddressList = new List<Address>();

        }
        //properties
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Address> AddressList { get; set; }
        public int CustomerID { get; private set; }
        public static int InstanceCount { get; set;}
        public string FullName
        {
            get
            {
                //if FName is null or empty return LName
                if (string.IsNullOrWhiteSpace(FName)) return LName;
                //if LName is null or empty return FName
                if (string.IsNullOrWhiteSpace(LName)) return FName;
                //if FName and LName are not null or empty return FName + " " + LName
                return FName + " " + LName;
            }
        }
        //methods
        public override bool Validate()
        {
            
            var errorsCount = 0;
            if (string.IsNullOrWhiteSpace(LName)) errorsCount++;
            if (string.IsNullOrWhiteSpace(FName)) errorsCount++;
            if (string.IsNullOrWhiteSpace(Email)) errorsCount++;
            //if no address
            if (AddressList == null || AddressList.Count == 0) errorsCount++;

            if (string.IsNullOrWhiteSpace(Phone)) errorsCount++;
            if (CustomerID <= 0) errorsCount++;

            //validates errorsCount
            if (errorsCount > 0) return false;
            else return true;
        }
    }
}
