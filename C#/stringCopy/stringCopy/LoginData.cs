using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stringCopy
{
    
    class LoginData
    {
        string userName = null;
        string password = null;

        public void setUserName( string val)
        {
            userName = val;
        }

        public void setPassword(string val)
        {
            password = val;
        }

        public string getUsername()
        {
            return userName;
        }

        public string getPassword()
        {
            return password;
        }
    }
}
