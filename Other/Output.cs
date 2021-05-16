using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolLoan;

namespace ToolLoan.Classes
{
    class Output
    {
        public ToolLibrarySystem ToolLibrarySystem { get; set; }
        public GlobalVariables Vars { get; set; }

        public Output(ToolLibrarySystem t, GlobalVariables v)
        {
            this.ToolLibrarySystem = t;
            this.Vars = v;
        }

        public void WelcomeScreen() { Console.WriteLine("Welcome to the Tool Library"); }

        public void MenuOption(string menu = "Main menu") { Console.WriteLine($"=============={menu}=============="); }
        public string ChooseMenu()
        {
            Console.WriteLine("1. Staff login \n2. Member login \n0. Exit");
            switch (Console.ReadLine())
            {   
                case "1":
                    return "Staff menu";
                case "2":
                    return "Member menu";
                case "0":
                    return "";
            }

            return "";
        }


        // return the index of the select category and tool type
        // for selecting a tool type for later use
        public int[] SelectToolType()
        {
            Console.WriteLine("\n\nPlease select the tool category\n");
            // get the category index
            for (int i = 1; i < this.Vars.ToolCategories.Length+1; i++)
            {
                Console.WriteLine($"{i}. {this.Vars.ToolCategories[i-1]}");
            }

            Console.WriteLine("\nPlease make a selection: "); 
            int SelectedCategoryIndex = Int32.Parse(Console.ReadLine())-1;
            Console.WriteLine("\n");

            Helper helpers = new Helper();
            // get the tool type index
            Console.WriteLine("Please select the tool Type\n");
            var RowValue = helpers.GetRow(this.Vars.ToolTypes, SelectedCategoryIndex);

            for (int i = 0; i < RowValue.Length; i++)
            {
                if (RowValue[i] != "")
                {
                    Console.WriteLine($"{i + 1}. {RowValue[i]}");
                }
            }
            Console.WriteLine("\nPlease make a selection: ");
            int SelectedTypeIndex = Int32.Parse(Console.ReadLine())-1;
            Console.WriteLine("\n");

            // return the category index and type index
            int[] ReturnValue = new int[2] { SelectedCategoryIndex, SelectedTypeIndex };
            return ReturnValue;
        }

        public Object[] GetNewToolInfo()
        {
            // print the output for adding a tool and get the input of the user
            // name, quantity, tool type
            // return it as an array

            Console.WriteLine("Enter tool name: ");
            string name = Console.ReadLine();

            int quantity = -1;

            while (quantity < 0)
            {
                try
                {
                    Console.WriteLine("\nEnter tool quantity: ");
                    quantity = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number!");
                }
            }

            int[] toolType = SelectToolType();

            Object[] returnResult = new object[] { name, quantity, toolType };
            return returnResult;
        }

        public void BrowseTools()
        {
            Tool[] categoryItems = null;
            int selectedCategoryIndex = -1;

            // user chooses category
            Console.WriteLine("\n\nPlease select the tool category\n");
            for (int i = 1; i < this.Vars.ToolCategories.Length + 1; i++)
            {
                Console.WriteLine($"{i}. {this.Vars.ToolCategories[i - 1]}");
            }

            // user select a number
            while (categoryItems == null)
            {
                try
                {
                    categoryItems = this.ToolLibrarySystem.ToolCollections[selectedCategoryIndex].toArray();
                }
                catch (Exception)
                {
                    Console.WriteLine($"Please enter a valid number between 0 & {this.Vars.ToolCategories.Length}");
                    Console.WriteLine("\nPlease make a selection: ");
                    selectedCategoryIndex = Int32.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("\n");
                }
            }

            // display all the tools in that list
            String s = String.Format("{0, -37} {1, -20} {2, -30}\n\n", "Tool Name", "Available", "Quantity");
            for (int i = 0; i < categoryItems.Length; i++)
            {
                s += String.Format("{0, -40} {1, -20} {2, -30}\n", $"{i+1}. {categoryItems[i].Name}", categoryItems[i].AvailableQuantity, categoryItems[i].Quantity);
            }
            Console.WriteLine($"\n{s}");

            //TODO: confirm it

            // get user input
            var chosenToolIndex = Int32.Parse(Console.ReadLine());

            int[] resultIndex = new int[] { 0, 0 };

            // return a tool
        }

    }
}
