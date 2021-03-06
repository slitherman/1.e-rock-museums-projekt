using _1.e_Projekt.Interfaces;
using _1.e_Projekt.Models;
using _1.e_Projekt.Services;
using Abp.Authorization.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _1.e_Projekt.Pages.MyPages.AoiControllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginApi : ControllerBase
    {
        private IConfiguration cfg;
   

        public static Users CurrentUsers;

        public LoginApi(IConfiguration repo)
        {
            cfg = repo;
        }

        public object Authenticate { get; private set; }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Models.UserLogin Users)
        {
            var user = Authenticater(Users);
            if(user !=null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("User Not Found");
          
        }

        private string Generate(UserModel users)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cfg
                   ["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            { // all claimtypes are apparently strings, find out how to add userid and password later or something
                
                new Claim(ClaimTypes.NameIdentifier, users.FirstName),
                new Claim(ClaimTypes.Surname, users.LastName),
                new Claim(ClaimTypes.Email, users.Email),
                   new Claim(ClaimTypes.Role, users.Role),



            };
            var token = new JwtSecurityToken(cfg["Jwt:Issuer"], cfg["Jwt:Audience"],


               claims,
               expires: DateTime.Now.AddHours(10),
               signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);   
        }

        private UserModel Authenticater(Models.UserLogin userLogin)
        {

            var CurrentUser = CurrentUsers.UserCollection.FirstOrDefault(o => o.Email.ToLower() ==
             userLogin.Email.ToLower() && o.Password == userLogin.Password);
         

            if (CurrentUser != null)
            {
                return CurrentUser;
            }
            return null;

        }
    }
}
