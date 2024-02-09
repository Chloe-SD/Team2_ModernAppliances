/*    
 Team 2 - CPRG 211 E
Project 1 - Modern Appliances
!!! NOTE - add ID numbers !!!
Brooke - 000914122                        
Chloe - 000913397
Denver
Zack

 */

namespace Team2_ModernAppliances
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // NOTE: I commonly use three terms in my comments to be able to search an entire
            // file for things quickly (NOTE: TODO: and QUESTION:) if y'all have a system that will work better for you
            // please let me know - chloe

            // TODO: List
            // see if user input can be tabbed, underlined and bolded

            ApplianceManagement system = new ProgramMenu();
            system.DisplayAllItems();
            while (true)
            {
                int mainMenuSelection = system.DisplayMainMenu(); //Displays main menu, gets user selection
                if (mainMenuSelection == 1) // checkout by item number
                {
                    system.Checkout();
                }
                else if (mainMenuSelection == 2) // search by  appliance brand
                {
                    // method needed
                }
                else if (mainMenuSelection == 3) // search by type of appliance
                {
                    system.SearchByType();
                }
                else if (mainMenuSelection == 4) // get random list of appliances
                {
                    system.RandomSearch();
                }
                else // save program and terminate loop.
                {
                    // write method commented while testing. dont want to make a new file every time
                    // I run a test.
                    //system.WriteToFile(); 
                    break;
                }

            }
        }
    }
}
