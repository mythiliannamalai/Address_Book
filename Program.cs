using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Program
    {
        private List<ContactDetails> contactDetailsList;
        private Dictionary<string, ContactDetails> contactDetailsMap;
        public string FirstName;
        public string LastName;
        public string Address;
        public string City;
        public string State;
        public string Zipcode;
        public string PhoneNumber;
        public string EmailId;
        public Program()
        {
            contactDetailsList = new List<ContactDetails>();
            contactDetailsMap = new Dictionary<string, ContactDetails>();
        }
        public void AddDetails()
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
                ContactDetails contactDetails = new ContactDetails(FirstName, LastName, Address, City, State, Zipcode, PhoneNumber, EmailId);
                contactDetailsList.Add(contactDetails);
                contactDetailsMap.Add(FirstName, contactDetails);
                foreach (var contact in contactDetailsMap)
                {
                    Console.WriteLine(contact.Value.toString());
                }            
        }
        public void ComputeDetails()
        {
            foreach (var contact in contactDetailsMap)
            {
                Console.WriteLine(contact.Value.toString());
            }
        }
        public void EditDetails()
        {
            Console.WriteLine("\nEnter the first name :");
            string key = Console.ReadLine();
            if (contactDetailsMap.ContainsKey(key))
            {
                Console.WriteLine("\n1.Edit First Name");
                Console.WriteLine("2.Edit Last Name");
                Console.WriteLine("3.Edit Address");
                Console.WriteLine("4.Edit City");
                Console.WriteLine("5.Edit State");
                Console.WriteLine("6.Edit zipcode");
                Console.WriteLine("7.Edit phone number");
                Console.WriteLine("8.Edit Email id");
                Console.WriteLine("Enter your choice :");
                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Console.WriteLine("Change First name");
                        string fn = Console.ReadLine();                        
                        break;
                    case 2:
                        Console.WriteLine("Change Laste name");
                        string ln = Console.ReadLine();                        
                        break;
                    case 3:
                        Console.WriteLine("Change Address");
                        string add = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Change City");
                        string ct = Console.ReadLine();                        
                        break;
                    case 5:
                        Console.WriteLine("Change State");
                        string st = Console.ReadLine();                        
                        break;
                    case 6:
                        Console.WriteLine("Change zip code");
                        string zc = Console.ReadLine();                        
                        break;
                    case 7:
                        Console.WriteLine("Change phone number");
                        string ph = Console.ReadLine();                        
                        break;
                    case 8:
                        Console.WriteLine("Change Email id");
                        string eid = Console.ReadLine();                        
                        break;
                }
                ContactDetails contactDetails = new ContactDetails(FirstName, LastName, Address, City, State, Zipcode, PhoneNumber, EmailId);
                contactDetailsList.Add(contactDetails);
                contactDetailsMap[key]=contactDetails;               
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
            contactDetailsMap.Remove(FirstName);            
        }
        public void SearchPerson()
        {
            Console.WriteLine("Enter the city name :");
            string City = Console.ReadLine();
            var list = contactDetailsList.FindAll(x => x.City == City);
            var res = list;
            foreach (var result in res)
            {
                Console.WriteLine(result.toString());
            }
        }
        public void PersonCount()
        {
            Console.WriteLine("Person count based on state and city :");
            Console.WriteLine("Enter City");
            string City = Console.ReadLine();
            Console.WriteLine("Enter state");
            string State = Console.ReadLine();
            var lists = contactDetailsList.FindAll(x => (x.City == City && x.State == State));
            var res = lists;
            foreach (var count in res)
            {
                Console.WriteLine(count.toString());
            }
            
            var result = lists.Count;
            Console.WriteLine($"Total Persons in {City} & {State}:" + result);
        }
        public void SortAssendingOrder()
        {
            var sortList = contactDetailsMap.OrderBy(x => x.Value.FirstName).ToList();
            foreach (var item in sortList)
            {
                Console.WriteLine(item.Value.toString());
            }
        }
        public void Sorting_City_state_zipcode()
        {            
            Console.WriteLine("1: Sort by City");
            Console.WriteLine("2: Sort by State");
            Console.WriteLine("3: Sort by Zip");
            Console.WriteLine("Enter your option :");
            int a = int.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:                    
                    var sortingCity = contactDetailsMap.OrderBy(x => x.Value.City).ToList();
                    foreach (var item in sortingCity)
                    {
                        Console.WriteLine(item.Value.toString());
                    }
                    break;
                case 2:
                    var sortingState = contactDetailsMap.OrderBy(x => x.Value.State).ToList();
                    foreach (var item in sortingState)
                    {
                        Console.WriteLine(item.Value.toString());
                    }
                    break;
                case 3:
                    var sortingZip = contactDetailsMap.OrderBy(x => x.Value.Zipcode).ToList();
                    foreach (var item in sortingZip)
                    {
                        Console.WriteLine(item.Value.toString());
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input....");
                    break;
            }
        }
        public void IoFile()
        {
            string filepath = @"C:\Users\user\source\repos\ConsoleApp2\Iofile.txt";            
            using (StreamWriter streamWriter = File.AppendText(filepath))
            {                
                foreach (var con in contactDetailsMap)
                {
                    streamWriter.WriteLine(con.Value.toString());
                }
                streamWriter.Close();
            }
            var val=File.ReadAllText(filepath);
            Console.WriteLine(val);
        }
    
        public void FinalOut()
        {
            Program program=new Program();
            int val;
            do
            {
                Console.WriteLine("\n1: Add Contact");
                Console.WriteLine("2: Edit Contact");
                Console.WriteLine("3. Delet");
                Console.WriteLine("4.Contact Details");
                Console.WriteLine("5.search");
                Console.WriteLine("6.count person");
                Console.WriteLine("7.Sorting list");
                Console.WriteLine("8.Sorting based on state ,city,and zipcode");
                Console.WriteLine("9.Io file");
                Console.WriteLine("0.Exit");
                Console.WriteLine("\nEnter your choice: ");
                val = int.Parse(Console.ReadLine());
                switch (val)
                {
                    case 1:
                        program.AddDetails();                        
                        break;
                        case 2:
                        program.EditDetails();                        
                        break ;
                        case 3:
                        program.DeleteContact();
                        program.ComputeDetails() ;
                        break ;
                    case 4:
                        program.ComputeDetails();
                        break;
                    case 5:
                        program.SearchPerson();
                        break;
                    case 6:
                        program.PersonCount();
                        break;
                    case 7:
                        program.SortAssendingOrder();
                        break;
                    case 8:
                        program.Sorting_City_state_zipcode();
                        break;
                    case 9:
                        program.IoFile();
                        break;
                    case 0:
                        Console.WriteLine("***Exit***");
                        break;
                    default:
                        Console.WriteLine("\n ***Wrong key***");
                        break;
                }
            }while(val!=0);
        }
        static void Main(string[]args)
        {
            Console.WriteLine("Welcome To  Addressook");
            Program program = new Program();
            int CH;
            do
            {
                Console.WriteLine("\n1.Office contact");
                Console.WriteLine("2.Personal contact");
                Console.WriteLine("0.Exit");
                Console.WriteLine("choes your Address Book : ");
                CH = int.Parse(Console.ReadLine());
                switch (CH)
                {
                    case 1:
                        program.FinalOut();

                        break;
                    case 2:
                        program.FinalOut();

                        break;
                    case 0:
                        Console.WriteLine("****EXIT****");

                        break;
                }
            } while (CH != 0);
        }
    }
}


