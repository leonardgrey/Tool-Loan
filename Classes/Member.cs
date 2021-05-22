using Assignment;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ToolLoan
{
    class Member : iMember, IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string PIN { get; set; }
        public string Username {
            get 
            {
                return $"{this.LastName.ToUpper()}{this.FirstName.ToUpper()}";
            }
            set { } 
        }

        // CHANGE FROM string[] TO List<Tool>
        public List<Tool> Tools { get; set; }

        public int NumOfTools { get { return this.Tools.Count; } set { } }

        public Member(string fName, string lName, string number, string pin)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.ContactNumber = number;
            this.PIN = pin;

            NumOfTools = 0;
            this.Tools = new List<Tool>();
        }

        public void addTool(Tool tool)
        {
            // cant have more than 3 tools loaned

            // check if the number of tool the person has is less than 3
            // add the tool into the Tools array
            if (this.NumOfTools < 3)
            {
                if (tool.AvailableQuantity > 0)
                {
                    this.Tools.Add(tool);

                    tool.AvailableQuantity--;
                    tool.NoBorrowings++;
                }
                else
                {
                    Console.WriteLine("Tool is out of stock");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Cannot borrow more than 3 tools");
                Console.ReadLine();
            }

        }

        public void deleteTool(Tool tool)
        {
            throw new NotImplementedException();
        }

        public string TpString()
        {
            throw new NotImplementedException();
        }

        public override string ToString() 
        {
            //return a string containing the first name, lastname, and contact phone number of this memeber
            return $"{this.FirstName} {this.LastName}, {this.ContactNumber}";
        }

        public int CompareTo(object obj)
        {
            Member t = (Member)obj;
            return Username.CompareTo(t.Username);
        }

    }
}
