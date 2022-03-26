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
using System.Linq;

namespace LibreWMS
{
    public class Login
    {
        public string UserName { get; set; }
        public string HashedPassword { get; set; }

        

        private static string username = string.Empty;
        private static string password = string.Empty;
        public Login()
        { }
        public static void AskForCredentials()
        {
            //TODO:  get Userdata from Database so that we can companre
            List<User> usersInDatabase = new List<User>();
            DB db = new DB();
            usersInDatabase = db.GetUsersFromDatabase();

            Console.Clear();
            Console.WriteLine($"{ Helper.GetVersion() }  -  { DateTime.Now.ToShortDateString() } ::::: Login\n");
            
            Console.Write(" User name: ");
            username = Console.ReadLine();
            Console.Write("  Password: ");
            while (true)
            {
                var key = System.Console.ReadKey(true);                                
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }                    
                password += key.KeyChar; 
            }
            // Debugging:
            // Console.Write($"\n\n PW-Hash from console: {PWtoHash.EncryptToMD5(password)}");
            // Console.Write($"\n\n PW-Hash from DB: {usersInDatabase.Where(u => u.UserName == username).Select(x => x.UserPW.ToString()).First()}");
            if(PWtoHash.IsTheSame(
                PWtoHash.EncryptToMD5(password), 
                usersInDatabase.Where(u => u.UserName == username).Select(x => x.UserPW.ToString()).First()
                ))
            {
                Console.WriteLine("\nDebug: Passwords match!");
            }
            else
            {
                Console.WriteLine("\nDebug: Passwords do NOT match!");
            }
            


            HitAnyKey.ToContinue();
        }

        

    } // end of class
} // end of namespace