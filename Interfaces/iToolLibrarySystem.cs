using System;
using System.Collections.Generic;
using System.Text;
using Assignment;
using Interfaces;
using ToolLoan;

namespace Interfaces
{
    interface iToolLibrarySystem
    {
        void add(Tool tool); // add a new tool to the system

        void add(Tool tool, int amountOfPieces); //add new pieces of an existing tool to the system

        void delete(Tool tool); //delte a given tool from the system

        void delete(Tool tool, int amountOfPieces); //remove some pieces of a tool from the system

        void add(Member member); //add a new memeber to the system

        void delete(Member tool); //delete a member from the system

        void display(string contactNumber); //given the contact phone number of a member, display all the tools that the member are currently renting

        void displayTools(int[] toolType); // display all the tools of a tool type selected by a member

        void borrowTool(Member member, Tool tool); //a member borrows a tool from the tool library

        void returnTool(Member member, Tool tool); //a member return a tool to the tool library

        void listRentedTools(Member member); //get a list of tools that are currently held by a given member

        void displayTopThree(); //Display top three most frequently borrowed tools by the members in the descending order by the number of times each tool has been borrowed.


    }
}
