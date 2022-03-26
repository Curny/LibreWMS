/* 
    LibreWMS - a free, open warehouse management program
    Copyright (C) 2021  Willy Weinmann

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>. 
    */
    
using System;
using System.Collections.Generic;

namespace LibreWMS
{

    public class Menu
    {
        //TODO: put all headers dynamically....
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
                    Header(menuName);
                    Article.ListAll();                    
                    HitAnyKey.ToContinue();
                    Menu backToListMenu = new Menu("List");
                    break;

                case "List active":
                    HeaderOfColumnIsActive = "Active";
                    Header(menuName);
                    Article.ListActive();
                    HitAnyKey.ToContinue();
                    Menu backToListMenu2 = new Menu("List");
                    break;

                case "List inactive":
                    HeaderOfColumnIsActive = "Active";
                    Header(menuName);
                    Article.ListInactive();
                    HitAnyKey.ToContinue();
                    Menu backToListMenu3 = new Menu("List");
                    break;
                // ==== end of menu search ====
                #endregion

                #region Article
                case "Add new":
                    Header(menuName);
                    Article.Create();
                    HitAnyKey.ToContinue();
                    Menu backToArticleMenu = new Menu("Article");
                    break;  

                #endregion

                #region MenuSystem
                // ---- menu system ----
                case "Users":
                    Header(menuName);
                    // TODO:  User administration
                    HitAnyKey.ToContinue();
                    Menu backToSystemFromUsers = new Menu("System");
                    break;  

                case "About":
                    Header("About LibreWMS");                
                    Console.WriteLine(About.LibreWMS());
                    HitAnyKey.ToContinue();
                    Menu backToSystemFromAbout = new Menu("System");
                    break;

                case "Connection String":
                    Header("Connection string info");
                    Console.WriteLine($"Connection string for the SQL database:\n\n\t { Helper.CnnVal("SampleDB") }");
                    HitAnyKey.ToContinue();
                    Menu backToSystemFromConStr = new Menu("System");
                    break;
                // ==== end of menu system ====
                #endregion

                case "":
                    Menu backToMainFromBlank = new Menu("Main");
                    break;

                default:
                    Header("THIS IS NOT IMPLEMENTED, YET!");
                    Console.WriteLine("This functionality has not been implemented, yet.");
                    HitAnyKey.ToContinue();
                    Menu backToMainByDefault = new Menu("Main");
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
