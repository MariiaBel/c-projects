using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Token.Models
{
    public class User
    {
        public string Login { get; internal set; }
        public string Password { get; internal set; }
        public string Role { get; internal set; }
    }
}
