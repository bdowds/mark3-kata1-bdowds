using System;
using System.Collections.Generic;
using System.Linq;

namespace OnboardingExperience
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcome Message
            Console.WriteLine("Welcome to 'Banking App'!\nPlease create an Account\n");

            //Creates a new instance of User class
            var newUser = new User();

            var isConfirmed = false;
            var isUserName = false;
            var isPin = false;

            //Asks the user for their First and Last name
            //Loops until name is confirmed correct by user.
            do
            {
                newUser.FirstName = AskQuestion("Enter your first name:", 'S').ToString();         
                newUser.LastName = AskQuestion("Enter your last name:", 'S').ToString();
                Console.WriteLine($"Is your name correct? (y/n): {newUser.FirstName} {newUser.LastName}");

                isConfirmed = ConfirmData();
                Console.Clear();

            } while (!isConfirmed);

            //Asks the user to create a username
            //Loops until username is confirmed by user.
            do
            {
                newUser.UserName = AskQuestion("Enter a Username:", 'S').ToString();
                Console.WriteLine($"Would you like your Username to be: '{newUser.UserName}' ? (y/n)");

                isConfirmed = ConfirmData();
                Console.Clear();

            } while (!isConfirmed);

            //Asks the user to create a 4-digit Pin
            //Loops until the Pin is confirmed by the user, and is 4 didgits.
            do
            {
                newUser.Pin = (int)AskQuestion("Enter a 4-digit pin:", 'I');
                Console.WriteLine($"Would you like your pin to be: '{newUser.Pin}' ? (y/n)");

                isConfirmed = ConfirmData();
                Console.Clear();

            } while (!isConfirmed);

            Console.WriteLine("\nAccount has been created successfully!");
            Console.WriteLine("\nPlease Login");

            //Asks the user to Login with a Username and Pin
            //Loops until the correct Username and Pin are entered
            do
            {
                isUserName = (AskQuestion("\nUsername:", 'S').ToString() == newUser.UserName);
                isPin = ((int)AskQuestion("\nPin:", 'I') == newUser.Pin);

                newUser.IsAccountOwner = (isUserName == true && isPin == true);

                var confirmMessage = (newUser.IsAccountOwner) ? $"\nLogin Successful!\nWelcome {newUser.FirstName} {newUser.LastName}!" : "\nUsername or Password incorrect!";
                Console.WriteLine(confirmMessage);

            } while (!newUser.IsAccountOwner);


            //End of Code
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadLine();
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



        //Based on the character passed through, Returns either the string entered by the user or a pin number.
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
    }
}
