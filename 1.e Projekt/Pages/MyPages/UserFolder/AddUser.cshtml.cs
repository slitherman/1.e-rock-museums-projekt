using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.e_Projekt.Helpers;
using _1.e_Projekt.Interfaces;
using _1.e_Projekt.Models;
using _1.e_Projekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace _1.e_Projekt.Pages.MyPages.UserFolder
{
    [Authorize]
    public class AddUserModel : PageModel
    {
        public IUserInterface UserMethods;
        [BindProperty]
        [PageRemote(PageHandler = "IsEmailTaken", HttpMethod ="Get", ErrorMessage ="error email is already in use")]
        public User Users { get; set; }
        public AddUserModel(IUserInterface repo)
        {
            UserMethods = repo;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            
            UserMethods.CreateUser(Users);
            return RedirectToPage("GetUsers");
        }
        public JsonResult IsEmailTaken(User Users)
        {
            string filename = "/Data/UserDatabase.json/";
            JsonFileReader.ReadJson3(filename);
            if(Users.Email.Contains(filename))
            {
                return new JsonResult(false);
            }
            return new JsonResult(true);
        }


    }
}
