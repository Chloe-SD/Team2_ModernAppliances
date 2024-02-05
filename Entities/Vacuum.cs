using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_ModernAppliances.Entities
{
    internal class Vacuum:Appliance
    {
        private int BatteryVoltage { get; set; }
        private string Grade { get; set; }

        public Vacuum(string itemNumber, string brand, int quantity, string wattage, string colour, double price, string grade, int batteryVoltage) : base(itemNumber, brand, quantity, wattage, colour, price)
        {
            batteryVoltage = this.BatteryVoltage;
            grade = this.Grade;
        }

        public override string FormatForFile()
        {
            return $"{this.ItemNumber}:{this.Brand}:{this.Quantity}:{this.Wattage}:{this.Colour}:{this.Price}:{this.Grade}:{this.BatteryVoltage}";
        }

        public string ToString()
        {
            base.ToString();
            return $"Grade: {this.Grade} \n"+
                $"Battery Voltage: {this.BatteryVoltage} V";
        }
    }
}
