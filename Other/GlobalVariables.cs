using System.Collections.Generic;
using System;
using System.Text;

namespace ToolLoan
{
    class GlobalVariables
    {
        // 0 = guest. 1 = staff. 2 = member
        public int CurrentUser { get; set; }


        public Dictionary<int, string> toolCategories = new Dictionary<int, string> { 
            { 1, "Gardening" }, 
            { 2, "Flooring" },
            { 3, "Fencing"},
            { 4, "Measuring"},
            { 5, "Cleaning"},
            { 6, "Painting"},
            { 7, "Electronic"},
            { 8, "Electricity"},
            { 9, "Automotive"},
        };

        public string[] ToolCategories { get; set; }
        public string[,] ToolTypes { get; set; }

        public GlobalVariables()
        {
            CurrentUser = 0;

            this.ToolCategories = new string[9] { toolCategories[1], toolCategories[2], toolCategories[3], toolCategories[4], toolCategories[5], toolCategories[6], toolCategories[7], toolCategories[8], toolCategories[9] };
            this.ToolTypes = new string[9, 6] {
                { "Line trimmer", "Lawn mower", "Hand tool", "Wheel barrow", "Power tool", "", },
                { "Scraper", "Laser", "Levelling tool", "Levelling material", "Hand ", "Tiling", },
                { "Hand", "Electric", "Steel fencing", "Power", "Fencing accessories", "", },
                { "Distance", "Laser measurer", "Temp & Humidity", "Levelling", "Markers", "", },
                { "Draining", "Car", "Vacuum", "Pressure", "Pool", "Floor", },
                { "Sanding", "Brushes", "Rollers", "Paint removal", "Paint Scrapers", "Sprayers", },
                { "Voltage tester", "Oscilloscopes", "Thermal imaging", "Data test", "Insulation tester", "", },
                { "Test", "Safety", "Basic Hand", "Circuit protection", "Cable tool", "", },
                { "Jacks", "Air compressors", "Battery charger", "Socket tool", "Braking", "", }
            };
        }


    }
}
