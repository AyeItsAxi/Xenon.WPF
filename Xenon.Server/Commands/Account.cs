using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Xenon.Server.Commands
{
    internal class Account
    {
        public static bool Login(string username, string password)
        {
            Console.WriteLine(username + password);
            Console.WriteLine($"Data\\Accounts\\{username}.xscf");
            if (!File.Exists($"Data\\Accounts\\{username}.xscf"))
            {
                return false;
            }
            XSCFile? account = JsonConvert.DeserializeObject<XSCFile>(File.ReadAllText($"Data\\Accounts\\{username}.xscf"));
            if (password == account?.password)
            {
                return true;
            }
            return false;
        }
    }
}
