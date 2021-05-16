﻿using System.Collections.Generic;
using System;
using System.Text;

namespace ToolLoan
{
    class GlobalVariables
    {
        // 0 = guest. 1 = staff. 2 = member
        public Member CurrentUser { get; set; }


        public string[] ToolCategories { get; set; }
        public string[,] ToolTypes { get; set; }

        public GlobalVariables()
        {
            CurrentUser = null;

            this.ToolCategories = new string[9] { "Gardening", "Flooring", "Fencing", "Measuring", "Cleaning", "Painting", "Electronic", "Electricity", "Automotive", };
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
