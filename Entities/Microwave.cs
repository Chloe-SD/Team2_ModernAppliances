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
        private char RoomValue { get; set; }
        private RoomType RoomType { get; set; }
        
        //microwave ctor
        public Microwave(string id, string brand, int quantity, string wattage, string colour, double price, string capacity, char room) :base(id, brand, quantity, wattage, colour, price)
        {
            // all shared attributes set by parent class ctor
            this.Capacity = capacity;
            this.RoomValue = room;
            this.RoomType = GetRoomType(room);
        }
        public RoomType GetRoomType(char room)
        {
            if (room == 'K')
            {
                return RoomType.Kitchen;
            }
            else
            {
                return RoomType.WorkSite;
            }
        }
        public override string FormatForFile()
        {
            // formatted string for file, seperated by ;
            return $"{this.ItemNumber};{this.Brand};{this.Quantity};{this.Wattage};{this.Colour};{this.Price};{this.Capacity};{this.RoomValue};";
        }
        public override string ToString()
        {
            // calls base to print all shared attribute values
            // then returns microwave specific attributes
            return $"{base.ToString()}" +
                $"Capacity: {this.Capacity}\n" +
                $"RoomType: {this.RoomType}";
        }
    }
}
