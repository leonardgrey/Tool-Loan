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

        const string lineBreak = "============================================================================================";

        public Output(ToolLibrarySystem t, GlobalVariables v)
        {
            this.ToolLibrarySystem = t;
            this.Vars = v;
        }

        public void WelcomeScreen() { Console.WriteLine("Welcome to the Tool Library"); }

        public void MenuOption(string menu = "Main menu") { Console.WriteLine($"=============={menu}=============="); }
        public int ChooseMenu()
        {
            Console.WriteLine(lineBreak);
            //TODO: fix/change this 
            Console.WriteLine("1. Staff Login \n2. Member Login \n0. Exit\n" + lineBreak);
            if (Console.ReadLine() == "1")
            {
                return 1;
            }
            else if (Console.ReadLine() == "2")
            {
                return 2;
            }
            else
            {
                return 0;
            }

        }

        public void StaffMenu()
        {
            Console.Clear();
            Console.WriteLine(lineBreak);
            Console.WriteLine( lineBreak.Substring(0, lineBreak.Length/2-5) +  "Staff menu" + lineBreak.Substring(0, lineBreak.Length / 2 - 4));
        }

        public void MemberMenu()
        {
            Console.Clear();
            Console.WriteLine(lineBreak);
            Console.WriteLine(lineBreak.Substring(0, lineBreak.Length / 2 - 10) + "Member menu" + lineBreak.Substring(0, lineBreak.Length / 2 - 10));
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

        public int[] BrowseTools()
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
                    Console.WriteLine($"\nPlease enter a valid number between 0 & {this.Vars.ToolCategories.Length}");
                    //Console.WriteLine("Please make a selection: ");
                    selectedCategoryIndex = Int32.Parse(Console.ReadLine()) - 1;
                }
            }
            Console.WriteLine(lineBreak);

            // display all the tools in that list
            
            if (categoryItems.Length > 0)
            {
                String s = String.Format("{0, -37} {1, -20} {2, -30}\n\n", "Tool Name", "Available", "Quantity");
                for (int i = 0; i < categoryItems.Length; i++)
                {
                    s += String.Format("{0, -40} {1, -20} {2, -30}\n", $"{i + 1}. {categoryItems[i].Name}", categoryItems[i].AvailableQuantity, categoryItems[i].Quantity);
                }
                Console.WriteLine($"\n{s}");
            }
            else
            {
                Console.WriteLine($"There are no tools inside category {Vars.ToolCategories[selectedCategoryIndex]}");
            }


            // get user input
            var chosenToolIndex = Int32.Parse(Console.ReadLine());

            int[] resultIndex = new int[] { selectedCategoryIndex, chosenToolIndex };
            return resultIndex;

        }

        public bool LoginMember(ToolLibrarySystem system)
        {
            // print out asking for information
            // use the search function inside member collection to return a boolean
            // repeat until it returns a true value.

            Boolean loggedIn = false;

            while (!loggedIn)
            {
                Console.Clear();
                Console.WriteLine("Username: ");
                string usernameInput = Console.ReadLine();

                Console.WriteLine("\nPasscode: ");
                string passcodeInput = Console.ReadLine();

                // search for member with that login
                Member mem = new Member("Leo", "Grey", "0421158333", "1234") { };
                if (system.MemberCollection.search(mem))
                {
                    Console.Clear();
                    loggedIn = true;
                    return true;
                }

                //TODO get whether the user is member or staff

            }
            return false;

        }

        public bool LoginStaff()
        {
            Boolean loggedIn = false;

            while (!loggedIn)
            {
                Console.WriteLine("\n\nUsername: ");
                string usernameInput = Console.ReadLine();

                Console.WriteLine("\nPasscode: ");
                string passcodeInput = Console.ReadLine();

                if (ValidateStaff(usernameInput, passcodeInput))
                {
                    return true;
                }

                Console.WriteLine("Incorrect login details, please try again.");
            }
            return false;
        }

        public bool ValidateStaff(string username, string passcode)
        {
            string staffUsername = "1";
            string staffPasscode = "1";

            if (staffUsername == username && staffPasscode == passcode)
            {
                return true;
            }

            return false;
        }


    }
}
