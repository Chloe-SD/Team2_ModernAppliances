/*    
 Team 2 - CPRG 211 E
Project 1 - Modern Appliances
!!! NOTE - add ID numbers !!!
Brooke - 000914122                         
Chloe - 000913397
Denver - 000920687 
Zack - 000927584


Summary: This program will manage a text file database of appliances. allowing one to search by type, brand, 
even a random list. The program will also allow one to "check out" an appliance, which will alter the quantity availalbe
and save the canges in the text file at the time that the program closes.
 */ 

using System.ComponentModel;
using System.Runtime.Intrinsics.X86;

namespace Team2_ModernAppliances
{
    
    internal class Program
    {
        // all methods are explained where they occur.
        

        //IMPORTANT!!!! Replace this filepath with your absolute pate before running this program. 
        public static string filePath = @"C:\Users\School\source\repos\Team2_ModernAppliances\appliances.txt";

        static void Main(string[] args)
        {           
            ApplianceManagement system = new ProgramMenu();
            while (true)
            {
                int mainMenuSelection = system.DisplayMainMenu(); //Displays main menu, gets user selection
                if (mainMenuSelection == 1) // checkout by item number
                {
                    system.Checkout();
                }
                else if (mainMenuSelection == 2) // search by  appliance brand
                {
                    system.SearchByBrand();
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
                    // write method commented while testing. dont want to make a new file every time you test                 
                    system.WriteToFile(); 
                    break; 
                }

            }
        }
    }
}
