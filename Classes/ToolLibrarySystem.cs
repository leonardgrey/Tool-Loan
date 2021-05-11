using Assignment;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLoan.Classes
{
    class ToolLibrarySystem : iToolLibrarySystem
    {

        public List<ToolCollection> ToolCollections { get; set; }

        GlobalVariables vars = new GlobalVariables();
        public ToolLibrarySystem()
        {
            CreateToolCollections();


        }



        public void add(Tool tool)
        {
            throw new NotImplementedException();
        }

        public void add(Tool tool, int amountOfPieces)
        {
            throw new NotImplementedException();
        }

        public void add(Member tool)
        {
            throw new NotImplementedException();
        }

        public void borrowTool(Member member, Tool tool)
        {
            throw new NotImplementedException();
        }

        public void delete(Tool tool)
        {
            throw new NotImplementedException();
        }

        public void delete(Tool tool, int amountOfPieces)
        {
            throw new NotImplementedException();
        }

        public void delete(Member tool)
        {
            throw new NotImplementedException();
        }

        public void display(string toolType)
        {
            throw new NotImplementedException();
        }

        public void displayTools(string toolType)
        {
            throw new NotImplementedException();
        }

        public void displayTopThree()
        {
            throw new NotImplementedException();
        }

        public string[] listTools(Member member)
        {
            throw new NotImplementedException();
        }

        public void returnTool(Member member, Tool tool)
        {
            throw new NotImplementedException();
        }

        public void CreateToolCollections()
        {
            ToolCollection gardeningTools = new ToolCollection();
            ToolCollections.Add(gardeningTools);
            ToolCollection flooringTools = new ToolCollection();
            ToolCollections.Add(flooringTools);
            ToolCollection fencingTools = new ToolCollection();
            ToolCollections.Add(fencingTools);
            ToolCollection measuringTools = new ToolCollection();
            ToolCollections.Add(measuringTools);
            ToolCollection cleaningTools = new ToolCollection();
            ToolCollections.Add(cleaningTools);
            ToolCollection paintingTools = new ToolCollection();
            ToolCollections.Add(paintingTools);
            ToolCollection electronicTools = new ToolCollection();
            ToolCollections.Add(electronicTools);
            ToolCollection electrictyTools = new ToolCollection();
            ToolCollections.Add(electronicTools);
            ToolCollection autoMotiveTools = new ToolCollection();
            ToolCollections.Add(autoMotiveTools);
        }
    }
}
