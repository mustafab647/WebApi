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

        public async Task<string> CreateToken(ESCore.Model.Authentication.User user)
        {
            var authClaims = new List<Claim>();
            authClaims.Add(new Claim(ClaimTypes.Role, "Category"));
            authClaims.Add(new Claim(ClaimTypes.Role, "Category.Create"));
            authClaims.Add(new Claim(ClaimTypes.Role, "Category.View"));
            authClaims.Add(new Claim(ClaimTypes.Name, user.UserName));
            authClaims.Add(new Claim(ClaimTypes.Email, user.Email));
            authClaims.Add(new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            GenerateTokenRequest generateTokenRequest = new GenerateTokenRequest();
            generateTokenRequest.UserName = user.UserName;
            generateTokenRequest.Claims = authClaims;

            var tokenResp = await GenerateTokenAsync(generateTokenRequest);
            string result = new JwtSecurityTokenHandler().WriteToken(tokenResp.JwtSecurityToken);
            return result;
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
            DateTime expireDate = DateTime.Now.AddMinutes(1);
            SigningCredentials signingCredentials = new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(issuer, audience, claims, DateTime.Now, expireDate, signingCredentials);
            return token;
        }
    }
}
