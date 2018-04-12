using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingExperience
{
    class User
    {
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string UserName { get; set; }
        public static int Pin { get; set; }
        public static bool IsAccountOwner { get; set; }

        enum ReturnType { rStr, rInt };
        bool isConfirmed = false;



        //Asks the user for their First and Last name
        //Loops until name is confirmed correct by user.
        public void NamePrompt()
        {
            do
            {
                FirstName = AskQuestion("Enter your first name:", ReturnType.rStr).ToString();
                LastName = AskQuestion("Enter your last name:", ReturnType.rStr).ToString();
                Console.WriteLine($"Is your name correct? (y/n): {FirstName} {LastName}");

                isConfirmed = ConfirmData();
                Console.Clear();

            } while (!isConfirmed);
        }



        //Asks the user to create a username
        //Loops until username is confirmed by user.
        public void UsernamePrompt()
        {
            do
            {
                UserName = AskQuestion("Enter a Username:", ReturnType.rStr).ToString();
                Console.WriteLine($"Would you like your Username to be: '{UserName}' ? (y/n)");

                isConfirmed = ConfirmData();
                Console.Clear();

            } while (!isConfirmed);
        }



        //Asks the user to create a 4-digit Pin
        //Loops until the Pin is confirmed by the user, and is 4 didgits.
        public void PinPrompt()
        {
            do
            {
                Pin = (int)AskQuestion("Enter a 4-digit pin:", ReturnType.rInt);
                Console.WriteLine($"Would you like your pin to be: '{Pin}' ? (y/n)");

                isConfirmed = ConfirmData();
                Console.Clear();

            } while (!isConfirmed);
        }



        //Asks the user to Login with a Username and Pin
        //Loops until the correct Username and Pin are entered
        public void Login()
        {
            do
            {
                bool isUserName = (AskQuestion("\nUsername:", ReturnType.rStr).ToString() == UserName);
                bool isPin = ((int)AskQuestion("\nPin:", ReturnType.rInt) == Pin);

                IsAccountOwner = (isUserName == true && isPin == true);

                var confirmMessage = (IsAccountOwner) ? $"\nLogin Successful!\nWelcome {FirstName} {LastName}!" : "\nUsername or Password incorrect!";
                Console.Clear();
                Console.WriteLine(confirmMessage);

            } while (!IsAccountOwner);
        }



        //Based on the character passed through, Returns either the string entered by the user or a pin number.
        private static object AskQuestion(string question, ReturnType returnType)
        {
            var isInt = false;
            Console.WriteLine(question);
            switch (returnType)
            {
                case ReturnType.rStr:
                    return Console.ReadLine();
                case ReturnType.rInt:
                    {
                        //Input validation for the pin number
                        question = question.Replace(" (must be a 4 digit number!)", "");
                        var input = Console.ReadLine();
                        isInt = int.TryParse(input, out int value);
                        return (isInt && input.Length == 4) ? value : AskQuestion(question + " (must be a 4 digit number!)", returnType);
                    }
                default:
                    return "This will never run";
            }
        }



        //Returns true if the user enters 'y' for Yes, or returns false if the user enters 'n' for No.
        private static bool ConfirmData()
        {
            do
            {
                var answer = Console.ReadLine();

                if (answer.ToLower() == "y") { return true; }
                else if (answer.ToLower() == "n") { return false; }
                else { Console.WriteLine("Please enter either a 'y' for Yes, or a 'n' for No."); }
            } while (true);
        }
    }
}
