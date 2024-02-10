using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Team2_ModernAppliances.Entities;

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
            string validatedItemNumber = "000000000";
            if (itemNumberInput != null)
            {
                if (itemNumberInput.Length == 9 && int.TryParse(itemNumberInput, out int itemNumber) && itemNumber >= 100000000 && itemNumber <= 999999999)
                {
                    validatedItemNumber = itemNumber.ToString(); // gives us a validated 9 digit int in the specified range
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
                if (appliance.GetItemNumber() == validatedItemNumber) 
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
                        .Where(appliance => appliance.GetBrand().ToUpper() == userInput.ToUpper())
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
            List<Appliance> selectedAppliances = new List<Appliance>();
            int userSelection = DisplayByTypeMenu();
            if (userSelection == 1) // Refrigerators
            {
                string doorsMenu = $"Enter number of doors: \n2 (double door), 3 (three doors) or 4 (four doors):";
                int doorsSelection = ProgramTools.GetUserSelection(doorsMenu, 2, 4); //get a validated number between 2 and 4
                List<Appliance> refrigerators = applianceList //itearate thru appliances
                    .Where(appliance => appliance is Refrigerator && ((Refrigerator)appliance).GetDoors() == doorsSelection)
                    .ToList(); // Lambda to compare applainces, Filters out anything that isnt a fridge with selected number of doors and adds them to a list as it goes.
                DisplaySelectedAppliances(refrigerators); // display the list of appliances
                return;

            }
            else if (userSelection == 2) // Vacuums
            {
                string voltagePrompt = $"Enter battery voltage value. 18 V (low) or 24 V (high)";
                List<string> voltages = new List<string>() { "18", "24" };
                string voltageSelection = ProgramTools.GetUserSelection(voltagePrompt, voltages);
                List<Appliance> vacuums = applianceList
                     .Where(appliance => appliance is Vacuum && ((Vacuum)appliance).GetVoltage() == voltageSelection)
                     .ToList();
                DisplaySelectedAppliances(vacuums);
                return;
            }
            else if (userSelection == 3) //Microwaves
            {
                string roomPrompt = $"Room where the microwave will be installed: K (kitchen) or W (work site):";
                List<string> roomTypes = new List<string>() { "K", "W" };
                string roomSelection = ProgramTools.GetUserSelection(roomPrompt, roomTypes);
                List<Appliance> microwaves = applianceList
                    .Where(appliance => appliance is Microwave && ((Microwave)appliance).GetRoomValue() == roomSelection)
                    .ToList();
                DisplaySelectedAppliances(microwaves);
                return;
            }
            else // 4 - Dishwashers
            {
                string ratingPrompt = $"Enter the sound rating of the dishwasher: \nQt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):";
                List<string> acceptableInput = new List<string>() { "QT", "QR", "QU", "M" };
                string ratingSelection = ProgramTools.GetUserSelection(ratingPrompt, acceptableInput);
                List<Appliance> dishwashers = applianceList
                    .Where(appliance => appliance is Dishwasher && ((Dishwasher)appliance).GetRating().ToUpper() == ratingSelection)
                    .ToList();
                DisplaySelectedAppliances(dishwashers);
                //display
                return;
            }
        }
        public override void RandomSearch()
        {
            string randoPrompt = $"Please enter a number between 1 and {applianceList.Count}";
            int randoNum = ProgramTools.GetUserSelection(randoPrompt, 1, applianceList.Count);
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
