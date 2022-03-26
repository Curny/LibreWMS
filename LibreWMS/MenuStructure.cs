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
namespace LibreWMS
{

    public static class MenuStructure
    {

        public static string[] Menu_Main = new string[]
        {
            "Search",
            "Book",
            "Articles",
            "System",
            "Quit"

        };

        public static string[] Menu_Search = new string[]
        {
            "List active",
            "List inactive",
            "List all articles",            
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
            "Users",
            "About",
            "Connection String",
            "Main menu"
        };  

    }


}
