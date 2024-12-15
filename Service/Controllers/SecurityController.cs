using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Security.Auth;
using Security.Models;


namespace Service.Controllers
{
    public class SecurityController : ApiController
    {
        private readonly AuthService _authService = new AuthService();

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/security/login")]
        public IHttpActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = _authService.Login(request.Email, request.Password);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
    }
}