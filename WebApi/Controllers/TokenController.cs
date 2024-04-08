using ESCore.ESContext;
using ESService.Abstracts;
using ESService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApi.Models;
using WebApi.Models.Token;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ESDBContext _context;
        private readonly ITokenService _tokenService;
        private UserManager<ESCore.Model.Authentication.User> _userManager;
        public TokenController(IConfiguration configuration
            , ESDBContext context
            , ITokenService tokenService
            , UserManager<ESCore.Model.Authentication.User> userManager
            )
        {
            _config = configuration;
            _context = context;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("CreateToken")]
        public async Task<IActionResult> CreateToken(Models.Token.Token token)
        {
            if (string.IsNullOrEmpty(token?.UserName) || string.IsNullOrEmpty(token?.Password))
                return BadRequest(new ArgumentNullException());

            var user = await _userManager.FindByNameAsync(token.UserName);
            if (await _userManager.CheckPasswordAsync(user, token.Password))
            {
                string jwtToken = await _tokenService.CreateToken(user);
                TokenResult tokenResult = new TokenResult();
                tokenResult.accessToken = jwtToken;
                var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(tokenResult);

                return new JsonResult(tokenResult);
            }
            else
                return BadRequest(new ArgumentException("Invalid username or password"));

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var hasUser = _context.Users.Any(x => x.UserName == registerRequest.UserName);

            if (hasUser)
                return BadRequest(new Exception("Definition user"));

            ESCore.Model.Authentication.User user = new ESCore.Model.Authentication.User();
            user.UserName = registerRequest.UserName;
            user.Email = registerRequest.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();

            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new RegisterResponse() { Error = "User creation failed! Please check user details and try again.", Success = false });

            return Ok(new RegisterResponse() { Success = true });
        }
    }
}
