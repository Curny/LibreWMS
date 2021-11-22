using System;

namespace LibreWMS
{

    public class Menu
    {
        

        public Menu()
        {
        }

        public Menu(string menuName)
        {
            switch (menuName)
            {
                case "Main menu":
                case "Main":
                    Header(menuName);

                    for (int i = 0; i < MenuStructure.Menu_Main.Length; i++)
                    {
                        Console.WriteLine($"{ i + 1 } - { MenuStructure.Menu_Main[i] }");
                    }                    
                    Menu sel = new Menu(MenuStructure.Menu_Main[MenuSelection()]);
                    break;
                case "List":
                    Header(menuName);

                    for (int i = 0; i < MenuStructure.Menu_List.Length; i++)
                    {
                        Console.WriteLine($"{ i + 1 } - { MenuStructure.Menu_List[i] }");
                    }
                    Menu selL = new Menu(MenuStructure.Menu_List[MenuSelection()]);
                    break;
                case "Search":
                    Header(menuName);

                    for (int i = 0; i < MenuStructure.Menu_Search.Length; i++)
                    {
                        Console.WriteLine($"{ i + 1 } - { MenuStructure.Menu_Search[i] }");
                    }
                    Menu selSrch = new Menu(MenuStructure.Menu_Search[MenuSelection()]);
                    break;
                
                case "Book":
                    Header(menuName);

                    for (int i = 0; i < MenuStructure.Menu_Book.Length; i++)
                    {
                        Console.WriteLine($"{ i + 1 } - { MenuStructure.Menu_Book[i] }");
                    }
                    Menu selBk = new Menu(MenuStructure.Menu_Book[MenuSelection()]);
                    break;

                case "Articles":
                    Header(menuName);

                    for (int i = 0; i < MenuStructure.Menu_Articles.Length; i++)
                    {
                        Console.WriteLine($"{ i + 1 } - { MenuStructure.Menu_Articles[i] }");
                    }
                    Menu selArt = new Menu(MenuStructure.Menu_Articles[MenuSelection()]);
                    break;
                
                case "System":
                    Header(menuName);

                    for (int i = 0; i < MenuStructure.Menu_System.Length; i++)
                    {
                        Console.WriteLine($"{ i + 1 } - { MenuStructure.Menu_System[i] }");
                    }
                    Menu selSys = new Menu(MenuStructure.Menu_System[MenuSelection()]);
                    break;

                case "About":
                    Header("About LibreWMS");                
                    Console.WriteLine(About.LibreWMS());
                    HitAnyKey.ToContinue();
                    Menu backToSystem = new Menu("System");
                    break;
                
                case "Quit":
                    Console.Clear();
                    Console.WriteLine("Goodbye... :) \n\n");
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }

        private static void Header(string menuName)
        {
            Console.Clear();
            Console.WriteLine($"{ Helper.GetVersion() }  -  { DateTime.Now.ToShortDateString() } ::::: { menuName }\n");
        }

        private static int MenuSelection()
        {
            Console.Write("\n Select menu number: ");
            int.TryParse(Console.ReadLine(), out int choice);
            return choice - 1; 
        }


            

    }


}
