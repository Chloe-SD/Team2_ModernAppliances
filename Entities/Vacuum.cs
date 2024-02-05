using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_ModernAppliances.Entities
{
    internal class Vacuum:Appliance
    {
        protected int _batteryVoltage;
        protected string _grade;

        public int batteryVoltage
        {
            get { return _batteryVoltage;  }
        }
        public string grade
        {
            get { return _grade; }
        }

        public Vacuum (string itemNumber, string brand, int quantity, string wattage, string colour, double price, string grade, int batteryVoltage) : base(itemNumber, brand, quantity, wattage, colour, price)
        {
            batteryVoltage = this.batteryVoltage;
            grade = this.grade;
        }

        public override string FormatForFile()
        {
            return $"{this.ItemNumber}:{this.Brand}:{this.Quantity}:{this.Wattage}:{this.Colour}:{this.Price}:{this.grade}:{this.batteryVoltage}"; 
        }

        public string ToString()
        {
            base.ToString();
            return $"Grade: {this.grade} \nBattery Voltage {this.batteryVoltage}";
        }
    }
}
