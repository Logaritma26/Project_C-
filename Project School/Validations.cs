using System;
using System.Collections.Generic;
using System.Globalization;

namespace Project_School
{
    public abstract class Validations
    {
        protected static void PrintAll(List<Contact> contacts)
        {
            Console.WriteLine("Printing contacts . . . ");
            for (var i = 0; i < contacts.Count; i++)
            {
                Console.Write($"{i + 1}-)");
                contacts[i].PrintProperties();
            }
        }

        protected static object ValidatedBirthDate()
        {
            var test = 3;
            while (test > 0)
            {
                Console.WriteLine("Enter contact birth date as dd-MM-yyyy : ");
                try
                {
                    var dateOfBirth = Convert.ToDateTime(DateTime.ParseExact(Console.ReadLine()!, "dd-MM-yyyy",
                        CultureInfo.InvariantCulture));
                    return dateOfBirth;
                }
                catch (Exception e)
                {
                    test--;
                    if (test != 0)
                    {
                        Console.WriteLine("Please enter proper values according to order dd-MM-yyyy !");
                    }
                }
            }

            Console.WriteLine("A lot of amiss operation made !");
            return null;
        }

        protected static object ValidatedTelephoneNumber()
        {
            var test = 3;
            while (test > 0)
            {
                Console.WriteLine("Enter contact telephone number : ");
                try
                {
                    var tempNum = Console.ReadLine();
                    var telephoneNumber = long.Parse(Equals("+", tempNum[0]) ? tempNum.Remove(0, 1) : tempNum);
                    return telephoneNumber;
                }
                catch (Exception e)
                {
                    test--;
                    if (test != 0)
                    {
                        Console.WriteLine("Please enter proper values, eg: +48123456789");
                    }
                }
            }

            Console.WriteLine("A lot of amiss operation made !");
            return null;
        }
        
        protected static object ValidatedEmail()
        {
            var test = 3;
            while (test > 0)
            {
                Console.WriteLine("Enter contact email : ");
                var email = Console.ReadLine();
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    if (addr.Address == email)
                    {
                        return email;
                    }
                }
                catch
                {
                    test--;
                    if (test != 0)
                    {
                        Console.WriteLine("Please enter proper values, eg: somename@abcmail.com");
                    }
                }
            }

            Console.WriteLine("A lot of amiss operation made !");
            return null;
        }
        
        protected static object ValidatedString(string title)
        {
            var test = 3;
            while (test > 0)
            {
                Console.WriteLine($"Enter contact {title} : ");
                var field = Console.ReadLine();
                try
                {
                    if (!string.IsNullOrEmpty(field))
                    {
                        return field;
                    }
                    throw new Exception();
                }
                catch
                {
                    test--;
                    if (test != 0)
                    {
                        Console.WriteLine("Please enter proper values, eg: Mary, ethan, Julia . . .");
                    }
                }
            }

            Console.WriteLine("A lot of amiss operation made !");
            return null;
        }
    }
}