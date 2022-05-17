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
    [AllowAnonymous]
    public class GetUsersModel : PageModel
    {
      
        private IUserInterface UserMethods; 
        [BindProperty(SupportsGet =true)]
        private Dictionary<int, Users> ExhibitionCollection { get; set; }
        public GetUsersModel(IUserInterface repo)
        {
            UserMethods = repo;
        }
        public IActionResult OnGet()
        {
            ExhibitionCollection = UserMethods.GetAllUsers();
            return Page();
            
        }
    }
}
