using System;
using System.Collections.Generic;
namespace LibreWMS
{
    public class Menu
    {
        static Dictionary<int, string> MenuItems = new Dictionary<int, string>();
        public static string menuChoice = string.Empty;
        public static string currentMenu = "Main Menu";

        public Menu()
        {
        }

        public static void MainMenu()
        {
            currentMenu = "Main Menu";
            MenuHeader.Display();
            MenuItems.Clear();
            MenuItems.Add(1, "List all aticles");
            MenuItems.Add(2, "Booking");
            MenuItems.Add(3, "Article handling");
            MenuItems.Add(5, "Settings");
            MenuItems.Add(0, "Quit");

            DisplaySelectedMenu();

            switch (menuChoice)
            {
                case "1":
                    ListAllArticlesMenu();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    MainMenu();
                    break;
            }

        }

        public static void ListAllArticlesMenu()
        {
            MenuItems.Clear();
            currentMenu = "List All Articles";
            MenuHeader.Display();
            MenuItems.Add(1, "List all articles");
            MenuItems.Add(2, "List only active articles");
            MenuItems.Add(3, "List only inactive articles");
            MenuItems.Add(4, "List only n articles");
            MenuItems.Add(5, "Search for article");
            MenuItems.Add(0, "Back to Main Menu");

            DisplaySelectedMenu();

            switch (menuChoice)
            {
                case "0":
                    MainMenu();
                    break;
                default:
                    ListAllArticlesMenu();
                    break;
            }
        }

        static void DisplaySelectedMenu()
        {
            Console.WriteLine();

            foreach (var item in MenuItems)
            {
                if (item.Key < 10)
                {
                    Console.WriteLine("   " + item.Key.ToString() + " - " + item.Value);
                }
                else
                {
                    Console.WriteLine("  " + item.Key.ToString() + " - " + item.Value);
                }

            }

            menuChoice = ReadInput();
        }

        static string ReadInput()
        {
            Console.Write("\n\tYour choice: ");

            return Console.ReadLine();
        }
    }
}
