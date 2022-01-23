using System;
using System.Collections.Generic;

namespace LibreWMS
{

    public class Menu
    {
        public static string HeaderOfColumnIsActive { get; set; }
        public Menu()
        {
        }

        public Menu(string menuName)
        {
            
            switch (menuName)
            {
                #region MainMenu
                // ---- main menu ----
                case "Main menu":
                case "Main":
                    Header(menuName);

                    for (int i = 0; i < MenuStructure.Menu_Main.Length; i++)
                    {
                        Console.WriteLine($"{ i + 1 } - { MenuStructure.Menu_Main[i] }");
                    }                    
                    Menu sel = new Menu(MenuStructure.Menu_Main[MenuSelection(MenuStructure.Menu_Main.Length)]);
                    break;
              
                case "Search":
                    Header(menuName);

                    for (int i = 0; i < MenuStructure.Menu_Search.Length; i++)
                    {
                        Console.WriteLine($"{ i + 1 } - { MenuStructure.Menu_Search[i] }");
                    }
                    Menu selSrch = new Menu(MenuStructure.Menu_Search[MenuSelection(MenuStructure.Menu_Search.Length)]);
                    break;
                
                case "Book":
                    Header(menuName);

                    for (int i = 0; i < MenuStructure.Menu_Book.Length; i++)
                    {
                        Console.WriteLine($"{ i + 1 } - { MenuStructure.Menu_Book[i] }");
                    }
                    Menu selBk = new Menu(MenuStructure.Menu_Book[MenuSelection(MenuStructure.Menu_Book.Length)]);
                    break;

                case "Articles":
                    Header(menuName);

                    for (int i = 0; i < MenuStructure.Menu_Articles.Length; i++)
                    {
                        Console.WriteLine($"{ i + 1 } - { MenuStructure.Menu_Articles[i] }");
                    }
                    Menu selArt = new Menu(MenuStructure.Menu_Articles[MenuSelection(MenuStructure.Menu_Articles.Length)]);
                    break;
                
                case "System":
                    Header(menuName);

                    for (int i = 0; i < MenuStructure.Menu_System.Length; i++)
                    {
                        Console.WriteLine($"{ i + 1 } - { MenuStructure.Menu_System[i] }");
                    }
                    Menu selSys = new Menu(MenuStructure.Menu_System[MenuSelection(MenuStructure.Menu_System.Length)]);
                    break;                
                
                case "Quit":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("\n>>> ARE YOU SURE YOU WANT TO QUIT? (y/n) >>> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string sure = Console.ReadLine();
                    if (sure == "y" || sure.ToString() == "j")
                    {                        
                        Console.WriteLine("Goodbye... :) \n\n");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Menu backToStart = new Menu("Main");
                    }
                    
                    break;
                // ==== end of main menu ====
                #endregion

                #region MenuSearch
                // ---- menu search ----
                case "List all articles":
                    HeaderOfColumnIsActive = "Active";
                    List<Article> articles = new List<Article>();
                    DB db = new DB();
                    articles = db.GetAllArticles();
                    Header(menuName);
                    
                    Console.WriteLine($" | Art. nr. | Art. name        | EAN / GTIN    | amnt avlble | Location         |   Gross kgs |     Net kgs | {HeaderOfColumnIsActive} |");
                    Console.WriteLine(" |----------|------------------|---------------|-------------|------------------|-------------|-------------|--------|");
                    foreach (var article in articles)
                    {
                        System.Console.WriteLine(article.StockInfo1);
                    }
                    
                    System.Console.WriteLine($"\n\n\t>>> Total amount of articles in database: { articles.Count.ToString() } <<<");
                    HitAnyKey.ToContinue();
                    Menu backToListMenu = new Menu("List");
                    break;
                // ==== end of menu search ====
                #endregion

                #region MenuSystem
                // ---- menu system ----
                case "About":
                    Header("About LibreWMS");                
                    Console.WriteLine(About.LibreWMS());
                    HitAnyKey.ToContinue();
                    Menu backToSystem = new Menu("System");
                    break;

                case "Connection String":
                    Header("Connection string info");
                    Console.WriteLine($"Connection string for the SQL database:\n\n\t { Helper.CnnVal("SampleDB") }");
                    HitAnyKey.ToContinue();
                    Menu backToSystemMenu = new Menu("System");
                    break;
                // ==== end of menu system ====
                #endregion

                default:
                    Header("THIS IS NOT IMPLEMENTED, YET!");
                    Console.WriteLine("This functionality has not been implemented, yet.");
                    HitAnyKey.ToContinue();
                    Menu backToMain = new Menu("Main");
                    break;
            }
        }

        private static void Header(string menuName)
        {
            Console.Clear();
            Console.WriteLine($"{ Helper.GetVersion() }  -  { DateTime.Now.ToShortDateString() } ::::: { menuName }\n");
        }

        private static int MenuSelection(int maxNr)
        {
            bool validChoice = false;
            int choice = 0;
            do
            {
                Console.Write("\n Select menu number: ");
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int c))
                {
                    validChoice = true;
                    choice = c;
                }
                else
                {
                    if (string.IsNullOrEmpty(input))
                    {
                        validChoice = true;
                        choice = maxNr;
                    }
                    else
                    {
                        validChoice = false;
                        input = string.Empty;
                        Console.WriteLine("\t>>> Invalid input. Repeat.");
                    }
                    
                }
            } while (!validChoice);
            
            return choice - 1 ;
        }


            

    } // end of class

}  // end of namespace
