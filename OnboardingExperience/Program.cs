using System;
using System.Collections.Generic;
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
                newUser.FirstName = AskQuestion("Please enter your first name:", 'S').ToString();         
                newUser.LastName = AskQuestion("Please enter your last name:", 'S').ToString();
                Console.WriteLine($"Is your name correct? (y/n): {newUser.FirstName} {newUser.LastName}");

                isConfirmed = ConfirmData();
                Console.Clear();

            } while (!isConfirmed);

            do
            {
                newUser.UserName = AskQuestion("Please enter a user name:", 'S').ToString();
                Console.WriteLine($"Would you like your user name to be: '{newUser.UserName}' ? (y/n)");

                isConfirmed = ConfirmData();
                Console.Clear();

            } while (!isConfirmed);
            do
            {
                newUser.Pin = (int)AskQuestion("Please enter a 4-digit pin:", 'I');
                Console.WriteLine($"Would you like your pin to be: '{newUser.Pin}' ? (y/n)");

                isConfirmed = ConfirmData();
                Console.Clear();

            } while (!isConfirmed);

            Console.WriteLine("Account has been created successfully!");

            /*do
            {
                Console.WriteLine("\nPlease Login");
            }*/
        }

        private static bool ConfirmData()
        {
            do
            {
                var answer = Console.ReadLine();

                if (answer.ToLower() == "y")
                {
                    return true;
                }
                else if (answer.ToLower() == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter either a 'y' for Yes, or a 'n' for No.");
                }
            } while (true);
        }

        private static object AskQuestion(string question, char returnType)
        {
            var isInt = false;
            Console.WriteLine(question);
            switch (returnType)
            {
                case 'S':
                    return Console.ReadLine();
                case 'I':
                    {               
                        question = question.Replace(" (not a 4 digit number)", "");
                        var input = Console.ReadLine();
                        isInt = int.TryParse(input, out int value);
                        return (isInt && input.Length == 4) ? value : AskQuestion(question + " (not a 4 digit number)", returnType);
                    }                    
            }
            return "Test";
        }
    }
}
