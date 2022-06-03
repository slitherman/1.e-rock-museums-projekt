using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using _1.e_Projekt.Helpers;
using _1.e_Projekt.Interfaces;
using _1.e_Projekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace _1.e_Projekt.Pages.MyPages.UserFolder
{

    public class UserSignUpModel : PageModel
    {
        [PageRemote(PageHandler = "IsEmailTaken", HttpMethod = "Get", ErrorMessage = "error email is already in use")]

        [BindProperty]


        public UserModel NewUser { get; set; }
        public IUserInterface UserMethods;
     
        private IConfiguration cfg;
        public UserSignUpModel(IUserInterface repo, IConfiguration _cfg)
        {
            UserMethods = repo;
            cfg = _cfg;
        }

        public IActionResult OnGet()
        {
            return Page();

        }
        public IActionResult OnPost()
        {
            UserMethods.CreateUser(NewUser);
            IsEmailTaken(NewUser);
            return Page();

       
        }
        public JsonResult IsEmailTaken(UserModel Users)
        {
            string filename = "./Data/JsonUsers.json";
            JsonFileReader.ReadJson3(filename);
            if (Users.Email.Contains(filename))
            {
                return new JsonResult(false);
            }
            return new JsonResult(true);
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
            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(cfg["Jwt:Issuer"], cfg["Jwt:Audience"],


               claims,
               expires: DateTime.Now.AddHours(10),
               signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
      
    }
}

