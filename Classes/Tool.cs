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
        public int AvailableQuantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Member MemberBorrowing { get; set; }

        // how many people have borrowed it not how many are currently 
        public int NoBorrowings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public MemberCollection GetBorrowers => throw new NotImplementedException();


        public Tool(string name, int quantity, int[] toolType )
        {
            this.Name = name;
            this.Quantity = quantity;
            this.ToolType = ToolType;
        }

        public void addBorrower(Member member)
        {
            this.MemberBorrowing = member;
            AvailableQuantity --;
            NoBorrowings ++;
        }

        public void deleteBorrower(Member Member)
        {

        }

        public override string ToString()
        {
            //return a string containning the name and the available quantity quantity this tool 
            return "";

        }
    }
}
