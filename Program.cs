using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
namespace AddressBook
{
    public class Program
    {
        private List<ContactDetails> contactDetailsList;
        private Dictionary<string, ContactDetails> contactDetailsMap;
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Address_Book_Service; Integrated Security=SSPI;";
        static SqlConnection connection = new SqlConnection(connectionString);
        public Program()
        {
            contactDetailsList = new List<ContactDetails>();
            contactDetailsMap = new Dictionary<string, ContactDetails>();
        }
        //UC-1 && UC-2 create contact and Add contact
        //UC-5 create multiple address book
        //UC-20 Add contact in Database
        public void AddDetails()
        {
            List<ContactDetails> contacts = new List<ContactDetails>();
            ContactDetails contactDetails = new ContactDetails();
            Console.WriteLine("First Name :");
            contactDetails.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name :");
            contactDetails.LastName = Console.ReadLine();
            Console.WriteLine("Address :");
            contactDetails.Address = Console.ReadLine();
            Console.WriteLine("City :");
            contactDetails.City = Console.ReadLine();
            Console.WriteLine("State :");
            contactDetails.State = Console.ReadLine();
            Console.WriteLine("Zip code :");
            contactDetails.Zipcode = Console.ReadLine();
            Console.WriteLine("Phone Number :");
            contactDetails.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Email Id :");
            contactDetails.EmailId = Console.ReadLine();
            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.Add_Contacte";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName", contactDetails.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", contactDetails.LastName);
                sqlCommand.Parameters.AddWithValue("@Address", contactDetails.Address);
                sqlCommand.Parameters.AddWithValue("@City", contactDetails.City);
                sqlCommand.Parameters.AddWithValue("@State", contactDetails.State);
                sqlCommand.Parameters.AddWithValue("@Zipcode", contactDetails.Zipcode);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", contactDetails.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@EmailId", contactDetails.EmailId);
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Console.WriteLine(contactDetails.FirstName + "," + contactDetails.LastName + "," + contactDetails.Address + ","
                    + contactDetails.City + "," + contactDetails.State + "," + contactDetails.Zipcode, ","
                    + contactDetails.PhoneNumber + "," + contactDetails.EmailId);
                contacts.Add(contactDetails);
                connection.Close();
            }
        }
        //UC-3 Edit contact
        //UC-17 Edit contact in Database
        public void EditDetails()
        {
                List<ContactDetails> contactDetailsList = new List<ContactDetails>();
                ContactDetails contactDetails = new ContactDetails();

                SqlConnection connection = new SqlConnection(connectionString);
                string spname = "dbo.Edit_Contact";
                using (connection)
                {
                    SqlCommand sqlCommand = new SqlCommand(spname, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    Console.WriteLine("Edit Contact");
                    Console.WriteLine("--------------");
                    Console.WriteLine("First Name :");
                    contactDetails.FirstName = Console.ReadLine();
                    sqlCommand.Parameters.AddWithValue("@FirstName", contactDetails.FirstName);
                    Console.WriteLine("Last Name :");
                    contactDetails.LastName = Console.ReadLine();
                    sqlCommand.Parameters.AddWithValue("@LastName", contactDetails.LastName);
                    Console.WriteLine("Address :");
                    contactDetails.Address = Console.ReadLine();
                    sqlCommand.Parameters.AddWithValue("@Address", contactDetails.Address);
                    Console.WriteLine("City :");
                    contactDetails.City = Console.ReadLine();
                    sqlCommand.Parameters.AddWithValue("@City", contactDetails.City);
                    Console.WriteLine("State :");
                    contactDetails.State = Console.ReadLine();
                    sqlCommand.Parameters.AddWithValue("@State", contactDetails.State);
                    Console.WriteLine("Zip code :");
                    contactDetails.Zipcode = Console.ReadLine();
                    sqlCommand.Parameters.AddWithValue("@Zipcode", contactDetails.Zipcode);
                    Console.WriteLine("Phone Number :");
                    contactDetails.PhoneNumber = Console.ReadLine();
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", contactDetails.PhoneNumber);
                    Console.WriteLine("Email Id :");
                    contactDetails.EmailId = Console.ReadLine();
                    sqlCommand.Parameters.AddWithValue("@EmailId", contactDetails.EmailId);
                    connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                contactDetails.FirstName = (string)reader["FirstName"];
                                contactDetails.LastName = (string)reader["LastName"];
                                contactDetails.Address = (string)reader["Address"];
                                contactDetails.City = (string)reader["City"];
                                contactDetails.State = (string)reader["State"];
                                contactDetails.Zipcode = (string)reader["Zipcode"];
                                contactDetails.PhoneNumber = (string)reader["PhoneNumber"];
                                contactDetails.EmailId = (string)reader["EmailId"];
                                contactDetailsList.Add(contactDetails);                                
                                Console.WriteLine(contactDetails.FirstName + "," + contactDetails.LastName + "," + contactDetails.Address + ","
                                    + contactDetails.City + "," + contactDetails.State + "," + contactDetails.Zipcode, ","
                                   + contactDetails.PhoneNumber + "," + contactDetails.EmailId);
                            }
                            connection.Close();
                        }
                    }
                }
            
        }
        //UC-4 Delete contact
        public void DeleteContact()
        {
            List<ContactDetails> contacts = new List<ContactDetails>();
            ContactDetails contactDetails = new ContactDetails();

            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.Delete_Contact";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.WriteLine("Delete Contact");
                Console.WriteLine("--------------");
                Console.WriteLine("First Name :");
                contactDetails.FirstName = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@FirstName", contactDetails.FirstName);
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            contactDetails.FirstName = (string)reader["FirstName"];
                            contactDetails.LastName = (string)reader["LastName"];
                            contactDetails.Address = (string)reader["Address"];
                            contactDetails.City = (string)reader["City"];
                            contactDetails.State = (string)reader["State"];
                            contactDetails.Zipcode = (string)reader["Zipcode"];
                            contactDetails.PhoneNumber = (string)reader["PhoneNumber"];
                            contactDetails.EmailId = (string)reader["EmailId"];
                            contacts.Add(contactDetails);
                            Console.WriteLine(contactDetails.FirstName + "," + contactDetails.LastName + "," + contactDetails.Address + ","
                                + contactDetails.City + "," + contactDetails.State + "," + contactDetails.Zipcode, ","
                               + contactDetails.PhoneNumber + "," + contactDetails.EmailId);
                        }
                        connection.Close();
                    }
                }
            }
        }        
        //UC-8 && 9 Persons by City or State
        public void PersonCount()
        {
            List<ContactDetails> contacts = new List<ContactDetails>();
            ContactDetails contactDetails = new ContactDetails();
            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.GetDataIn_alphabeticalOrder";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.WriteLine("Retrive Contact based on city");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Enter City :");
                contactDetails.City = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@City", contactDetails.City);
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            contactDetails.FirstName = (string)reader["FirstName"];
                            contactDetails.LastName = (string)reader["LastName"];
                            contactDetails.Address = (string)reader["Address"];
                            contactDetails.City = (string)reader["City"];
                            contactDetails.State = (string)reader["State"];
                            contactDetails.Zipcode = (string)reader["Zipcode"];
                            contactDetails.PhoneNumber = (string)reader["PhoneNumber"];
                            contactDetails.EmailId = (string)reader["EmailId"];
                            contacts.Add(contactDetails);
                            Console.WriteLine(contactDetails.FirstName + "," + contactDetails.LastName + "," + contactDetails.Address + ","
                                + contactDetails.City + "," + contactDetails.State + "," + contactDetails.Zipcode, ","
                               + contactDetails.PhoneNumber + "," + contactDetails.EmailId);
                        }
                        connection.Close();
                    }
                }
            }
        }
        //UC-10 sort the entries in the address book alphabetically by Person’s name
        public void SortAssendingOrder()
        {
            List<ContactDetails> contacts = new List<ContactDetails>();
            ContactDetails contactDetails = new ContactDetails();

            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.GetDataIn_alphabeticalOrder";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.WriteLine("Retrive Contact based on city ot state by Alphabetical order");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Enter City :");
                contactDetails.City = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@City", contactDetails.City);
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            contactDetails.FirstName = (string)reader["FirstName"];
                            contactDetails.LastName = (string)reader["LastName"];
                            contactDetails.Address = (string)reader["Address"];
                            contactDetails.City = (string)reader["City"];
                            contactDetails.State = (string)reader["State"];
                            contactDetails.Zipcode = (string)reader["Zipcode"];
                            contactDetails.PhoneNumber = (string)reader["PhoneNumber"];
                            contactDetails.EmailId = (string)reader["EmailId"];
                            contacts.Add(contactDetails);
                            Console.WriteLine(contactDetails.FirstName + "," + contactDetails.LastName + "," + contactDetails.Address + ","
                                + contactDetails.City + "," + contactDetails.State + "," + contactDetails.Zipcode, ","
                               + contactDetails.PhoneNumber + "," + contactDetails.EmailId);
                        }
                        connection.Close();
                    }
                }
            }
        }
        // UC-11 && 12 number of contact persons count by City or State
        public void Sorting_City_state_zipcode()
        {
            List<ContactDetails> contacts = new List<ContactDetails>();
            ContactDetails contactDetails = new ContactDetails();            
                SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.GetDataIn_alphabeticalOrder";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.WriteLine("1: Sort by City");
                Console.WriteLine("2: Sort by State");
                Console.WriteLine("3: Sort by Zip");
                Console.WriteLine("Enter your option :");
                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Console.WriteLine("Retrive Contact based on city");
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("Enter City :");
                        contactDetails.City = Console.ReadLine();
                        sqlCommand.Parameters.AddWithValue("@City", contactDetails.City);
                        break;
                    case 2:
                        Console.WriteLine("Retrive Contact based on state");
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("Enter State :");
                        contactDetails.City = Console.ReadLine();
                        sqlCommand.Parameters.AddWithValue("@State", contactDetails.State);
                        break;
                    case 3:
                        Console.WriteLine("Retrive Contact based on Zipcode");
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("Enter City :");
                        contactDetails.City = Console.ReadLine();
                        sqlCommand.Parameters.AddWithValue("@Zipcode", contactDetails.Zipcode);
                        break;
                    default:
                        Console.WriteLine("Invalid input....");
                        break;
                }
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            contactDetails.FirstName = (string)reader["FirstName"];
                            contactDetails.LastName = (string)reader["LastName"];
                            contactDetails.Address = (string)reader["Address"];
                            contactDetails.City = (string)reader["City"];
                            contactDetails.State = (string)reader["State"];
                            contactDetails.Zipcode = (string)reader["Zipcode"];
                            contactDetails.PhoneNumber = (string)reader["PhoneNumber"];
                            contactDetails.EmailId = (string)reader["EmailId"];
                            contacts.Add(contactDetails);
                            Console.WriteLine(contactDetails.FirstName + "," + contactDetails.LastName + "," + contactDetails.Address + ","
                                + contactDetails.City + "," + contactDetails.State + "," + contactDetails.Zipcode, ","
                               + contactDetails.PhoneNumber + "," + contactDetails.EmailId);
                        }
                        connection.Close();
                    }
                }
            }
        }
        //UC-13 IO file
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
        //UC -14 CSV File
        public void CsvFile()
        {
            string path = @"C:\Users\user\source\repos\ConsoleApp2\CSVAddressBook.csv";            
            using (var writer = new StreamWriter(path))
            using (var csvwriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvwriter.WriteHeader<ContactDetails>();
                foreach (var contsct in contactDetailsList)
                {
                    csvwriter.NextRecord();
                    csvwriter.WriteRecord(contsct);
                }
            }
            using (TextReader reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<ContactDetails>().ToList();
                foreach (ContactDetails contacts in records)
                {
                    Console.WriteLine(contacts.toString());
                }
            }
        }
        //UC-15 Json file
        public void JsonFile()
        {

            string jsonpath = @"C:\Users\user\source\repos\ConsoleApp2\ConsoleApp2\AddressBook.json";
            string jsonData =JsonConvert.SerializeObject(contactDetailsList);
            using (StreamWriter writer = File.CreateText(jsonpath))
            {
                writer.Flush();
                writer.Write(jsonData);
                Console.WriteLine(jsonData);
            }
            string result=File.ReadAllText(jsonpath);

            List<ContactDetails> contactDetails=JsonConvert.DeserializeObject<List<ContactDetails>>(result);
        }
        //UC-16 Retrive data 
        public static List<ContactDetails> RetriveData()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Address_Book_Service; Integrated Security=SSPI;";
            SqlConnection connection = new SqlConnection(connectionString);
            List<ContactDetails> employees = new List<ContactDetails>();
            ContactDetails contactDetails = new ContactDetails();
            string spname = "dbo.GetAllDataFromSQL";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        contactDetails.FirstName = reader.GetString(0);
                        contactDetails.LastName = reader.GetString(1);
                        contactDetails.Address = reader.GetString(2);
                        contactDetails.City = reader.GetString(3);
                        contactDetails.State = reader.GetString(4);
                        contactDetails.Zipcode = reader.GetString(5);
                        contactDetails.PhoneNumber = reader.GetString(6);
                        contactDetails.EmailId = reader.GetString(7);
                        
                        employees.Add(contactDetails);
                        Console.WriteLine(contactDetails.FirstName + "," + contactDetails.LastName + "," + contactDetails.Address + 
                            "," + contactDetails.City + "," + contactDetails.State + "," + contactDetails.Zipcode + "," +
                            contactDetails.PhoneNumber + "," + contactDetails.EmailId);
                    }
                    connection.Close();
                }
                return employees;
            }
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
                Console.WriteLine("10.CSV file");
                Console.WriteLine("11.Json file");
                Console.WriteLine("12.Retrive sql data");
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
                        break ;
                    case 4:
                        RetriveData();
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
                    case 10:
                        program.CsvFile();
                        break;
                    case 11:
                        program.JsonFile();
                        break;
                    case 12:
                        RetriveData();
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


