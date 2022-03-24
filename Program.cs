using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace AddressBook
{    
    public class Program
    {       
        ArrayList contactDetailsList = new ArrayList();
        Dictionary<string,ArrayList> contactDetailMap = new Dictionary<string, ArrayList>();
        public string FirstName;
        public string LastName;
        public string Address;
        public string City;
        public string State;
        public string Zipcode;
        public string PhoneNumber;
        public string EmailId;
                
        public void information()
        {
            Console.WriteLine("\n Enter Your First name");
           FirstName = Console.ReadLine();
            Console.WriteLine("Enter Your Last name");
            LastName = Console.ReadLine();
            Console.WriteLine("Enter Your Address");
             Address = Console.ReadLine();
            Console.WriteLine("Enter Your City");
             City = Console.ReadLine();
            Console.WriteLine("Enter Your State");
            State = Console.ReadLine();
            Console.WriteLine("Enter Your Zipcode");
            Zipcode =Console.ReadLine();
            Console.WriteLine("Enter Your Phone number");
           PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Your Email Id");
             EmailId = Console.ReadLine();
            foreach (string contact in contactDetailsList)
            {
                Console.WriteLine(contact);
            }
        }
        public void AddDetails()
        {
            contactDetailsList.Add(FirstName);
            contactDetailsList.Add(LastName);
            contactDetailsList.Add(Address);
            contactDetailsList.Add(City);
            contactDetailsList.Add(State);
            contactDetailsList.Add(Zipcode);
            contactDetailsList.Add(PhoneNumber);
            contactDetailsList.Add(EmailId);
            contactDetailMap.Add(FirstName,contactDetailsList);
            foreach (string contact in contactDetailsList)
            {
                Console.WriteLine(contact);
            }
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To  Addressook");                      
            Program details = new Program();
            
            int i = 1;
            int j = 1;
            do
            {
                Console.WriteLine("\n1: Add Contact");
                Console.WriteLine("0. Exit");
                Console.WriteLine("\nEnter your choice: ");
                int val = int.Parse(Console.ReadLine());
                switch (val)
                {
                    case 1:
                        details.information();
                        details.AddDetails();                     
                        i++;
                        j++;
                        break;
                    case 0:
                        Console.WriteLine("***Exit***");
                        i--;
                        j++;
                        break;
                    default:
                        Console.WriteLine("\n ***Wrong key***");
                        break;
                }
            } while (i == j);
        }
    }
}