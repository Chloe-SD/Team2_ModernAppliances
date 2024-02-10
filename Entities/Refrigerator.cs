using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_ModernAppliances.Entities
{
    internal class Refrigerator:Appliance
    {
        private int Doors { get; set; }
        private double Height { get; set; }
        private double Width { get; set; }

        public Refrigerator(string itemNumber, string brand, int quantity, string wattage, string colour, double price, int doors, double height, double width) : base(itemNumber, brand, quantity, wattage, colour, price)
        {
            this.Doors = doors;
            this.Height = height;
            this.Width = width;
        }
        public int GetDoors()
        {
            return this.Doors;
        }

        public override string FormatForFile()
        {
            return $"{this.ItemNumber};{this.Brand};{this.Quantity};{this.Wattage};{this.Colour};{this.Price};{this.Doors};{this.Height};{this.Width};";
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"Doors: {this.Doors}\n" +
                $"Height: {this.Height}\n" +
                $"Width: {this.Width}\n";
        }
    }
}
