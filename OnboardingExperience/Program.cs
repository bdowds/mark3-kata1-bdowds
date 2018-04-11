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
            var yesOrNo = "y";

            do
            {
                Console.WriteLine("\nPlease enter your first name:");
                newUser.FirstName = Console.ReadLine();

                Console.WriteLine($"Confirm first name: {newUser.FirstName} ? (y/n)");

                yesOrNo = Console.ReadLine().ToLower();
            } while (yesOrNo == "n");

            do
            {
                Console.WriteLine("\nPlease enter your last name:");
                newUser.LastName = Console.ReadLine();

                Console.WriteLine($"Confirm last name: {newUser.LastName} ? (y/n)");

                yesOrNo = Console.ReadLine().ToLower();
            } while (yesOrNo == "n");


            do
            {
                Console.WriteLine("\nPlease enter a 4-digit pin:");
                newUser.Pin = int.Parse(Console.ReadLine());

                Console.WriteLine($"Confirm Pin: {newUser.Pin} ? (y/n)");

                yesOrNo = Console.ReadLine().ToLower();
            } while (yesOrNo == "n");
            

            

        }
    }
}
