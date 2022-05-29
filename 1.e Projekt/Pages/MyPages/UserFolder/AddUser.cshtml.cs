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
        private UserManager<IdentityUser> userManager;
        private UserManager<IdentityUser> signInManeger;

        public IUserInterface UserMethods;
        [BindProperty]
        [PageRemote(PageHandler = "IsEmailTaken", HttpMethod ="Get", ErrorMessage ="error email is already in use")]
        public UserModel AddedUsers { get; set; }
        public AddUserModel(IUserInterface repo, UserManager<IdentityUser> userManager, UserManager<IdentityUser> signInManeger)
        {
            UserMethods = repo;
            this.userManager = userManager;
            this.signInManeger = signInManeger;

        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel()
                {
                    FirstName= AddedUsers.FirstName,
                    LastName = AddedUsers.LastName,

                     Email = AddedUsers.Email,
                     Password= AddedUsers.Password,
                    ConfirmPassword= AddedUsers.ConfirmPassword
                  

                };

             UserMethods.CreateUser(AddedUsers);
              return RedirectToPage("GetUsers");
            }
            return Page();
        }
        public JsonResult IsEmailTaken(UserModel Users)
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
