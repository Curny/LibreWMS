using System;

namespace LibreWMS
{

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

    public static class About
    {
        public static string LibreWMS()
        {
            string infoText = 
                    @"
                    LibreWMS - a free, open warehouse management program
                    Copyright (C) 2021  Willy Weinmann
                    
                    >> GNU GENERAL PUBLIC LICENSE Version 3 <<

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
                    "
                    ;


            return infoText;
        }
    }

}