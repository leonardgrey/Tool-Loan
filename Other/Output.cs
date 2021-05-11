using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolLoan;

namespace ToolLoan.Classes
{
    class Output
    {
        GlobalVariables vars = new GlobalVariables();
        Helper helpers = new Helper();

        public string WelcomeScreen() { return "Welcome to the Tool Library"; }
        public string MenuOption(string menu = "") { return $"=============={menu}=============="; }


        // return the index of the select category and tool type
        // for selecting a tool type for later use
        public int[] SelectToolType()
        {
            Console.WriteLine("\n\nPlease select the tool category and type\n");
            // get the category index
            for (int i = 1; i < vars.ToolCategories.Length+1; i++)
            {
                Console.WriteLine($"{i}. {vars.ToolCategories[i-1]}");
            }

            Console.WriteLine("\nPlease make a selection: ");
            int SelectedCategoryIndex = Int32.Parse(Console.ReadLine())-1;
            Console.WriteLine("\n");

            // get the tool type index
            var RowValue = helpers.GetRow(vars.ToolTypes, SelectedCategoryIndex);

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

    }
}
