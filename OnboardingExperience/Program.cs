using System;

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
                Console.WriteLine("Please enter your first name");
                newUser.FirstName = Console.ReadLine();

                Console.WriteLine($"Confirm first name: {newUser.FirstName} ? (y/n)");

                yesOrNo = Console.ReadLine().ToLower();
            } while (yesOrNo == "n");

            do
            {
                Console.WriteLine("Great! Please enter your last name");
                newUser.LastName = Console.ReadLine();

                Console.WriteLine($"Confirm last name: {newUser.LastName} ? (y/n)");

                yesOrNo = Console.ReadLine().ToLower();
            } while (yesOrNo == "n");

            Console.WriteLine("Great!");

            Console.ReadLine();
            

        }
    }
}
