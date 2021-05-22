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
        public MemberCollection MemberCollection { get; set; }

        public Member CurrentUser { get; set; }

        string lineBreak = "=====================================================";
        public ToolLibrarySystem(MemberCollection memberCollection)
        {
            this.ToolCollections = new List<ToolCollection>();
            this.MemberCollection = memberCollection;
            this.CurrentUser = null;

            CreateToolCollections();
            TempTools();
        }

        public void add(Tool tool)
        {
            var collection = this.ToolCollections[tool.ToolType[0]];
            Tool rTool = collection.FindTool(tool);

            if (this.ToolCollections[tool.ToolType[0]].search(rTool))
            {
                Console.WriteLine("Tool already exists");
                Console.ReadLine();
            }
            else
            {
                this.ToolCollections[tool.ToolType[0]].add(tool);
                Console.WriteLine("Tool was added to system");
                Console.ReadLine();
            }


        }

        public void add(Tool tool, int amountOfPieces)
        {
            // find the index of the tool within the toolcollection
            var toolCatIndex = tool.ToolType[0];
            var toolCollectionArray = this.ToolCollections[toolCatIndex].toArray();
            var toolIndex = Array.IndexOf(toolCollectionArray, tool);


            if (this.ToolCollections[toolCatIndex].search(tool))
            {
                this.ToolCollections[toolCatIndex].toArray()[toolIndex].AvailableQuantity += amountOfPieces;
                this.ToolCollections[toolCatIndex].toArray()[toolIndex].Quantity += amountOfPieces;
            }
            else
            {
                this.ToolCollections[toolCatIndex].add(tool);
            }
        }

        public void add(Member member)
        {
            this.MemberCollection.add(member);
        }

        public void borrowTool(Member member, Tool tool)
        {
            try
            {
                // call addTool from Member
                member.addTool(tool);
                // call addBorrower from Tool
                tool.addBorrower(member);
            }
            catch (Exception)
            {
                Console.WriteLine("Press enter...");
                Console.ReadLine();
            }

        }

        public void delete(Tool tool)
        {
            this.ToolCollections[tool.ToolType[0]].delete(tool);
        }

        public void delete(Tool tool, int amountOfPieces)
        {
            throw new NotImplementedException();
        }

        public void delete(Member member)
        {
            this.MemberCollection.delete(member);
        }

        public void display(string contactNumber)
        {
            // find the member where contactNumber matches
            // display the members Tools

            Member mem = this.MemberCollection.FindMember(number:contactNumber);

            if (mem != null)
            {
                Console.WriteLine(lineBreak);
                if (mem.Tools.Count > 0)
                {
                    String s = String.Format("{0, -60}\n\n", "Tool Name", "Available", "Quantity");
                    for (int i = 0; i < mem.Tools.Count; i++)
                    {
                        s += String.Format("{0, -60} ", $"{i + 1}. {mem.Tools[i].Name}");
                        s += "\n";
                    }
                    Console.WriteLine($"{s}");
                }
                else
                {
                    Console.WriteLine($"Currently borrowing no tools");
                }
                Console.WriteLine(lineBreak);
            }
            else
            {
                Console.WriteLine("Member with that number doesn't exist");
                Console.ReadLine();
            }

            Console.ReadLine();


        }

        public void displayTools(int[] toolType)
        {
            ToolCategoriesTypes Vars = new ToolCategoriesTypes();
            // get toolcollection then sort by tool type and get the tooltypes
            var categoryItems = this.ToolCollections[toolType[0]].toArray();
            string lineBreak = "======================================================================";

            Console.WriteLine(lineBreak);
            if (categoryItems.Length > 0)
            {
                String s = String.Format("{0, -50} {1, -10} {2, -30}\n\n", "Tool Name", "Available", "Quantity");
                for (int i = 0; i < categoryItems.Length; i++)
                {
                    s += String.Format("{0, -50} {1, -10} {2, -30}", $"{i + 1}. {categoryItems[i].Name}", categoryItems[i].AvailableQuantity, categoryItems[i].Quantity);
                    s += "\n";
                }
                Console.WriteLine($"{s}");
            }
            else
            {
                Console.WriteLine($"There are no tools inside category {Vars.ToolCategories[toolType[0]]}");
            }
            Console.WriteLine(lineBreak);
        }

        public void displayTopThree()
        {
            throw new NotImplementedException();
        }

        public void listRentedTools(Member member)
        {
            var t = member.Tools;

            Console.Clear();
            Console.WriteLine("Currently borrowing these tools");
            Console.WriteLine(lineBreak);
            for (int i = 0; i < t.Count; i++)
            {
                Console.WriteLine($"{i+1}. {t[i].Name}");
            }
            if (t.Count == 0)
            {
                Console.WriteLine("Currently not borrowing any tools");
            }
            Console.WriteLine(lineBreak);

        }

        public void returnTool(Member member, Tool tool)
        {
            tool.AvailableQuantity++;
            member.deleteTool(tool);
        }

        // own functions
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

        public void TempTools()
        {
            Tool tool1 = new Tool("tool", 3, new int[] { 0, 0 })
            {

            };
            Tool tool3 = new Tool("Gardening line trimmer", 0, new int[] { 0, 0 })
            {

            };
            Tool tool4 = new Tool("Gardening hand tool", 0, new int[] { 2, 2 })
            {

            };
            Tool tool5 = new Tool("Gardening wheelbarrow", 0, new int[] { 0, 3 })
            {

            };
            Tool tool7 = new Tool("Flooring tool levelling material", 0, new int[] { 1, 3 })
            {

            };
            Tool tool8 = new Tool("Flooring tool levelling tool", 0, new int[] { 1, 2 })
            {

            };
            Tool tool9 = new Tool("Flooring tool floor laser", 0, new int[] { 1, 1 })
            {

            };
            Tool tool10 = new Tool("Flooring tool hand tool", 0, new int[] { 1, 4 })
            {

            };
            add(tool1);
            add(tool3);
            add(tool4);
            add(tool5);
            add(tool7);
            add(tool8);
            add(tool9);
            add(tool10);

        }
    }
}
