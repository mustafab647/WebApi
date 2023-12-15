using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore.Model.Authentication
{
    public class User : IdentityUser, IEquatable<string>
    {
        //public string Name { get;set; }
        //public string Password { get;set; }
        //public string Email { get;set; }
        //public bool IsEmailVerified { get;set; }
        //public bool IsValid { get;set; }
        public bool Equals(string? other)
        {
            throw new NotImplementedException();
        }
    }
}
