using ESService.Abstracts;
using ESService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ESService.Bussines
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GenerateTokenResponse> GenerateTokenAsync(GenerateTokenRequest generateTokenRequest)
        {
            JwtSecurityToken token = await GetToken(generateTokenRequest.Claims, generateTokenRequest.UserName);
            GenerateTokenResponse generateTokenResponse = new GenerateTokenResponse();
            generateTokenResponse.JwtSecurityToken = token;
            return generateTokenResponse;
        }
        private async Task<JwtSecurityToken> GetToken(List<Claim> claims, string userName)
        {
            if (claims == null)
                return null;
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SigningKey"] ?? ""));
            string issuer = _configuration["JwtSettings:Issuer"] ?? "";
            string audience = _configuration["JwtSettings:Audience"] ?? "";
            DateTime expireDate = DateTime.Now.AddHours(1);
            SigningCredentials signingCredentials = new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(issuer, audience, claims, DateTime.Now, expireDate, signingCredentials);
            return token;
        }
    }
}
