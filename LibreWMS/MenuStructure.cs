using System;
namespace LibreWMS
{

    public static class MenuStructure
    {

        public static string[] Menu_Main = new string[]
        {
            "Search",
            "List",
            "Book",
            "Articles",
            "System",
            "About",
            "Quit"

        };

        public static string[] Menu_List = new string[]
        {
            "List all",
            "List active",
            "List inactive",
            "Main menu"
        };

        public static string[] Menu_Search = new string[]
        {
            "Search by parameter",
            "Set search parameter",
            "Set amount of returned lines",
            "Main menu"
        };

        public static string[] Menu_Book = new string[]
        {
            "Increase amount",
            "Decrease amount",
            "Main menu"
        };

        public static string[] Menu_Articles = new string[]
        {
            "Add new",
            "Edit",
            "Set active",
            "Set inactive",
            "Main menu"
        };

        public static string[] Menu_System = new string[]
        {
            "About",
            "Connection String",
            "Main menu"
        };
            

    }


}
