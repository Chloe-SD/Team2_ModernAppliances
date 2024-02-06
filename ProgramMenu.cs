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
        public override void DisplayMainMenu()
        {
            //TODO: This will be the main menu
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
        //public override void RandomSearch()
        //{

        //}
    }
}
