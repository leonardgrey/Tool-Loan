using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLoan
{
    class Member : iMember
    {
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContactNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PIN { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string[] Tools => throw new NotImplementedException();

        public int NumOfTools { get; set; }

        public Member(string fName, string lName, string number, string pin)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.ContactNumber = number;
            this.PIN = pin;

            NumOfTools = 0;
        }

        public void addTool(Tool tool)
        {
            // cant have more than 3 tools loaned

            if (this.NumOfTools < 3)
            {

            }

            throw new NotImplementedException();
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
