using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.e_Projekt.Interfaces;
using _1.e_Projekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _1.e_Projekt.Pages.MyPages.UserFolder
{
    [Authorize]
    public class UpdateUserModel : PageModel
    {
        private readonly IUserInterface UserMethods;
        [BindProperty]
        public Users Users { get; set; }
        public UpdateUserModel(IUserInterface repo)
        {
            UserMethods = repo;
        }
        public IActionResult OnGet(int id)
        {
            Users = UserMethods.FindUser(id);
            return Page();
        }
        public IActionResult OnPost(Users user)
        {
            Users.UpdateUserInfo(user);
            return RedirectToAction("GetUsers");
        }
    }
}
