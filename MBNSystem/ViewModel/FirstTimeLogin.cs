using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBNSystem.ViewModel
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}