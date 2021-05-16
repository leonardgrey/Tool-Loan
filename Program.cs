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




            MainTest(outputs);
        }

        public static void MainTest(Output outputs)
        {
            //outputs.WelcomeScreen();
            //outputs.MenuOption();
            //outputs.ChooseMenu();
            outputs.BrowseTools();
   
        }
        public static Tool CreateTool(Output outputs)
        {
            //TODO: add member to tool
            var userToolInput = outputs.GetNewToolInfo();
            Tool resultTool = new Tool((string)userToolInput[0], (int)userToolInput[1], (int[])userToolInput[2]);

            return resultTool;
        }

    }
}
