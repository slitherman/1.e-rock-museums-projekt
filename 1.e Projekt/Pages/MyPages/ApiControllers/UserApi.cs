using _1.e_Projekt.Models;
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
    [Route("api/users")]
    [ApiController]
    public class UserApi : ControllerBase
    {
        [HttpGet("Admins")]
        [Authorize(Roles ="Admin")]
        public IActionResult AdminsEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.Email} you are an {currentUser.Role}");
        }


        public UserModel GetCurrentUser()
        {
            var userIdentity = HttpContext.User.Identity as ClaimsIdentity;
            if (userIdentity != null)
            {
                var userClaims = userIdentity.Claims;

                
                return new UserModel
                {
                    FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Role= userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                };
                
            }
            return null;
        }
    }
}
