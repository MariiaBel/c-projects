using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Token.Models;

namespace Token.Controllers
{
    public class AcountController : Controller
    {

        private List<User> users = new List<User>
        {
            new User{Login = "loginAdmin", Password = "123", Role = "Admin"},
            new User{Login = "loginHR", Password = "123", Role = "HR"},
            new User{Login = "loginTeacher", Password = "123", Role = "Teacher"}
        };

        [HttpPost("/token")]
        public IActionResult Token(string login, string password)
        {
            var indentity = GetIndentity(login, password);
            if (indentity == null) return BadRequest(new { errorText = "Bad request" });

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENT,
                notBefore: now,
                claims: indentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(
                    AuthOptions.GetSymmentricSecurityKey(),
                    SecurityAlgorithms.HmacSha256
                    )
                 );
            var encoderJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new { access_token = encoderJwt, role = indentity.Name };
            return Json(response);
        }

        private ClaimsIdentity GetIndentity(string login, string password)
        {
            User user = users.FirstOrDefault(x => x.Login == login && x.Password == password);

            if (user == null) return null;

            var claim = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role),
            };

            ClaimsIdentity claimIndentity = new ClaimsIdentity(
                claim, 
                "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
                );
            return claimIndentity ;
        }
    }
}