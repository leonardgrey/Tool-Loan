using System;
using System.Collections.Generic;
using ToolLoan.Classes;

namespace ToolLoan
{
    class Program
    {
        static void Main(string[] args)
        {
            MemberCollection memberCollection = new MemberCollection();
            AddMembers(memberCollection);
            ToolLibrarySystem librarySystem = new ToolLibrarySystem(memberCollection);
            GlobalVariables vars = new GlobalVariables();
            Output outputs = new Output(librarySystem, vars);


            MainTest(outputs, librarySystem);

        }

        public static void AddMembers(MemberCollection memColl)
        {
            Member mem = new Member("1", "1la", "111111111", "1111") { };
            Member mem2 = new Member("2", "2la", "2222222222", "2222") { };
            Member mem3 = new Member("3", "3la", "3333333333", "3333") { };
            memColl.add(mem);
            memColl.add(mem2);
            memColl.add(mem3);
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

        public static void CreateSingleTool(Output outputs, ToolLibrarySystem systen)
        {
            //TODO: add member to tool
            var userToolInput = outputs.GetNewToolInfo();
            Tool resultTool = new Tool((string)userToolInput[0], (int)userToolInput[1], (int[])userToolInput[2]);

            systen.add(resultTool);
        }

        public static void CreateMultipleTool(Output outputs, ToolLibrarySystem systen)
        {

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
