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
            base.Checkout();
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
            // random search
        }
        //{

        //}
    }
}
