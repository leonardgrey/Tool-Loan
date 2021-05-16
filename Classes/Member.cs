using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLoan
{
    class Member : iMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string PIN { get; set; }
        
        // CHANGE FROM string[] TO List<Tool>
        public List<Tool> Tools { get; set; }
        public int NumOfTools { get; set; }
        // public int NumOfTools { get => this.Tools.Count; set => NumOfTools = value; }

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

            //TODO add console outputs 
            if (this.Tools.Count < 3)
            {
                this.Tools.Add(tool);
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
            return "";
        }
    }
}
