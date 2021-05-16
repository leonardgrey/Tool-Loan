using System;
using System.Collections.Generic;
using ToolLoan.Classes;

namespace ToolLoan
{
    class Program
    {
        static void Main(string[] args)
        {
            ToolLibrarySystem librarySystem = new ToolLibrarySystem();
            GlobalVariables vars = new GlobalVariables();
            Output outputs = new Output(librarySystem, vars);


            MainTest(outputs, librarySystem);

        }

        public static void MainTest(Output outputs, ToolLibrarySystem system)
        {
            var menu = outputs.ChooseMenu();
            if (menu == 1)
            {
                outputs.LoginStaff();
                outputs.StaffMenu();
            }
            else if (menu == 2)
            {
                outputs.LoginMember(system);
                outputs.MemberMenu();
            }

        }

        public static Tool CreateTool(Output outputs)
        {
            //TODO: add member to tool
            var userToolInput = outputs.GetNewToolInfo();
            Tool resultTool = new Tool((string)userToolInput[0], (int)userToolInput[1], (int[])userToolInput[2]);

            return resultTool;
        }

        public static void MemberBorrowsTool(Output outputs, ToolLibrarySystem system)
        {
            var toolIndex = outputs.BrowseTools();

            // TODO: add member to this
            Member mem = new Member("Leo", "Grey", "0421158333", "1234");

            ToolCollection t = system.ToolCollections[toolIndex[0]];
            Tool resultTool = t.CollectionOfTools[toolIndex[1]];

            system.borrowTool(mem, resultTool);

        }

    }
}
