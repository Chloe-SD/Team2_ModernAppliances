using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_ModernAppliances.Entities
{
    internal class Dishwasher:Appliance
    {
        private string SoundRating { get; set; }
        private string Feature { get; set; }
        private string SoundRatingDisplay { get; set; }
       

        // Constructor to initialize the Dishwasher object
        public Dishwasher(string itemNumber, string brand, int quantity, string wattage, string color, double price, string soundRating, string feature)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.SoundRating = soundRating; // Set the sound rating
            this.Feature = feature; // Set the feature
            this.SoundRatingDisplay = GetSoundRatingDisplay(soundRating); // get readable rating through method

        }
        
        public string GetSoundRatingDisplay(string soundRating)
        {
            // Public property to get the human-readable display of sound rating
            {
                // Return the corresponding display text based on the sound rating code
                if (soundRating == "Qt")
                {
                    return "Quietest";
                }
                else if (soundRating == "Qr")
                {
                    return "Quieter";
                }
                else if (soundRating == "Qu")
                {
                    return "Quiet";
                }
                else if (soundRating == "M")
                {
                    return "Moderate";
                }
                else
                {
                    return "Unknown";
                }
            }
        }

        public string GetSoundRatingDisplay()
        {
            return this.SoundRatingDisplay;
        }

        // Override ToString method to provide a string representation of the Dishwasher object
        public override string ToString()
        {
            return $"{base.ToString()}" +
                   $"Sound Rating: {SoundRatingDisplay}\n" +
                   $"Feature: {Feature}";
        }

        // Method to format dishwasher details for file output
        public override string FormatForFile()
        {
            return $"{this.ItemNumber};{this.Brand};{this.Quantity};{this.Wattage};{this.Colour};{this.Price};{this.Feature};{this.SoundRating};";
        }
    }
}
