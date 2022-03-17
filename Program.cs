namespace Address_book
{
    class Contact
    {
        public string Laste_name;
        public string First_name;
        public string Address;
        public string Cite;
        public string State;
        public string Phone_number;
        public string Zip;
        public string Email;
        public void display()
        {
            Console.WriteLine("Welcome to Address Book");
            Console.WriteLine("Enter the Last Name : ");
            Laste_name = (Console.ReadLine());
            Console.WriteLine("Enter the First Name : ");
            First_name = (Console.ReadLine());
            Console.WriteLine("Enter the Address :");
            Address = (Console.ReadLine());
            Console.WriteLine("Enter city : ");
            Cite = (Console.ReadLine());
            Console.WriteLine("Enter State : ");
            State = (Console.ReadLine());
            Console.WriteLine("Enter the mobile number : ");
            Phone_number = (Console.ReadLine());
            Console.WriteLine("Enter the Zip Code : ");
            Zip = (Console.ReadLine());
            Console.WriteLine("Enter the email id : ");
            Email = (Console.ReadLine());
        }
        static void Main(string[] args)
        {
            Contact contact = new Contact();
            contact.display();
        }
    }
}
    






