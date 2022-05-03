using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Configuration;
namespace AddressBook
{
    public class ContactDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
       
        public ContactDetails(string FirstName, string LastName, string Address, string City, string State, string Zipcode, string PhoneNumber,string EmailId)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.City = City;
            this.State = State;
            this.Zipcode = Zipcode;
            this.PhoneNumber = PhoneNumber;
            this.EmailId = EmailId;
        }
        public ContactDetails()
        {

        }

        public string toString()
        {
            return "\nFirst Name :" + FirstName + "\nLast Name :" + LastName + "\nAddress :" + Address + "\nCity:" + City + "\nstate :" + State + "\nzip code :" + Zipcode + "\nPhone number" + PhoneNumber + "\nemail :" + EmailId;
        }

    }
}
