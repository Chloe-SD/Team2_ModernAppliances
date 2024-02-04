using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_ModernAppliances.Entities
{
    public class Dishwasher : Appliance
    {
        private string _soundRating; // Private field to store the sound rating of the dishwasher

        public string SoundRating // Public property to get and set the sound rating of the dishwasher
        {
            get { return _soundRating; }
            set
            {
                // Validate the sound rating value
                if (value.ToLower() == "qt" || value.ToLower() == "qr" || value.ToLower() == "qu" || value.ToLower() == "m")
                {
                    _soundRating = value;
                }
            }
        }

        // Public properties to provide constant values for different sound ratings
        public string SoundRatingModerate => "M";
        public string SoundRatingQT => "Qt";
        public string SoundRatingQR => "Qr";
        public string SoundRatingQU => "Qu";

        // Public property to get and set the feature of the dishwasher
        public string Feature { get; set; }

        // Constructor to initialize the Dishwasher object
        public Dishwasher(string itemNumber, string brand, int quantity, int wattage, string color, double price, string soundRating, string feature)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            SoundRating = soundRating; // Set the sound rating
            Feature = feature; // Set the feature
        }

        // Override ToString method to provide a string representation of the Dishwasher object
        public override string ToString()
        {
            return $"Dishwasher Details:\n" +
                   $"Item Number: {ItemNumber}\n" +
                   $"Brand: {Brand}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Wattage: {Wattage}\n" +
                   $"Color: {Color}\n" +
                   $"Price: {Price}\n" +
                   $"Sound Rating: {SoundRating}\n" +
                   $"Feature: {Feature}\n";
        }

        // Method to format dishwasher details for file output
        public string FormatForFile()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Feature};{SoundRating};";
        }
    }
}
