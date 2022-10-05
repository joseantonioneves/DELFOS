using DELFOS.JWT.SSO.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DELFOS.JWT.SSO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // injeção de dependencia com IConfiguration
        public IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        /// <summary>
        /// Implementa as ações executadas na chamada da controller Login
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);
            if (user !=null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("Usuário não encontrado");
        }

        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.GivenName),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], 
                                            _config["Jwt:Audience"],
                                            claims,
                                            expires: DateTime.Now.AddMinutes(20),
                                            signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel? Authenticate(UserLogin userLogin)
        {
            var currentUser = UserConstants.
                Users.FirstOrDefault(op => op.UserName.ToLower() == 
                userLogin.UserName.ToLower() && op.Password == userLogin.Password);
            if(currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }
}
