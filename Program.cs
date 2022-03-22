using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace AddressBook
{
    class ContactDetails
    {
        public string FirstName;
        public string LastName;
        public string Address;
        public string City;
        public string State;
        public int Zipcode;
        public int PhoneNumber;
        public string EmailId;
        public ContactDetails(string FirstName, string LastName, string Address, string City, string State, int Zipcode, int PhoneNumber, string EmailId)
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
        public string toString()
        {
            return "\n First Name : " + FirstName + "\n Laste Name : " + LastName + "\n Address: " + Address + "\n City: " + City + "\n State: " + State + "\n Zipcode: " + Zipcode + "\n Phone Number:" + PhoneNumber + "\n EmailId: " + EmailId;
        }
    }
    class Program
    {
        private ArrayList contactDetailsList;
        private Dictionary<string, ContactDetails> contactDetailsMap;
        public Program()
        {
            contactDetailsList = new ArrayList();
            contactDetailsMap = new Dictionary<string, ContactDetails>();
        }
        public void AddDetails()
        {
            Console.WriteLine("\n Enter Your First name");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Enter Your Last name");
            string LastName = Console.ReadLine();
            Console.WriteLine("Enter Your Address");
            string Address = Console.ReadLine();
            Console.WriteLine("Enter Your City");
            string City = Console.ReadLine();
            Console.WriteLine("Enter Your State");
            string State = Console.ReadLine();
            Console.WriteLine("Enter Your Zipcode");
            int Zipcode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Your Phone number");
            int PhoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Your Email Id");
            string EmailId = Console.ReadLine();
            ContactDetails contactDetails = new ContactDetails(FirstName, LastName, Address, City, State, Zipcode, PhoneNumber, EmailId);
            contactDetailsList.Add(contactDetails);
            contactDetailsMap.Add(FirstName, contactDetails);
        }
        public void EditDetails(string key)
        {
                Console.WriteLine("\n Enter Your First name");
                string FirstName = Console.ReadLine();
                Console.WriteLine("Enter Your Last name");
                string LastName = Console.ReadLine();
                Console.WriteLine("Enter Your Address");
                string Address = Console.ReadLine();
                Console.WriteLine("Enter Your City");
                string City = Console.ReadLine();
                Console.WriteLine("Enter Your State");
                string State = Console.ReadLine();
                Console.WriteLine("Enter Your Zipcode");
                int Zipcode = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Your Phone number");
                int PhoneNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Your Email Id");
                string EmailId = Console.ReadLine();
                ContactDetails contactDetails = new ContactDetails(FirstName, LastName, Address, City, State, Zipcode, PhoneNumber, EmailId);
                contactDetailsList.Add(contactDetails);
                contactDetailsMap[key] = contactDetails;
            
            
        }
        public void ComputeDetails()
        {
            foreach (ContactDetails contact in contactDetailsList)
            {
                Console.WriteLine(contact.toString());
            }
        }
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome To  Addressook");              
            
            Console.WriteLine("How many Contact : ");
            int num = int.Parse(Console.ReadLine());
            for (int i=1; i <= num;i++)
            {
                Program details = new Program();
                int j = 1;
                while (j <= 2)
                {
                    Console.WriteLine("\n 1: To Add a Contact Details");
                    Console.WriteLine("2: To Edit a Contact Details");
                    Console.WriteLine("\n Enter your choice: ");
                    int val = int.Parse(Console.ReadLine());
                    switch (val)
                    {
                        case 1:
                            details.AddDetails();
                            details.ComputeDetails();
                            break;
                        case 2:
                            Console.WriteLine("\n \n Enter a First Name to Edit");
                            string key = Console.ReadLine();
                            details.EditDetails(key);
                            details.ComputeDetails();
                            break;
                        default:
                            Console.WriteLine("\n ***Wrong key***");
                            break;
                    }
                    j++;
                }
            }
             
        }
            
    }
}