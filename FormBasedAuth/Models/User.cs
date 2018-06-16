using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBasedAuth.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}