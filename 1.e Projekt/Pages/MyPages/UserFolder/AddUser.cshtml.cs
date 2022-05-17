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
    public class AddUserModel : PageModel
    {
        public IUserInterface UserMethods;
        [BindProperty]
        public Users Users { get; set; }
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
    }
}
