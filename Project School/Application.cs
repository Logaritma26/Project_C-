using System.Linq;

namespace Project_School
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    internal class Application
    {
        private readonly List<Contact> _contacts = new();

        public Application()
        {
            var contact1 = new Contact("person1", "person1", "person1",
                DateTime.ParseExact("01-01-1980", "dd-MM-yyyy", CultureInfo.InvariantCulture), 111);
            var contact2 = new Contact("person2", "person2", "person2",
                DateTime.ParseExact("02-02-1980", "dd-MM-yyyy", CultureInfo.InvariantCulture), 222);
            var contact3 = new Contact("person3", "person3", "person3",
                DateTime.ParseExact("03-03-1980", "dd-MM-yyyy", CultureInfo.InvariantCulture), 333);
            var contact4 = new Contact("person4", "person4", "person4",
                DateTime.ParseExact("27-04-1980", "dd-MM-yyyy", CultureInfo.InvariantCulture), 444);
            var contact5 = new Contact("person5", "person5", "person5",
                DateTime.ParseExact("05-05-1980", "dd-MM-yyyy", CultureInfo.InvariantCulture), 555);
            var contact6 = new Contact("person6", "person6", "person6",
                DateTime.ParseExact("06-06-1980", "dd-MM-yyyy", CultureInfo.InvariantCulture), 666);

            _contacts.Add(contact1);
            _contacts.Add(contact2);
            _contacts.Add(contact3);
            _contacts.Add(contact4);
            _contacts.Add(contact5);
            _contacts.Add(contact6);
        }

        public void AddContact(int index = -1)
        {
            if (index == -1)
            {
                Console.WriteLine("Adding new contact . . . ");
            }
            
            Console.WriteLine("Enter contact name : ");
            var name = Console.ReadLine();

            Console.WriteLine("Enter contact surname : ");
            var surname = Console.ReadLine();

            Console.WriteLine("Enter contact email : ");
            var email = Console.ReadLine();

            Console.WriteLine("Enter contact birth date as dd-MM-yyyy : ");
            var dateOfBirth =
                Convert.ToDateTime(DateTime.ParseExact(Console.ReadLine()!, "dd-MM-yyyy",
                    CultureInfo.InvariantCulture));

            Console.WriteLine("Enter contact telephone number : ");
            var telephoneNumber = Convert.ToInt64(Console.ReadLine());

            var contact = new Contact(name, surname, email, dateOfBirth, telephoneNumber);

            if (index == -1)
            {
                _contacts.Add(contact);
                Console.WriteLine("Contact added successfully !");
            }
            else
            {
                _contacts[index] = contact;
                Console.WriteLine("Contact edited successfully !");
            }
        }

        public void PrintAll()
        {
            Console.WriteLine("Printing contacts . . . ");
            for (var i = 0; i < _contacts.Count; i++)
            {
                Console.Write($"{i + 1}-)");
                _contacts[i].PrintProperties();
            }
        }

        public void CheckBirthDate()
        {
            foreach (var contact in _contacts)
            {
                if (DateInside(contact.DateOfBirth))
                {
                    contact.PrintProperties();
                }
            }
        }

        private static bool DateInside(DateTime contactDate)
        {
            var startDateOfWeek = DateTime.Now.Date;
            var missingYears = startDateOfWeek.Year - contactDate.Year;
            var checkDate = contactDate.AddYears(missingYears);

            while (startDateOfWeek.DayOfWeek != DayOfWeek.Monday)
            {
                startDateOfWeek = startDateOfWeek.AddDays(-1d);
            }

            var toDate = startDateOfWeek.AddDays(6d);

            return checkDate >= startDateOfWeek && checkDate <= toDate;
        }

        public void EditContact()
        {
            var selection = -1;
            var hasError = false;
            PrintAll();
            Console.Write("Please select the contact you want to edit :");
            try
            {
                selection = Convert.ToInt32(Console.ReadLine()) - 1;
                if (selection >= _contacts.Count && selection != -1)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                hasError = true;
                //throw;
            }

            if (!hasError)
            {
                AddContact(selection);
            }
        }
        
        public void DeleteContact()
        {
            var selection = -1;
            var hasError = false;
            PrintAll();
            Console.Write("Please select the contact you want to delete :");
            try
            {
                selection = Convert.ToInt32(Console.ReadLine()) - 1;
                if (selection >= _contacts.Count || selection < 0)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                hasError = true;
                //throw;
            }

            if (hasError) return;
            _contacts.RemoveAt(selection);
        }

        
        public void SearchContacts()
        {
            var selection = -1;
            var hasError = false;

            Console.WriteLine();
            Console.WriteLine("1-) Search by Name");
            Console.WriteLine("2-) Search by Surname");
            Console.WriteLine("3-) Search by Email");
            Console.WriteLine("4-) Search by Birth Date");
            Console.WriteLine("5-) Search by Telephone Number");
            Console.WriteLine();
            
            try
            {
                selection = Convert.ToInt32(Console.ReadLine());
                if (selection >= 6 || selection <= 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please use only numbers according to menu !");
                hasError = true;
            }

            if (hasError) return;
            switch (selection)
            {
                case 1:
                    SearchByName();
                    break;
                case 2:
                    SearchBySurname();
                    break;
                case 3:
                    SearchByEmail();
                    break;
                case 4:
                    SearchByBirthDate();
                    break;
                case 5:
                    SearchByTelNumber();
                    break;
                default:
                    Console.WriteLine("Please select only numbers according to menu !");
                    break;
            }

        }

        private void SearchByName()
        {
            Console.WriteLine("Enter the name you want to search for: ");
            var name = Console.ReadLine();

            foreach (var contact in _contacts.Where(contact => contact.Name == name))
            {
                contact.PrintProperties();
            }
        }
        private void SearchBySurname()
        {
            Console.WriteLine("Enter the surname you want to search for: ");
            var surname = Console.ReadLine();

            foreach (var contact in _contacts.Where(contact => contact.Surname == surname))
            {
                contact.PrintProperties();
            }
        }
        private void SearchByEmail()
        {
            Console.WriteLine("Enter the email you want to search for: ");
            var email = Console.ReadLine();

            foreach (var contact in _contacts.Where(contact => contact.Email == email))
            {
                contact.PrintProperties();
            }
        }
        private void SearchByTelNumber()
        {
            Console.WriteLine("Enter the telephone number you want to search for: ");
            var number = Convert.ToInt64(Console.ReadLine());

            foreach (var contact in _contacts.Where(contact => contact.TelephoneNumber == number))
            {
                contact.PrintProperties();
            }
        }
        private void SearchByBirthDate()
        {
            Console.WriteLine("Enter the birth date as 'dd-MM-yyyy' you want to search for: ");
            var date = Convert.ToDateTime(DateTime.ParseExact(Console.ReadLine()!, "dd-MM-yyyy",
                CultureInfo.InvariantCulture));

            foreach (var contact in _contacts.Where(contact => contact.DateOfBirth == date))
            {
                contact.PrintProperties();
            }
        }
        
    }
}