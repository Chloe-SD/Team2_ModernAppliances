using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_ModernAppliances.Entities
{
    public enum RoomType
    {
        Kitchen,
        WorkSite
    }
    internal class Microwave:Appliance
    {
        //Microwave specific attributes
        private string Capacity {  get; set; }
        private RoomType Room { get; set; }
        //microwave ctor
        public Microwave(string id, string brand, int quantity, string wattage, string colour, double price, string capacity, RoomType roomType) :base(id, brand, quantity, wattage, colour, price)
        {
            this.Capacity = capacity;
            this.Room = roomType;
        }
        public override string FormatForFile()
        {
            return $"{this.ItemNumber};{this.Brand};{this.Quantity};{this.Wattage};{this.Colour};{this.Price};{this.Capacity};{this.Room};";
        }
        public override string ToString()
        {
            base.ToString();
            return $"Capacity: {this.Capacity}\n" +
                $"RoomType: {this.Room}";
        }
    }
}
