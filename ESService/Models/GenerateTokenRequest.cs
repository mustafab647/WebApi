using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ESService.Models
{
    public class GenerateTokenRequest
    {
        public string UserName { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
