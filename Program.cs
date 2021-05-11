using System;
using System.Collections.Generic;
using ToolLoan.Classes;

namespace ToolLoan
{
    class Program
    {
        Output Outputs = new Output();

        static void Main(string[] args)
        {
            GlobalVariables globalVars = new GlobalVariables();




            ToolSelectionTest();
        }

        private void TestResize()
        {
            Tool Tool = new Tool("Tool name 1", 1, new[] {1, 1 });

            ToolCollection ToolCollection = new ToolCollection();
            Console.WriteLine(ToolCollection.CollectionOfTools.Length);

            ToolCollection.ResizeArray(ToolCollection.CollectionOfTools);
            Console.WriteLine(ToolCollection.CollectionOfTools.Length);

            ToolCollection.ResizeArray(ToolCollection.CollectionOfTools);
            Console.WriteLine(ToolCollection.CollectionOfTools.Length);

            ToolCollection.ResizeArray(ToolCollection.CollectionOfTools);
            Console.WriteLine(ToolCollection.CollectionOfTools.Length);

            ToolCollection.ResizeArray(ToolCollection.CollectionOfTools);
            Console.WriteLine(ToolCollection.CollectionOfTools.Length);
        }

        public static void ToolSelectionTest()
        {
            Output Outputs = new Output();
            GlobalVariables vars = new GlobalVariables();
            var i = Outputs.SelectTool();
            Console.WriteLine(vars.ToolCategories[i[0]]);
            Console.WriteLine(vars.ToolTypes[i[0], i[1]]);

        }

        public static void TestEqual()
        {
            Tool tool1 = new Tool("number1", 1, new[] {1, 1 }) {};
            Tool tool2 = new Tool("number2", 1, new[] { 1, 1 }) { };
            //Console.WriteLine(tool1.Name);

            ToolCollection Collect = new ToolCollection() { };

            Collect.add(tool1);
            Collect.add(tool2);

            Console.WriteLine(Collect.search(tool1));
            Console.WriteLine(Collect.search(tool2));

            Collect.delete(tool2);

            Console.WriteLine(Collect.search(tool1));
            Console.WriteLine(Collect.search(tool2));

        }
    }
}
