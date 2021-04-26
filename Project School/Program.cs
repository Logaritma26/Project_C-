using System;

namespace Project_School
{
    internal class Program
    {
        private static readonly Application App = new();
        private static bool _isContinue = true;

        static void Main(string[] args)
        {
            Application();
        }

        private static void Application()
        {
            while (_isContinue)
            {
                int selection;

                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Please select the operation you want to perform : ");
                Console.WriteLine();
                Console.WriteLine("1-) Add new contact");
                Console.WriteLine("2-) Print out all contacts");
                Console.WriteLine("3-) Check current week's birth dates");
                Console.WriteLine("4-) Edit contact");
                Console.WriteLine("5-) Delete contact");
                Console.WriteLine("6-) Search contacts");
                Console.WriteLine("7-) Exit program");
                Console.WriteLine();


                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Please use only numbers according to menu !");
                    continue;
                }

                switch (selection)
                {
                    case 1:
                        App.AddContact();
                        break;
                    case 2:
                        App.PrintAll();
                        break;
                    case 3:
                        App.CheckBirthDate();
                        break;
                    case 4:
                        App.EditContact();
                        break;
                    case 5:
                        App.DeleteContact();
                        break;
                    case 6:
                        App.SearchContacts();
                        break;
                    case 7:
                        _isContinue = false;
                        Console.WriteLine("Exiting from system . . .");
                        break;
                    
                    default:
                        Console.WriteLine("Please select only numbers according to menu !");
                        break;
                }
            }
        }
    }
}