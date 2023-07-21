using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Web.Models
{
    public class SignUpVM
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string roleName { get; set; }
        public List<AppRole> roles { get; set; }
    }
}