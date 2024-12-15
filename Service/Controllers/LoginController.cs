using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login([FromBody] UserLogin user)
        {
            // Validar credenciales (esto es un ejemplo simple)
            if (user.Username == "admin" && user.Password == "1234")
            {
                // Generar token JWT
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey123!"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var token = new JwtSecurityToken(
                    issuer: "MyApp",
                    audience: "MyAppUsers",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return Content(HttpStatusCode.Unauthorized, "Usuario o contraseña incorrectos.");
        }
    }

    // Modelo de usuario
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}