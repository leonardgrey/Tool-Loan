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
        public Tool[] CollectionOfTools { get; set; }
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
                throw;
            }
        }
      
        public void delete(Tool tool)
        {
            this.CollectionOfTools = this.CollectionOfTools.Where(val => val != tool).ToArray();
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


        public void ResizeArray(Tool[] arrayToResize)
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
