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
        public ToolCategoriesTypes Vars { get; set; }

        const string lineBreak = "=====================================================";

        public Output(ToolLibrarySystem t, ToolCategoriesTypes v)
        {
            this.ToolLibrarySystem = t;
            this.Vars = v;
        }

        public void WelcomeScreen() { Console.WriteLine("Welcome to the Tool Library"); }

        public void MenuOption(string menu = "Main menu") { Console.WriteLine($"=============={menu}=============="); }
        public int LoggedOut()
        {
            Console.WriteLine(lineBreak);
            //TODO: fix/change this 
            Console.WriteLine("1. Staff Login \n2. Member Login \n0. Exit\n" + lineBreak);
            var t = Console.ReadLine();
            if (t == "1")
            {
                return 1;
            }
            else if (t == "2")
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        public int StaffMenu()
        {
            List<string> options = new List<string>() { 
                "Add a new tool", 
                "Add new pieces of an existing tool", 
                "Remove some pieces of a tool", 
                "Register a new member", 
                "Remove a member", 
                "Find the contact number of a member" 
            };

            Console.Clear();
            Console.WriteLine(lineBreak.Substring(0, lineBreak.Length/2-5) +  "Staff menu" + lineBreak.Substring(0, lineBreak.Length / 2 - 4));

            // print all the options available and return the user input
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i+1}. {options[i]}");
            }
            Console.WriteLine("0. Return to main menu");

            Console.WriteLine(lineBreak + "\nPlease select an option\n");

            return Int32.Parse(Console.ReadLine());
        }

        public int MemberMenu()
        {
            List<string> options = new List<string>() {
                "Display all the tools of a tool type",
                "Borrow a tool",
                "Return a tool",
                "List all the tools that I am renting",
                "Display top 3 most frequentely rented tools"
            };

            Console.Clear();
            Console.WriteLine(lineBreak.Substring(0, lineBreak.Length / 2 - 4) + "Member menu" + lineBreak.Substring(0, lineBreak.Length / 2 - 6));

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i+1}. {options[i]}");
            }
            Console.WriteLine("0. Return to main menu");

            Console.WriteLine(lineBreak + "\nPlease select an option\n");

            return Int32.Parse(Console.ReadLine());
        }


        // TOOL PART OF CONSOLE
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

        public Tool GetNewToolInfo()
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
            Tool resultTool = new Tool((string)returnResult[0], (int)returnResult[1], (int[])returnResult[2]);
            return resultTool;
        }

        public int[] GetToolCategory()
        {
            Tool[] categoryItems = null;
            int selectedCategoryIndex = -1;
            Console.Clear();
            // user chooses category
            Console.WriteLine("\nPlease select the tool category\n");
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
            return new int[] { selectedCategoryIndex, 0 };
        }

        public int[] SelectTool(ToolLibrarySystem system, int[] category)
        {
            Console.WriteLine("Please select a tool");
            // get user input
            var chosenToolIndex = Int32.Parse(Console.ReadLine()) - 1;
            
            int[] resultIndex = new int[] { category[0], chosenToolIndex };
            return resultIndex;
        }
        
        public int GetNewToolInforMultiple()
        {
            int quantity = -1;
            while (quantity < 0)
            {
                Console.WriteLine("Quantity of tools");
                quantity = Int32.Parse(Console.ReadLine());
            }

            return quantity;
        }

        public Member CreateNewMember()
        {
            // ask for name, last, number, pin
            Console.WriteLine("Please enter members first name");
            var fName = Console.ReadLine();
            Console.WriteLine("Please enter members last name");
            var lName = Console.ReadLine();
            Console.WriteLine("Please enter members number");
            var number = Console.ReadLine();
            Console.WriteLine("Please enter members PIN");
            var pin = Console.ReadLine();

            Member resultMem = new Member(fName, lName, number, pin) { };

            return resultMem;
        }

        public Member DeleteMember(ToolLibrarySystem system)
        {
            Console.Clear();
            Console.WriteLine("Heres a list of all members");
            Console.WriteLine(lineBreak);
            String s = String.Format("{0, -40} {1, -20}\n\n", "Name", "Username");

            foreach (var item in system.MemberCollection.toArray())
            {
                s += String.Format("{0, -40} {1, -20}\n", $"{item.FirstName} {item.LastName}", item.Username);
            }
            Console.WriteLine($"{s}");
            Console.WriteLine(lineBreak);

            Console.WriteLine("Enter username of member to delete");
            var usernameInput = Console.ReadLine();

            Member mem = system.MemberCollection.FindMember(usernameInput, true);

            return mem;
        }

        public void GetPhoneNumber(ToolLibrarySystem system)
        { 
            Console.Clear();
            Console.WriteLine("Heres a list of all members");
            Console.WriteLine(lineBreak);
            String s = String.Format("{0, -40} {1, -20}\n\n", "Name", "Number");

            foreach (var item in system.MemberCollection.toArray())
            {
                s += String.Format("{0, -40} {1, -20}\n", $"{item.FirstName} {item.LastName}", item.ContactNumber);
            }
            Console.WriteLine($"{s}");
            Console.WriteLine(lineBreak);
        }

        // // // //

        // LOGIN PART OF CONSOLE //
        public bool LoginMember(ToolLibrarySystem system)
        {
            Boolean loggedIn = false;

            while (!loggedIn)
            {
                Console.WriteLine("Username: ");
                string usernameInput = Console.ReadLine();

                Console.WriteLine("\nPasscode: ");
                string passcodeInput = Console.ReadLine();

                // search for member with that login
                Member mem = system.MemberCollection.FindMember(usernameInput, passcode:passcodeInput) ;
                system.CurrentUser = mem;
                if (system.MemberCollection.search(mem))
                {
                    Console.Clear();
                    return true;
                }
                Console.WriteLine("Incorrect login details");
                Console.WriteLine(lineBreak + "\n");
                // TODO: validate the member 
            }
            return false;
        }

        public bool LoginStaff()
        {
            Boolean loggedIn = false;

            while (!loggedIn)
            {
                Console.WriteLine("Username: ");
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
        // // // // 

    }
}
