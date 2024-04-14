using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using IntegracjaSystemow8.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
//using IntegracjaSystemow8.Model;
//using IntegracjaSystemow8.Services.Users;
using ORM_Projekt.jwt_seed.Services.Users;
using ORM_Projekt.jwt_seed.Model;

namespace ORM_Projekt.jwt_seed
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticationRequest request)
        {
            var response = userService.Authenticate(request);
            if (response == null)
                return BadRequest(new
                {
                    message = "Username or password is incorrect"
                });
            return Ok(response);
        }
    }
}
