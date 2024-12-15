using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Authorization
{
    public static class AuthorizationService
    {
        public static bool HasRole(string role, string requiredRole)
        {
            return role.Equals(requiredRole, StringComparison.OrdinalIgnoreCase);
        }
    }
}
