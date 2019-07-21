using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stringCopy
{
    class Program
    {
        public string pass;
        public string src = "Value";

        public void setPass(LoginData user)
        {
            user.setUserName("Valentine");
        }

        static void Main(string[] args)
        {
            LoginData data = new LoginData();
            Program test = new Program();
            test.setPass(data);
            Console.WriteLine(data.getUsername());
        }
    }
}
