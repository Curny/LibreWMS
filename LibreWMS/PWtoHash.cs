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
using System.Security.Cryptography;
using System.Text;


namespace LibreWMS
{
    /// <summary>
    /// "encrypt" entered Password to MD5-Hashes and compare to the hashed stored in User.UserPW in the Database
    /// </summary>
    public class PWtoHash
    {
        public string EncryptToMD5(string salt)
        {
            byte[] hash1;
            using (MD5 md5 = MD5.Create())
            {
                md5.Initialize();
                md5.ComputeHash(Encoding.UTF8.GetBytes(salt));
                hash1 = md5.Hash;
            }

            // Zurück von Byte in einen String
            string hashedString = BitConverter
                            .ToString(hash1)
                            .Replace("-", String.Empty);
            return hashedString;
        }

        public static bool IsTheSame(string s1, string s2)
        {
            return (s1 == s2 ? true : false);
        }


    } // end of class
} // end of namespace