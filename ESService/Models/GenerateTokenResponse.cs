using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESService.Models
{
    public class GenerateTokenResponse
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
        public JwtSecurityToken JwtSecurityToken { get; set; }
    }
}
