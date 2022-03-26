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
    public class User
    {
        #region Properties
        public string UserName { get; set; }
        public string UserIsActive { get; set; }  // yes or no
        public string RoleName { get; set; }  // TODO implement own Role class and inherit it to User
        public string UserPW { get; set; }  // will be a MD5-Hash
        #endregion
        
        
        public User()
        {

        }

    } // end of class
} // end of namespace