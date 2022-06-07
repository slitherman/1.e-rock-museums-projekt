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
    public class DeleteUserModel : PageModel
    {
        public IUserInterface UserMethods;
        [BindProperty]
        public Users Users { get; set; }
        public DeleteUserModel(IUserInterface repo)
        {
            UserMethods = repo;
        }
        public IActionResult OnGet(int id)
        {
            Users.FindUser(id);
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            Users.DeleteUser(id);
            return RedirectToPage("GetUsers");

        }
    }
}
