using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Address_book
{
    class ContactDetails
    {
        public string Laste_name;
        public string First_name;
        public string Address;
        public string Cite;
        public string State;
        public int Phone_number;
        public int Zip;
        public string Email;
        public ContactDetails(string Laste_name,string First_name,string Address,string Cite,string State,int Phone_number,int Zip,string Email)
        {
            this.Laste_name = Laste_name;
            this.First_name = First_name;
            this.Address = Address;
            this.Cite = Cite;
            this.State = State;
            this.Phone_number = Phone_number;
            this.Zip = Zip;
            this.Email = Email;
        }
        public string ToString()
        {
            return "Details of " + First_name +" " +Laste_name + "\n Address : " + Address + "\n Cite : " + Cite + "\n State : " + State + "\n Phone Number : " + Phone_number + "\n Zip Code : " + Zip + "\n Email Id : " + Email;
        }
    }   
    class Program
    {
        public ArrayList ContactDetailIsList;
        private Dictionary<string, ContactDetails> ContactDetailIsListMap;
        public Program()
        {
            ContactDetailIsList = new ArrayList();
            ContactDetailIsListMap= new Dictionary<string, ContactDetails>();
        }
        public void AddDeatails(string Laste_name, string First_name, string Address, string Cite, string State, int Phone_number, int Zip, string Email)
        {
            ContactDetails contactDetails =new ContactDetails(Laste_name, First_name, Address, Cite, State, Phone_number, Zip, Email);
            ContactDetailIsList.Add(contactDetails);
            ContactDetailIsListMap.Add(First_name,contactDetails);
        }
        public void ComputeDetails()
        {
            foreach (ContactDetails contact in ContactDetailIsList)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book");
            Program program = new Program();
            Console.WriteLine("Enter the Last Name : ");
            string Laste_name = (Console.ReadLine());
            Console.WriteLine("Enter the First Name : ");
            string First_name = (Console.ReadLine());
            Console.WriteLine("Enter the Address :");
            string Address = (Console.ReadLine());
            Console.WriteLine("Enter city : ");
            string Cite = (Console.ReadLine());
            Console.WriteLine("Enter State : ");
            string State = (Console.ReadLine());
            Console.WriteLine("Enter the mobile number : ");
            int Phone_number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Zip Code : ");
            int Zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the email id : ");
            string Email = (Console.ReadLine());
            program.AddDeatails(Laste_name, First_name, Address, Cite, State, Phone_number, Zip, Email);
            program.ComputeDetails();
        }
        
    }
}
    






