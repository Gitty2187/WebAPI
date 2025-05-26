using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserLogin(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
