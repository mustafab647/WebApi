using ESService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESService.Abstracts
{
    public interface ITokenService
    {
        Task<GenerateTokenResponse> GenerateTokenAsync(GenerateTokenRequest generateTokenRequest);
        Task<string> CreateToken(ESCore.Model.Authentication.User user);
    }
}
