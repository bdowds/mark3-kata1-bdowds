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

                Console.WriteLine($"Confirm first name: {newUser.FirstName} ? (y/n)");

                isConfirmed = ConfirmData();
            } while (!isConfirmed);

            do
            {              
                newUser.LastName = AskQuestion("Please enter your last name:", 'S').ToString();

                Console.WriteLine($"Confirm last name: {newUser.LastName} ? (y/n)");

                isConfirmed = ConfirmData();
            } while (!isConfirmed);


            do
            {
                newUser.Pin = (int)AskQuestion("Please enter a 4-digit pin:", 'I');

                Console.WriteLine($"Confirm Pin: {newUser.Pin} ? (y/n)");

                isConfirmed = ConfirmData();
            } while (!isConfirmed);
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
            Console.WriteLine($"\n{question}");
            switch (returnType)
            {
                case 'S':
                    return Console.ReadLine();
                case 'I':
                    {               
                        question = question.Replace("(not a number)", "");
                        var input = Console.ReadLine();
                        isInt = int.TryParse(input, out int value);
                        return (isInt && input.Length == 4) ? value : AskQuestion(question + "(not a 4 digit number)", returnType);
                    }
                    
            }
            return "Test";
        }
    }
}
