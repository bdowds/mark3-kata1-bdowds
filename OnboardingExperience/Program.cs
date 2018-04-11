using System;
using System.Linq;

namespace OnboardingExperience
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to 'Banking App'!");

            var newUser = new User();
            var isConfirmed = false;

            do
            {
                Console.WriteLine("\nPlease enter your first name:");
                newUser.FirstName = Console.ReadLine();

                Console.WriteLine($"Confirm first name: {newUser.FirstName} ? (y/n)");

                isConfirmed = ConfirmData(Console.ReadLine());
            } while (!isConfirmed);

            do
            {
                Console.WriteLine("\nPlease enter your last name:");
                newUser.LastName = Console.ReadLine();

                Console.WriteLine($"Confirm last name: {newUser.LastName} ? (y/n)");

                isConfirmed = ConfirmData(Console.ReadLine());
            } while (!isConfirmed);


            do
            {
                Console.WriteLine("\nPlease enter a 4-digit pin:");
                newUser.Pin = int.Parse(Console.ReadLine());

                Console.WriteLine($"Confirm Pin: {newUser.Pin} ? (y/n)");

                isConfirmed = ConfirmData(Console.ReadLine());
            } while (!isConfirmed);
        }

        private static bool ConfirmData(string a)
        {
            if (a.ToLower() == "y")
            {
                return true;
            }
            else if (a.ToLower() == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Please enter either a 'y' for Yes, or a 'n' for No.");
                return false;
            }
        }
    }
}
