using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_ModernAppliances
{
    internal class ProgramMenu:ApplianceManagement
    {
        public ProgramMenu():base()
        {
            //TODO: Put the welcome message here
        }
        public override void DisplayAllItems()
        {
            foreach (Appliance appliance in base.applianceList)
            {
                Console.WriteLine(appliance);

            }
        }
        public override int DisplayMainMenu()
        {
            // String for the display of the menu
            string menu = "Welcome to Modern Appliances!\n" +
                              "How may we assist you?\n" +
                              "1 - Check out appliance\n" +
                              "2 - Find appliances by brand\n" +
                              "3 - Display appliances by type\n" +
                              "4 - Produce random appliance list\n" +
                              "5 - Save & exit";

            //storing the integer and returning the user selction
            int userSelection = GetUserSelection(menu, 1, 5);
            return userSelection;
        }
        public override void Checkout()
        {
            // NOTE:!!! Check the output example when writing any menus!!!
            // prompt to enter item number
            // search list by item number
            // if item not foind print an error message
            // if found call checkout method in base appliance class
                    // this will return a bool of either true of false
                    // if false is returned that means the item is not in stock (Already has quantity of 0)
                    // if true is returned that means that the item IS in stock AND the quantity has been decreased by 1
            //print whatever confirmation we are supposed to print (from sample)

            // NOTE!! IMPORTANT!! There is already a checkout method in appliance, perhaps its better to just call that since it chan change the attribure itself
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
            Console.WriteLine($"Please enter a number between 1 and {applianceList.Count}");
            string userEntry = Console.ReadLine();
            int randoNum;
            List<Appliance> randomList = new List<Appliance>();
            while (true)
            {
                if (int.TryParse(userEntry, out randoNum))
                {
                    if (1 <= randoNum && randoNum <= applianceList.Count)
                    {
                        // generate a number of random integers (between 1 and inputList.Count) equal to userEntry
                        for (int i = 0; i < randoNum; i++)
                        {
                            Random rand = new Random();
                            int random = rand.Next(1, (applianceList.Count + 1));
                            randomList.Add(applianceList[random]);
                        }
                        // for each random integer generated, print the appliance object at inputList[random int]
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid entry. Please enter a number between 1 and {applianceList.Count}");
                        userEntry = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid entry. Please enter a number between 1 and {applianceList.Count}");
                    userEntry = Console.ReadLine();
                }
            }
            DisplaySelectedAppliances(randomList);
        }
        //{

        //}
    }
}
