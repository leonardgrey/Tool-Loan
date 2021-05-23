using System;
using System.Collections.Generic;
using ToolLoan.Classes;

namespace ToolLoan
    {
        class Program
    {
        MemberCollection memberCollection;
        ToolLibrarySystem system;
        ToolCategoriesTypes vars;
        Output outputs;
        public void Setup()
        {
            memberCollection = new MemberCollection();
            AddMembers(memberCollection);
            system = new ToolLibrarySystem(memberCollection);
            vars = new ToolCategoriesTypes();
            outputs = new Output(system, vars);
        }

        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.Setup();


            //pg.outputs.SelectToolType();

            pg.MainOutput();

        }

        public void MainOutput()
        {
            outputs.WelcomeScreen();
            // LOGIN PART
            var userLoginType = outputs.LoggedOut();
            if (userLoginType == 1) 
            { 
                Console.Clear();

                int[] toolSelect = null;
                if (this.outputs.LoginStaff())
                {
                    while (true)
                    {
                        var selectedOption = outputs.StaffMenu();
                        switch (selectedOption)
                        {
                            case 1: // add a new tool
                                Console.Clear();
                                Tool tool = outputs.GetNewToolInfo();
                                this.system.add(tool);
                                break;
                            case 2: // add a quantity of pieces for a tool
                                toolSelect = GetToolSelectedIndex();
                                if (toolSelect != null)
                                {
                                    this.system.add(this.system.ToolCollections[toolSelect[0]].toArray()[0], outputs.GetNewToolInforMultiple());
                                }
                                else { Console.ReadLine();}
                                break;
                            case 7: // remove tool
                                toolSelect = GetToolSelectedIndex();
                                system.delete(system.ToolCollections[toolSelect[0]].toArray()[0]);
                                break;
                            case 3: // remove pieces of tool
                                toolSelect = GetToolSelectedIndex();
                                var amount = outputs.AmountToDelete();
                                system.delete(system.ToolCollections[toolSelect[0]].toArray()[0], amount);
                                break;
                            case 4: // register new member
                                Console.Clear();
                                system.add(outputs.CreateNewMember());
                                break;
                            case 5: // remove member
                                system.delete(outputs.DeleteMember(system));
                                break;
                            case 6: // find contact number of member
                                system.display(outputs.GetPhoneNumber());
                                break;
                            case 0: Console.Clear(); MainOutput(); break;
                            default:
                                Console.WriteLine("Invalid option");
                                Console.ReadLine();
                                break;
                        }
                    }
                }
            }
            // MEMBER
            else if (userLoginType == 2) 
            { 
                Console.Clear(); 
                int[] toolSelect = null;

                if(outputs.LoginMember(system))
                {
                    while (true)
                    {
                        var selectedOption = outputs.MemberMenu();
                        switch (selectedOption)
                        {
                            case 1: // display tools
                                system.displayTools(outputs.GetToolCategory());
                                Console.WriteLine("\nPress enter...");
                                Console.ReadLine();
                                break;
                            case 2: // borrow tool
                                toolSelect = GetToolSelectedIndex();
                                if (toolSelect == null)
                                {
                                    break;
                                }
                                Tool t = null;
                                try
                                {
                                    t = system.ToolCollections[toolSelect[0]].toArray()[toolSelect[1]];
                                }
                                catch (Exception)
                                {

                                }
                                system.borrowTool(system.CurrentUser, t);

                                break;
                            case 3: // return tool 
                                // show tools rented then get index 
                                system.listRentedTools(system.CurrentUser);
                                Tool tool = null;
                                try
                                {
                                    tool = system.CurrentUser.Tools[outputs.GetRentedToolSelection()];
                                    system.returnTool(system.CurrentUser, tool);    
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Input number too big");
                                }
                                break;
                            case 4: // list all tools im renting
                                system.listRentedTools(system.CurrentUser);
                                Console.WriteLine("Press enter...");
                                Console.ReadLine();
                                Console.Clear();
                                // get the tool selected
                                break;
                            case 5: // display top three most freq rented tools 
                                system.displayTopThree();
                                break;
                            case 0: Console.Clear(); MainOutput(); break;

                            default:
                                break;
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    MainOutput();
                }
                
            }
            else if (userLoginType == 0) { Environment.Exit(0); }
        }

        public int[] GetToolSelectedIndex()
        {
            var toolCat = this.outputs.GetToolCategory();
            var categoryItems = system.ToolCollections[toolCat[0]].toArray();

            system.displayTools(toolCat);
            if (categoryItems.Length > 0)
            {
                return outputs.SelectTool(system, toolCat);
            }
            else
            {
                return null;
            }
        }

        public static void AddMembers(MemberCollection memColl)
        {
            Member mem1 = new Member("1", "", "0421158333", "1") { };
            memColl.add(mem1);

            Member mem = new Member("Pratham", "chaudhry", "111111111", "1234") { };
            Member mem2 = new Member("Matt", "Lee", "2222222222", "1234") { };
            Member mem3 = new Member("Denny", "Lee", "3333333333", "3333") { };
            Member mem4 = new Member("Jet", "Wong", "3333333333", "3333") { };
            Member mem5 = new Member("Arded", "Amreet", "3333333333", "3333") { };
            Member mem6 = new Member("esha", "Rohan", "3333333333", "3333") { };
            memColl.add(mem);
            memColl.add(mem2);
            memColl.add(mem3);
            memColl.add(mem4);
            memColl.add(mem5);
            memColl.add(mem6);

        }
    }
}
