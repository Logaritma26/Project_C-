using System.Linq;

namespace Project_School
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    internal class Application : Validations
    {
        private readonly List<Contact> _contacts = new();

        public Application()
        {
            var contact1 = new Contact("Andrew", "Smith", "andrew@gmail.com",
                DateTime.ParseExact("01-01-1980", "dd-MM-yyyy", CultureInfo.InvariantCulture), 48725552410);
            var contact2 = new Contact("Lily", "Johnson", "lily@gmail.com",
                DateTime.ParseExact("02-02-1980", "dd-MM-yyyy", CultureInfo.InvariantCulture), 48515552629);
            var contact3 = new Contact("Marcus", "Miller", "marcus@gmail.com",
                DateTime.ParseExact("03-03-1980", "dd-MM-yyyy", CultureInfo.InvariantCulture), 48505559772);
            var contact4 = new Contact("Tom", "Moore", "tommoore@gmail.com",
                DateTime.ParseExact("27-04-1980", "dd-MM-yyyy", CultureInfo.InvariantCulture), 48695554577);
            var contact5 = new Contact("Rupert", "Lee", "ruplee@gmail.com",
                DateTime.ParseExact("05-05-1980", "dd-MM-yyyy", CultureInfo.InvariantCulture), 48735553619);
            var contact6 = new Contact("Ethan", "White", "ewhite@gmail.com",
                DateTime.ParseExact("06-06-1980", "dd-MM-yyyy", CultureInfo.InvariantCulture), 48785554664);

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

            var name = ValidatedString("name");
            if (name == null)
            {
                return;
            }

            var surname = ValidatedString("surname");
            if (surname == null)
            {
                return;
            }

            var email = ValidatedEmail();
            if (email == null)
            {
                return;
            }


            var dateOfBirth = ValidatedBirthDate();
            if (dateOfBirth == null)
            {
                return;
            }

            var telephoneNumber = ValidatedTelephoneNumber();
            if (telephoneNumber == null)
            {
                return;
            }

            var contact = new Contact((string) name, (string) surname, (string) email, (DateTime) dateOfBirth,
                (long) telephoneNumber);

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


        public void PrintAll() => PrintAll(_contacts);

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
            int selection;
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
                Console.WriteLine("Please select proper values !");
                return;
                //throw;
            }

            _contacts.RemoveAt(selection);
        }

        public void SearchContacts()
        {
            int selection;

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
                return;
            }

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
            }
        }

        private void SearchByName()
        {
            Console.WriteLine("Enter the name you want to search for: ");
            string name;
            try
            {
                name = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.Name == name))
            {
                contact.PrintProperties();
            }
        }

        private void SearchBySurname()
        {
            Console.WriteLine("Enter the surname you want to search for: ");
            string surname;

            try
            {
                surname = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.Surname == surname))
            {
                contact.PrintProperties();
            }
        }

        private void SearchByEmail()
        {
            Console.WriteLine("Enter the email you want to search for: ");
            string email;

            try
            {
                email = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.Email == email))
            {
                contact.PrintProperties();
            }
        }

        private void SearchByTelNumber()
        {
            Console.WriteLine("Enter the telephone number you want to search for: ");
            long number;

            try
            {
                number = Convert.ToInt64(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.TelephoneNumber == number))
            {
                contact.PrintProperties();
            }
        }

        private void SearchByBirthDate()
        {
            Console.WriteLine("Enter the birth date as 'dd-MM-yyyy' you want to search for: ");
            DateTime date;

            try
            {
                date = Convert.ToDateTime(DateTime.ParseExact(Console.ReadLine()!, "dd-MM-yyyy",
                    CultureInfo.InvariantCulture));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.DateOfBirth == date))
            {
                contact.PrintProperties();
            }
        }
    }
}