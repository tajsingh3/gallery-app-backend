using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApi.Domain.Services;
using GalleryApi.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GalleryApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public UserController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody]SignupResource signupResource)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid signup data");

            var result = await authenticationService.CreateUser(signupResource.Email, signupResource.Password);
            if (!result.Succeeded)
            {
                return BadRequest("user account could not be created");
            }

            return Ok(new { AccountCreated = true });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginResource loginResource)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid signup data");

            var token = await authenticationService.Authenticate(loginResource.Email, loginResource.Password);
            if (token == null) return BadRequest("Jwt Token could not be created");

            return Ok(new { UserName = loginResource.Email, Token = token });

        }

    }
}
