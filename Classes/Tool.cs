using Assignment;
using System;
using System.Collections.Generic;
using System.Text;
using ToolLoan.Classes;

namespace ToolLoan
{
    class Tool : iTool
    {
        public int[] ToolType { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }

        // how many people have borrowed it not how many are currently 
        public int NoBorrowings { get; set; }

        // probs wont use this
        public MemberCollection GetBorrowers { get; set; }


        public Tool(string name, int quantity, int[] toolType)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.ToolType = toolType;

            this.AvailableQuantity = quantity;
            this.NoBorrowings = 0;
        }

        // DIDNT NEED THIS
        public void addBorrower(Member member)
        {
            // this.MemberBorrowing = member;

        }

        // DIDNT NEED THIS
        public void deleteBorrower(Member Member)
        {

        }

        public override string ToString()
        {
            //return a string containning the name and the available quantity quantity this tool 
            return $"{this.Name}: {this.AvailableQuantity}";

        }
    }
}


