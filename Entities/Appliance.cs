﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_ModernAppliances
{
    internal abstract class Appliance
    {
        // Shared attributes for all appliance types
        protected string ItemNumber { get; set; }
        protected string Brand { get; set; }
        protected int Quantity { get; set; }
        protected string Wattage { get; set; }
        protected string Colour { get; set; }
        protected double Price { get; set; }
        public string GetItemNumber() => ItemNumber;
        public string GetBrand() => Brand;

        public Appliance(string itemNumber, string brand, int quantity, string wattage, string colour, double price)
        {
            this.ItemNumber = itemNumber;
            this.Brand = brand;
            this.Quantity = quantity;
            this.Wattage = wattage;
            this.Colour = colour;
            this.Price = price;
            // cannot instanciate Appliance obj, must use polymorphism and pass these values to base
            // example - Appliance x = new Microwave(attributes)
            // ctor for Microwave example:
                //public Microwave(all attributes):base(base attributes)
                    // this.microwaveAttributes = microwave specific attributes
        }
        public bool Checkout()
        {
            if (this.Quantity >= 1) // check if item is in stock
            {
                this.Quantity--; // if in stock, decrease quantity by 1
                return true; // true tells the caller that the process is sucessful
            }
            else
            {
                return false; // otherwise, false tells the caller that the item is unavailale
            }
        }
        public void DetermineApplianceType()
        {
            Console.WriteLine("DetermineApplianceType() not written yet");
            //TODO: QUESTION: Is this what the UML says? its cut off. We will write this
            //when we know more about what needs to call it
        }
        public abstract string FormatForFile();
        // force all types to have a format method.
        // neets to return a string of all attributes in the same format as the txt file.
        public override string ToString()
        {
            // all appliances need to have a ToString. but you can call base as part of the output
            // and just add in the additional details specific to appliance type
            return $"ItemNumber: {this.ItemNumber}\n" +
                $"Brand: {this.Brand}\n" +
                $"Quantity: {this.Quantity}\n" +
                $"Wattage: {this.Wattage}\n" +
                $"Colour: {this.Colour}\n" +
                $"Price: {this.Price}\n";
        }
     
    }
}
