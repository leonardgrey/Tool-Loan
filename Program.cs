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

            var t = CreateTool();
            Console.WriteLine("");

        }

        

        public static Tool CreateTool()
        {
            //TODO: add member to tool
            Output Outputs = new Output();
            var userToolInput = Outputs.GetNewToolInfo();
            Tool resultTool = new Tool((string)userToolInput[0], (int)userToolInput[1], (int[])userToolInput[2]);

            return resultTool;
        }

        
    }
}
