using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Security.Models;

namespace Security.Auth
{
    public class AuthService
    {
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>()
        {
            { "admin@example.com", PasswordHasher.HashPassword("Admin123!") }, // Ejemplo de usuario
        };

        public string Login(string email, string password)
        {
            if (_users.ContainsKey(email) && PasswordHasher.VerifyPassword(password, _users[email]))
            {
                // Genera un token JWT con rol "Admin" por defecto
                return TokenManager.GenerateToken(email, "Admin");
            }
            throw new UnauthorizedAccessException("Invalid credentials");
        }
    }
}
