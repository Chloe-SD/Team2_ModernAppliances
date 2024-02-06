/*    
 Team 2 - CPRG 211 E
Project 1 - Modern Appliances
!!! NOTE - add ID numbers !!!
Brooke                          
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
            //nothing here yet

            // NOTE: I commonly use three terms in my comments to be able to search an entire
            // file for things quickly (NOTE: TODO: and QUESTION:) if y'all have a system that will work better for you
            // please let me know - chloe
            
            // used following for testing, created list of all appliances and sent all of them ToString
            ApplianceManagement x = new ProgramMenu();
            x.WriteToFile();
            //x.SearchByType();
            //x.DisplayMainMenu();
            //x.DisplayAllItems();
        }
    }
}
