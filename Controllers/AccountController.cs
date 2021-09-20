using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using ReviewApi.Data;
using ReviewApi.Data.ApiModels;
using ReviewApi.Data.Models;
using ReviewApi.Data.ViewModels;

namespace ReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDBContext _context;

        public AccountController(AppDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("SignIn")]
        public string SignIn(SignInViewModel signInViewModel)
        {
            if(_context.Users.Any(user => user.Login == signInViewModel.Login && user.Password == signInViewModel.Password))
                return CheckAndGenerateJwtCode(signInViewModel.Login, signInViewModel.Password);
            return "Invalid username or password.";
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<string> SignUp(SignUpViewModel signUpViewModel)
        {
            if (ModelState.IsValid || !_context.Users.Any(user => user.Login == signUpViewModel.Login))
            {
                _context.Add(new User { Name = signUpViewModel.Name, Login = signUpViewModel.Login, Password = signUpViewModel.Password });
                await _context.SaveChangesAsync();
                return CheckAndGenerateJwtCode(signUpViewModel.Login, signUpViewModel.Password);
            }
            return "Invalid username or password.";
        }

        private string CheckAndGenerateJwtCode(string username, string password)
        {
            User user = _context.Users.FirstOrDefault(x => x.Login == username);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);

                var now = DateTime.UtcNow;
                var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: claimsIdentity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                return new JwtSecurityTokenHandler().WriteToken(jwt);

            }
            return "Invalid username or password.";
        }
    }
}
