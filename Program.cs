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

            
            pg.MainOutput();
        }

        public void MainOutput()
        {
            // show welcome screen
            // ask for login - if user presses 0 at any time it goes back to this menu
            //TODO: create a logout 
            // show either staff menu or member menu
            // STAFF
            // display options
            // go to output page for selected option
            // MEMBER
            // display options
            // go to output page for selected option

            outputs.WelcomeScreen();

            // LOGIN PART
            var userLoginType = outputs.LoggedOut();
            if (userLoginType == 1) 
            { 
                Console.Clear(); 
                this.outputs.LoginStaff();
                var selectedOption = outputs.StaffMenu();

                int[] toolSelect = null;

                switch (selectedOption)
                {
                    case 1: // add a new tool
                        Tool tool = outputs.GetNewToolInfo(); 
                        this.system.add(tool); 
                        break;
                    case 2: // add a quantity of pieces for a tool
                        toolSelect = GetToolSelectedIndex(outputs, this.system);
                        this.system.add(this.system.ToolCollections[toolSelect[0]].toArray()[0], outputs.GetNewToolInforMultiple());
                        break;
                    case 3: // remove pieces of tool
                        toolSelect = GetToolSelectedIndex(outputs, system);
                        system.delete(system.ToolCollections[toolSelect[0]].toArray()[0]);
                        break;
                    case 4: // register new member
                        Console.Clear();
                        system.add(outputs.CreateNewMember());
                        break;
                    case 5: // remove member
                        system.delete(outputs.DeleteMember(system));
                        break;
                    case 6: // find contact number of member
                        outputs.GetPhoneNumber(system);
                        break;
                    case 0:
                        this.MainOutput();
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
                this.MainOutput();
            }
            // MEMBER
            else if (userLoginType == 2) 
            { 
                Console.Clear(); 
                outputs.LoginMember(system);
                var selectedOption = outputs.MemberMenu();

                int[] toolSelect = null;

                switch (selectedOption)
                {
                    case 1: // display tools
                        system.displayTools(outputs.GetToolCategory()); 
                        break;
                    case 2: // borrow tool
                        toolSelect = GetToolSelectedIndex(outputs, system);
                        system.displayTools(toolSelect);
                        system.borrowTool(system.CurrentUser, system.ToolCollections[toolSelect[0]].toArray()[toolSelect[1]]);

                        break;
                    case 3: // return tool 
                        Console.WriteLine("3"); break;
                    case 4: // list all tools im renting
                        system.listTools(system.CurrentUser);
                        MainOutput();
                        break;
                    case 5: // display top three most freq rented tools 
                        Console.WriteLine("5"); break;
                    case 0: MainOutput(); break;

                    default:
                        break;
                }

                MainOutput();
            }
            else if (userLoginType == 0) { Environment.Exit(0); }
        }

        public static int[] GetToolSelectedIndex(Output outputs, ToolLibrarySystem system)
        {
            var toolCat = outputs.GetToolCategory();
            system.displayTools(toolCat);
            return outputs.SelectTool(system, toolCat);

        }


        public static void AddMembers(MemberCollection memColl)
        {
            Member mem1 = new Member("1", "", "0421158333", "1") { };
            memColl.add(mem1);

            Member mem = new Member("Pratham", "chaudhry", "111111111", "1111") { };
            Member mem2 = new Member("Matt", "Lee", "2222222222", "2222") { };
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
