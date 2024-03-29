﻿using System;
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
        private string voltageDisplay { get; set; }

        public Vacuum(string itemNumber, string brand, int quantity, string wattage, string colour, double price, string grade, int batteryVoltage) : base(itemNumber, brand, quantity, wattage, colour, price)
        {
            this.BatteryVoltage = batteryVoltage;
            this.Grade = grade;
            this.voltageDisplay = GetVoltageDisplay(batteryVoltage);
        }
        public string GetVoltage()
        {
            return this.BatteryVoltage.ToString();
        }

        private string GetVoltageDisplay(int voltage)
        {
            if (voltage == 18)
            {
                return "Low";
            }
            return "high";
        }

        public override string FormatForFile()
        {
            return $"{this.ItemNumber};{this.Brand};{this.Quantity};{this.Wattage};{this.Colour};{this.Price};{this.Grade};{this.BatteryVoltage};";
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"Grade: {this.Grade} \n"+
                $"Battery Voltage: {this.voltageDisplay}";
        }
    }
}
