using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_ModernAppliances.Entities
{
    internal class Refrigerator:Appliance
    {
        public int Doors { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        public Refrigerator(string itemNumber, string brand, int quantity, string wattage, string colour, double price, int doors, double height, double width) : base(itemNumber, brand, quantity, wattage, colour, price)
        {
            this.Doors = doors;
            this.Height = height;
            this.Width = width;
        }

        public override string FormatForFile()
        {
            return $"{this.ItemNumber};{this.Brand};{this.Quantity};{this.Wattage};{this.Colour};{this.Price};{this.Doors};{this.Height};{this.Width}";
        }

        public override string ToString()
        {
            // all appliances need to have a ToString. but you can call base as part of the output
            // and just add in the additional details specific to appliance type
            return $"ItemNumber: {this.ItemNumber}\n" +
                $"Brand: {this.Brand}\n" +
                $"Quantity: {this.Quantity}\n" +
                $"Wattage: {this.Wattage}\n" +
                $"Colour: {this.Colour}\n" +
                $"Price: {this.Price}\n" +
                $"Doors: {this.Doors}\n" +
                $"Height: {this.Height}\n" +
                $"Width: {this.Width}";
        }
    }
}
