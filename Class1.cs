using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_ModernAppliances
{
    internal abstract class Appliance
    {
        // Shared attributes for all appliance types
        // abstract forces any child class to inherit these attributes
        // TODO: QUESTION: Cant use private for abstract, is protected acceptable?
        protected abstract string ItemNumber { get; set; }
        protected abstract string Brand { get; set; }
        protected abstract int Quantity { get; set; }
        protected abstract string Wattage { get; set; }
        protected abstract string Colour { get; set; }
        protected abstract double Price { get; set; }

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
        public void Checkout()
        {
            Console.WriteLine("Checkout() not written yet");
            //call this when "purchasing" an appliance to decrease QUANTITY by 1
            //check if stock is avaialble
            //if available - this.Quantity--;
            //if unavailable - Error
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
