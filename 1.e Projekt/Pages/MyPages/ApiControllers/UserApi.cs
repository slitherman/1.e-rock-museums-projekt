using _1.e_Projekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace _1.e_Projekt.Pages.MyPages.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApi : ControllerBase
    {
        [HttpGet("Admins")]
        [Authorize]
        public IActionResult AdminsEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.Email} you are an admin");
        }

        public Users GetCurrentUser()
        {
            var userIdentity = HttpContext.User.Identity as ClaimsIdentity;
            if (userIdentity != null)
            {
                var userClaims = userIdentity.Claims;

                // i have no fucking idea what im doing idk if this actually makes any sense
                // 
                return new Users
                {
                    FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                };
                
            }
            return null;
        }
    }
}
