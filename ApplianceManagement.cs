using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_ModernAppliances.Entities;

namespace Team2_ModernAppliances
{
    internal abstract class ApplianceManagement
    {
        //list for storigng all appliance objects
        protected List<Appliance> applianceList {  get; set; }

        public ApplianceManagement()
        {
            
            this.applianceList = new List<Appliance>(); // make a new list
            this.PopulateList();    // Read file to populate list

        }
        private void PopulateList()
        {
            // TODO: QUESTION: can we make this a relative path instead? will use for now to build program
            string filePath = @"appliances.txt";
            StreamReader reader = new StreamReader(filePath);
            
            string? line = reader.ReadLine(); // read first line of file
            while (line != null) // loop as long as line is not null value
            {
                string[] parts = line.Split(';'); // create an array of attributes (Split at semicolon)
                Appliance newAppliance = CreateAppliance(parts); // create new appliance OBJ
                applianceList.Add(newAppliance); // add to list      
                line = reader.ReadLine(); // read next line of file for next loop iteration
            }
        }
        private Appliance CreateAppliance(string[] parts)
        {
            // set values for all shared attibutes, each appliance will have these
            string id = parts[0];
            string brand = parts[1];
            int quantity = int.Parse(parts[2]);
            string wattage = parts[3];
            string colour = parts[4];
            double price = double.Parse(parts[5]);

            if (id[0] == '1') // item is a refrigerator
            {
                int doors = int.Parse(parts[6]);
                double height = double.Parse(parts[7]);
                double width = double.Parse(parts[8]);
                Appliance newRefrigerator = new Refrigerator(id, brand, quantity, wattage, colour, price, doors, height, width);
                return newRefrigerator;
            }
            else if (id[0] == '2') // item is a vacuum
            {
                string grade = parts[6];
                int voltage = int.Parse(parts[7]);
                Appliance newVacuum = new Vacuum(id, brand, quantity, wattage, colour, price, grade, voltage);
                return newVacuum;
            }
            else if (id[0] == '3') //item is a microwave
            {
                string capacity = parts[6];
                char room = char.Parse(parts[7]);
                Appliance newMicrowave = new Microwave(id, brand, quantity, wattage, colour, price, capacity, room);
                return newMicrowave;
            }
            else // item is a dishwasher
            {
                string rating = parts[7];
                string feature = parts[6];
                Appliance newDishwasher = new Dishwasher(id, brand, quantity, wattage, colour, price, rating, feature);
                return newDishwasher;
            }
        }
        public void WriteToFile()
        {
            //TODO: QUESTION: Change to Absolute Path?
            string fileDestination = @"C:\Users\Denve\OneDrive\Desktop\OOP II\Project\DenverBranch\appliancestest.txt";
            using StreamWriter writer = new StreamWriter(fileDestination);
            foreach (Appliance app in applianceList) // For loop to write out each appliance to txt file
            {
                writer.WriteLine(app.FormatForFile());
            }
        }
        public int GetUserSelection(string menu, int min, int max)
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
                Console.WriteLine($"Invalid selection. Please enter a whole number between {min} and {max}");
            }
            
        }

        public void DisplaySelectedAppliances(List<Appliance> selectedAppliances)
        {
            foreach (Appliance appliance in selectedAppliances)
            {
                Console.WriteLine($"{appliance}\n");
            }
        }
        public abstract void DisplayAllItems();
        public abstract int DisplayMainMenu();
        public abstract void Checkout();
        public abstract void SearchByType();
        public abstract void RandomSearch();

    }
}
