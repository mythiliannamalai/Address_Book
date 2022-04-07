using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace AddressBook
{
    public class Program
    {      
        ArrayList contactDetailsList = new ArrayList();
        Dictionary<string, ArrayList> contactDetailMap = new Dictionary<string, ArrayList>();
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
            Zipcode = Console.ReadLine();
            Console.WriteLine("Enter Your Phone number");
            PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Your Email Id");
            EmailId = Console.ReadLine();
        }
        public void AddDetails()
        {
            bool MethodName(string FirstName) => contactDetailsList.Contains(FirstName);
            bool result = MethodName(FirstName);
            if (result == true)
            {
                Console.WriteLine("This name is already in contact");
            }
            else
            {
                contactDetailsList.Add(FirstName);
                contactDetailsList.Add(LastName);
                contactDetailsList.Add(Address);
                contactDetailsList.Add(City);
                contactDetailsList.Add(State);
                contactDetailsList.Add(Zipcode);
                contactDetailsList.Add(PhoneNumber);
                contactDetailsList.Add(EmailId);
                contactDetailMap.Add(FirstName, contactDetailsList);
            }
        }
        public void EditDetails()
        {
            Console.WriteLine("Enter the first name :");
            string y = Console.ReadLine();
            if (y == FirstName)
            {
                Console.WriteLine("1.Edit First Name");
                Console.WriteLine("2.Edit Last Name");
                Console.WriteLine("3.Edit Address");
                Console.WriteLine("4.Edit City");
                Console.WriteLine("5.Edit State");
                Console.WriteLine("6.Edit zipcode");
                Console.WriteLine("7.Edit phone number");
                Console.WriteLine("8.Edit Email id");
                Console.WriteLine("Enter your choice :");
                int a= int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Console.WriteLine("Change First name");
                        string fn = Console.ReadLine();
                        contactDetailsList[0] = fn;
                        break;
                    case 2:
                        Console.WriteLine("Change Laste name");
                        string ln = Console.ReadLine();
                        contactDetailsList[1] = ln;
                        break;
                    case 3:
                        Console.WriteLine("Change Address");
                        string add = Console.ReadLine();
                        contactDetailsList[2] = add;
                        break;
                    case 4:
                        Console.WriteLine("Change City");
                        string ct = Console.ReadLine();
                        contactDetailsList[3] = ct;
                        break;
                    case 5:
                        Console.WriteLine("Change State");
                        string st = Console.ReadLine();
                        contactDetailsList[4] = st;
                        break;
                    case 6:
                        Console.WriteLine("Change zip code");
                        string zc = Console.ReadLine();
                        contactDetailsList[5] = zc;
                        break;
                    case 7:
                        Console.WriteLine("Change phone number");
                        string ph = Console.ReadLine();
                        contactDetailsList[6] = ph;
                        break;
                    case 8:
                        Console.WriteLine("Change Email id");
                        string eid = Console.ReadLine();
                        contactDetailsList[7] = eid;
                        break;
                }
            }
            else
            {
                Console.WriteLine("the name is not founded");
            }
        }
        public void DeleteContact()
        {
            Console.WriteLine("\nEnter The First name to Delete Contact ");
            string FirstName = Console.ReadLine();
            contactDetailsList.RemoveRange(0, contactDetailsList.Count);
            contactDetailMap.Remove(FirstName);
        }
        public void AllContact()
        {
            foreach (string contact in contactDetailsList)
            {
                Console.WriteLine(contact);
            }
        }
        public void FinalOut()
        {          
            Program details = new Program();
            int i = 1;
            int j = 1;
            do
            {
                Console.WriteLine("\n1: Add Contact");
                Console.WriteLine("2: Edit Contact");
                Console.WriteLine("3. Delet");
                Console.WriteLine("4.Contact Details");
                Console.WriteLine("0. Exit");
                Console.WriteLine("\nEnter your choice: ");
                int val = int.Parse(Console.ReadLine());
                switch (val)
                {
                    case 1:
                            details.information();
                            details.AddDetails();
                        Console.WriteLine("\n");
                            details.AllContact();
                        i++; j++;
                        break;
                    case 2:
                            details.EditDetails();
                        Console.WriteLine("\n");
                        details.AllContact();
                             i++; j++;
                        break;
                    case 3:
                            details.DeleteContact();
                            details.AllContact();
                             i++; j++;
                        break;
                    case 4:
                            Console.WriteLine("\n View to all contacte ");
                        Console.WriteLine("\n");
                        details.AllContact();
                             i++; j++;
                        break;
                    case 0:
                        Console.WriteLine("***Exit***");
                        i--; j++;
                        break;
                    default:
                        Console.WriteLine("\n ***Wrong key***");

                        break;
                }
            } while (i == j);
        }      
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To  Addressook");
            Program program = new Program();
            int a = 1;
            int b = 1;
            do
            {
                Console.WriteLine("\n1.Office contact");
                Console.WriteLine("2.Personal contact");
                Console.WriteLine("0.Exit");
                Console.WriteLine("choes your Address Book : ");
                var CH = int.Parse(Console.ReadLine());                     
                switch (CH)
                {
                    case 1:
                        program.FinalOut();
                        a++;b++;
                        break;
                    case 2:
                        program.FinalOut();
                        a++; b++;
                        break;
                    case 0:
                        Console.WriteLine("****EXIT****");
                        a++; b--;
                        break;
                }
            }while(a == b);
        }
               
    }
}


