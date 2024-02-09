using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Team2_ModernAppliances
{
    internal class ProgramMenu:ApplianceManagement
    {
        public ProgramMenu():base()
        {
            //just makes a menu OBJ
        }
        public override void Checkout()

        {
            Console.WriteLine("Enter the item number of an appliance:");
            string? itemNumberInput = Console.ReadLine(); // ? defines that the field could be null, removes warning
            int validatedItemNumber = 0;
            if (itemNumberInput != null)
            {
                if (itemNumberInput.Length == 9 && int.TryParse(itemNumberInput, out int itemNumber) && itemNumber >= 100000000 && itemNumber <= 999999999)
                {
                    validatedItemNumber = itemNumber; // gives us a validated 9 digit int in the specified range
                }
                else
                {
                    Console.WriteLine("Invalid item number. Please enter a 9-digit number.\n");
                    return; // breaks the process if entry invalid
                }
            }
            // at this point we have a validated item number to compare to appliance objects. 
            // note that the below is unreachable is validatedItemNumber still is 0, or is invalid

            Appliance? applianceToCheckout = null; // ? to define value van be null
            foreach (Appliance appliance in applianceList)
            {
                if (appliance.GetItemNumber() == validatedItemNumber.ToString()) 
                {
                    //now we are comparing appliance to validated input, rather than any potential input
                    // eliminating unnessesary calculations
                    applianceToCheckout = appliance;
                    break; // nice move, stopping the rest of the loop if a match is found!
                }
            }

            if (applianceToCheckout != null)
            {
                bool applianceAvailable = applianceToCheckout.Checkout(); // This will check if available. and if so decrease QTY for us
                if (applianceAvailable)
                {
                    Console.WriteLine($"Appliance \"{applianceToCheckout.GetItemNumber()}\" has been checked out.\n");
                    return; // all we need is confirmation msg. we know the QTY is handled already due to the true bool
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.\n");
                    return;
                }
            }
            else
            {
                Console.WriteLine("No appliances found with that item number.\n");
                return;
            }
        }
        public override void SearchByBrand()
        {
            Console.WriteLine("Enter brand to search for:");
            string? userInput = Console.ReadLine();
            if (userInput != null)
            {
                if (!userInput.Any(char.IsDigit))
                {
                    List<Appliance> brand = applianceList
                        .Where(appliance => appliance.GetBrand() == userInput.ToUpper())
                        .ToList();
                    if (brand.Count > 0)
                    {
                        Console.WriteLine("Matching Appliances:\n");
                        DisplaySelectedAppliances(brand);
                        return;
                    }
                    Console.WriteLine("Sorry, No appliances found with that brand name.\n");
                    return;

                }
            }
            Console.WriteLine("Invalid brand name.\n");
            return;
        }
        public override void SearchByType()
        {
            // NOTE:!!! Check the output example when writing any menus!!!
            // prompt to choose type
            // NOTE: There may be other options asked, check the sample output, we might need sub-menus here
            // use an int verify method to make sure input is acceptable
            // store whatever type they chose as a variable
            //iterate through list
            //if OBJ type is equal to input type, sent that OBj ToString()
        }
        public override void RandomSearch()
        {
            string randoPrompt = $"Please enter a number between 1 and {applianceList.Count}";
            int randoNum = GetUserSelection(randoPrompt, 1, applianceList.Count);
            List<Appliance> randomList = new List<Appliance>();
            // generate a number of random integers (between 1 and inputList.Count) equal to userEntry
            for (int i = 0; i < randoNum; i++)
            {
                Random rand = new Random();
                int random = rand.Next(1, (applianceList.Count + 1)); 
                randomList.Add(applianceList[random-1]);
            }
            // for each random integer generated, print the appliance object at inputList[random int]
            DisplaySelectedAppliances(randomList);
        }
    }
}
