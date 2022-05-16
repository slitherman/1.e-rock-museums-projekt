using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.e_Projekt.Interfaces;
using _1.e_Projekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _1.e_Projekt.Pages.MyPages
{
    [Authorize]
    public class DeleteExhibitionsModel : PageModel
    {
         public IExhibition Exhibition;
        [BindProperty(SupportsGet =true)]
        public Exhibition DeletedExhibition { get; set; }
        public DeleteExhibitionsModel(IExhibition repo)
        {
            Exhibition = repo;
        }
        public IActionResult OnGet(int id)
        {
            DeletedExhibition.DeleteExhibition(id);
            return RedirectToPage("GetExhibitions");

        }
    }
}
