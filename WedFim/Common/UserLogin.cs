using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WedFim.Common
{
    [Serializable]
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}