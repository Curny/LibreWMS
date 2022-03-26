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