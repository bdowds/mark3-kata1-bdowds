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

            var testUser = new User();

            testUser.NamePrompt();

            //Calls three Methods to get: First and Last name, Username, and Pin from the user.
            newUser.NamePrompt();
            newUser.UsernamePrompt();
            newUser.PinPrompt();

            Console.WriteLine("\nAccount has been created successfully!");
            Console.WriteLine("\nPlease Login");

            //Asks the user to input data to Login.
            newUser.Login();


            //End of Code
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadLine();
        }       
    }
}
