using Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolLoan.Classes;

namespace ToolLoan
{
    class ToolCollection : iToolCollection
    {
        private Tool[] CollectionOfTools { get; set; }
        public int Number { get; set; }

        public ToolCollection()
        {
            this.CollectionOfTools = new Tool[0];
            this.Number = 0;

        }

        public void add(Tool tool)
        {
            try
            {
                ResizeArray(this.CollectionOfTools);
                this.CollectionOfTools[this.Number] = tool;
                this.Number++;
            }
            catch (Exception)
            { 

            }
        }
      
        public void delete(Tool tool)
        {
            this.CollectionOfTools = this.CollectionOfTools.Where(val => val != tool).ToArray();
            Console.WriteLine("Tool has been deleted");
            Console.ReadLine();
        }

        public bool search(Tool tool)
        {
            if (this.CollectionOfTools.Contains(tool))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Tool[] toArray()
        {
            return this.CollectionOfTools;
        }

        public Tool FindTool(Tool tool)
        {
            foreach (var item in toArray())
            {
                if (item.Name == tool.Name)
                {
                    return item;
                }
            }
            return null;
        }


        private void ResizeArray(Tool[] arrayToResize)
        {
            Tool[] TempArray = new Tool[arrayToResize.Length+1];
            for (int i = 0; i < arrayToResize.Length; i++)
            {
                TempArray[i] = arrayToResize[i];
            }
            this.CollectionOfTools = TempArray;
        }

    }
}
