using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Team2_ModernAppliances
{
    internal abstract class ProgramTools
    {
        public static int GetUserSelection(string menu, int min, int max)
        {
            // Use this to get a selection for your menu. 
            // NOTE: This method will actually display the menu. Pass the ENTIRE menu in as one formatted string
            // Also pass in the minimum and maximum acceptable replies.

            // an example of using this would look like this
            // string exampleMenu = $"1 - selection one \n2 - selection two \n3 - selection three"
            // int userSelection = GetUserSelection(exampleMenu, 1, 3)
            while (true) // loop goes until a valid selection is made
            {
                Console.WriteLine(menu); // prints the menu EACH TIME the loop runs
                string? input = Console.ReadLine(); // reads user input
                if (int.TryParse(input, out int selection)) // tries to parse an int, if sucessful saves as 'selection'
                {
                    if (selection >= min && selection <= max) // determine if 'selection' is in required range
                    {
                        return selection; // return the int and break the loop
                    }
                }
                // if not valid, prints this error and loops again
                Console.WriteLine($"\nInvalid selection. Please enter a whole number between {min} and {max}\n");
            }
        }
        public static string GetUserSelection(string prompt, List<string> acceptableInput)
        {
            // when you need the user to input a specific value that isnt just an int within a certain range use this.
            //This nethod will display the prompt for you, pass the prompt, and a list of acceptable user responses.
            // NOTE:: For comparison purposes, ensure all acceptable answers are uppercase

            //Example use case: User needs to select what voltage of vacuum they want::::::
            // string voltagePrompt = "Enter battery voltage value. 18 V (low) or 24 V (high)";
            // List<string> acceptableInput = new List<string>(){"18","24"};
            // string userVoltage = ProgramTools.GetUserSelection(voltagePrompt, List<string> acceptableInput);

            // in the above example, the loop will run until the user enters either 18, or 24. then it will return the value to you.
            while (true)
            {
                Console.WriteLine(prompt); // displays the prompt you sent
                string? userInput = Console.ReadLine(); // read user input
                if (userInput != null) // ensure input not null
                {
                    if (acceptableInput.Contains(userInput.ToUpper())) // determine if input matches an acceptable answer
                    {
                        return userInput.ToUpper(); // always returns all uppercase string (does not affect numbers)
                    }
                }
                // if not an acceptable answer, Error message and loop again.
                Console.WriteLine($"Invalid selection, please one of the following options: {string.Join(", ", acceptableInput)}");
            }
        }
    }
}
