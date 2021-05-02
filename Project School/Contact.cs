using System;

namespace Project_School
{
    public class Contact
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public long TelephoneNumber { get; set; }

        public Contact(string name, string surname, string email, DateTime dateOfBirth, long telephoneNumber)
        {
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
            TelephoneNumber = telephoneNumber;
        }


        public void PrintProperties()
        {
            Console.WriteLine(
                $"Name: {Name}, Surname: {Surname}, Email: {Email}, Birth Date: {DateOfBirth:dd/MM/yyyy}, Number: +{TelephoneNumber}");
        }
    }
}