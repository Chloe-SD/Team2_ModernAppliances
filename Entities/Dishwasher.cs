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

        // Public property to get and set the sound rating of the dishwasher
        public string SoundRating
        {
            get { return _soundRating; }
            set
            {
                // Validate the sound rating value
                string uppercaseValue = value.ToUpper(); // Convert the input value to uppercase
                if (uppercaseValue == "QT" || uppercaseValue == "QR" || uppercaseValue == "QU" || uppercaseValue == "M")
                {
                    _soundRating = uppercaseValue; // Assign the uppercase value to the private field
                }
            }
        }

                // Public property to get the human-readable display of sound rating
        public string SoundRatingDisplay
        {
            get
            {
                // Return the corresponding display text based on the sound rating code
                if (_soundRating == "QT")
                {
                    return "Quietest";
                }
                else if (_soundRating == "QR")
                {
                    return "Quieter";
                }
                else if (_soundRating == "QU")
                {
                    return "Quiet";
                }
                else if (_soundRating == "M")
                {
                    return "Moderate";
                }
                else
                {
                    return "Unknown"; 
                }
            }
        }

        // Public properties to provide constant values for different sound ratings
        public string SoundRatingModerate => "M";
        public string SoundRatingQT => "QT";
        public string SoundRatingQR => "QR";
        public string SoundRatingQU => "QU";

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
            base.ToString();
        
            return
                   $"Sound Rating: {SoundRatingDisplay}\n" +
                   $"Feature: {Feature}\n";
        }

        // Method to format dishwasher details for file output
        public string FormatForFile()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Feature};{SoundRating};";
        }
    }
}
