using System.IO.MemoryMappedFiles;
using Team2_ModernAppliances.Entities;

namespace Team2_ModernAppliances
{
    internal class ProgramMenu : ApplianceManagement
    {
        public ProgramMenu() : base()
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

                              "5 - Save & exit:";

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

            string typeMenu = "Appliance Types\n" +
                              "1 - Refrigerators\n" +
                              "2 - Vacuums\n" +
                              "3 - Microwaves \n" +
                              "4 - Dishwahers\n" +
                              "Enter Option:\n";

            int userSelection = GetUserSelection(typeMenu, 1, 4);

            switch (userSelection)
            {
                case 1:
                    string refrigeratorMenu = "Enter Number of doors: " +
                                              "2 (double door), 3(" +
                                              "three doors), or 4(" +
                                              "four doors)";
                    userSelection = GetUserSelection(refrigeratorMenu, 2, 4);

                    Console.WriteLine("Matching refrigerators:\n");
                    switch (userSelection)
                    {
                        case 2:
                            foreach (object app in applianceList)
                                if (app.GetType() == typeof(Refrigerator))
                                {
                                    Refrigerator fridge = (Refrigerator)app;

                                    if (fridge.getDoors() == 2)
                                    {
                                        Console.WriteLine(fridge.ToString());
                                    }
                                }
                            break;
                        case 3:
                            foreach (object app in applianceList)
                                if (app.GetType() == typeof(Refrigerator))
                                {
                                    Refrigerator fridge = (Refrigerator)app;

                                    if (fridge.getDoors() == 3)
                                    {
                                        Console.WriteLine(fridge.ToString());
                                    }
                                }
                            break;
                        case 4:
                            foreach (object app in applianceList)
                                if (app.GetType() == typeof(Refrigerator))
                                {
                                    Refrigerator fridge = (Refrigerator)app;

                                    if (fridge.getDoors() == 4)
                                    {
                                        Console.WriteLine(fridge.ToString());
                                    }
                                }
                            break;
                    }
                    break;
                case 2:
                    string vacuumMenu = "Enter batter voltage value. 18 V (low)" +
                                         " or 24 V (high)";
                    Console.WriteLine(vacuumMenu);
                    
                    
                    string? input = Console.ReadLine(); // reads user input
                    while (input != "18" && input != "24")
                    {
                        // if not valid, prints this error and loops again
                        Console.WriteLine($"Invalid selection \n" + vacuumMenu);
                        input = Console.ReadLine();
                    }

                    Console.WriteLine("Matching Vacuums:\n");
                    if (int.TryParse(input, out int selection)) // tries to parse an int, if sucessful saves as 'selection'
                    {
                        if (selection == 18) // determine if 'selection' is in required range
                        {
                            foreach (object app in applianceList)
                                if (app.GetType() == typeof(Vacuum))
                                {
                                    Vacuum vacuum = (Vacuum) app;

                                    if (vacuum.GetBatteryVoltage() == 18)
                                    {
                                        Console.WriteLine(vacuum.ToString());
                                    }
                                }
                        }

                        if (selection == 24) // determine if 'selection' is in required range
                        {
                            foreach (object app in applianceList)
                                if (app.GetType() == typeof(Vacuum))
                                {
                                    Vacuum vacuum = (Vacuum)app;

                                    if (vacuum.GetBatteryVoltage() == 24)
                                    {
                                        Console.WriteLine(vacuum.ToString());
                                    }
                                }
                        }

                     }
                    break;
                case 3:
                    string microwaveMenu = "Room where the microwave will be" +
                                           "installed: K (kitchen) or W (work" +
                                           " site)";
                    Console.WriteLine(microwaveMenu);

                    input = Console.ReadLine(); // reads user input
                    while (input != "K" && input != "W")
                    {
                        // if not valid, prints this error and loops again
                        Console.WriteLine($"Invalid selection. \n" + microwaveMenu);
                        input = Console.ReadLine();
                    }

                    Console.WriteLine("Matching microwaves:\n");
                    char roomType = input[0];

                    if (roomType == 'K')
                    {
                        foreach (object app in applianceList)
                            if (app.GetType() == typeof(Microwave))
                            {
                                Microwave microwave = (Microwave)app;

                                if (microwave.GetRoomType() == RoomType.Kitchen)
                                {
                                    Console.WriteLine(microwave.ToString());
                                }

                            }
                    }
                    else
                    {
                        foreach (object app in applianceList)
                            if (app.GetType() == typeof(Microwave))
                            {
                                Microwave microwave = (Microwave)app;

                                if (microwave.GetRoomType() == RoomType.WorkSite)
                                {
                                    Console.WriteLine(microwave.ToString());
                                }

                            }

                    }
                    break;
                case 4:
                    string dishwasherMenu = "Enter the sound rating of the " +
                                            "dishwasher: Qt (Quietest), Qr " +
                                            "(Quieter), Qu(Quiet) or M (Moderate): ";
                    Console.WriteLine(dishwasherMenu);
                    input = Console.ReadLine(); // reads user input
                    while (input != "Qt" && input != "Qr" && input != "Qu" && input != "M")
                    {
                        // if not valid, prints this error and loops again
                        Console.WriteLine($"Invalid selection \n" + dishwasherMenu);
                        input = Console.ReadLine();
                    }
                    Console.WriteLine("Matching dishwashers:");
                    

                    switch (input) 
                    {
                        case "Qt":
                            foreach (object app in applianceList)
                                if (app.GetType() == typeof(Dishwasher))
                                {
                                    Dishwasher dishwasher = (Dishwasher)app;

                                    if (dishwasher.GetSoundRatingDisplay() == "Quietest")
                                    {
                                        Console.WriteLine(dishwasher.ToString());
                                    }
                                }
                            break;

                        case "Qr":
                            foreach (object app in applianceList)
                                if (app.GetType() == typeof(Dishwasher))
                                {
                                    Dishwasher dishwasher = (Dishwasher)app;

                                    if (dishwasher.GetSoundRatingDisplay() == "Quieter")
                                    {
                                        Console.WriteLine(dishwasher.ToString());
                                    }
                                }
                            break;

                        case "Qu":
                            foreach (object app in applianceList)
                                if (app.GetType() == typeof(Dishwasher))
                                {
                                    Dishwasher dishwasher = (Dishwasher)app;

                                    if (dishwasher.GetSoundRatingDisplay() == "Quiet")
                                    {
                                        Console.WriteLine(dishwasher.ToString());
                                    }
                                }
                            break;

                        case "M":
                            foreach (object app in applianceList)
                                if (app.GetType() == typeof(Dishwasher))
                                {
                                    Dishwasher dishwasher = (Dishwasher)app;

                                    if (dishwasher.GetSoundRatingDisplay() == "Moderate")
                                    {
                                        Console.WriteLine(dishwasher.ToString());
                                    }

                                }
                            break;
                    }

                    break;

            }


        }
        public override void RandomSearch()
        {
            // random search
        }
        //{

        //}
    }
}
