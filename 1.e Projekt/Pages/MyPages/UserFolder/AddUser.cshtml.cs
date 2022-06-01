using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using _1.e_Projekt.Helpers;
using _1.e_Projekt.Interfaces;
using _1.e_Projekt.Models;
using _1.e_Projekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;


namespace _1.e_Projekt.Pages.MyPages.UserFolder
{
    [AllowAnonymous]
    public class AddUserModel : PageModel
    {
  

        public IUserInterface UserMethods;
        public static Users CurrentUsers;

        private IConfiguration cfg; 
        [BindProperty]
    
        [PageRemote(PageHandler = "IsEmailTaken", HttpMethod ="Get", ErrorMessage ="error email is already in use")]
        public UserModel AddedUsers { get; set; }
        public AddUserModel(IUserInterface repo, IConfiguration _cfg)
        {
            UserMethods = repo;
          
            cfg = _cfg;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public  IActionResult OnPost(UserLogin Users)
        {
            if (ModelState.IsValid)
            {
                var user = Authenticater(Users);
                if (user != null)
                {
                    var token = Generate(user);
                  



                }
                return NotFound("User Not Found");


            }


            return Page();
        }
     
        private string Generate(UserModel users)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cfg
                   ["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            { 
                
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
        private UserModel Authenticater(UserLogin userLogin)
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
