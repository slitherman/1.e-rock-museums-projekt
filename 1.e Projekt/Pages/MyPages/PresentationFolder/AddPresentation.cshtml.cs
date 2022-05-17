using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.e_Projekt.Interfaces;
using _1.e_Projekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _1.e_Projekt.Pages.MyPages.PresentationFolder
{
    [Authorize]
    public class AddPresentationModel : PageModel
    {

        private IPresentation PresentationMethods;
        [BindProperty]
        public Exhibition Presentations { get; set; }
        public AddPresentationModel(IPresentation repo)
        {
            PresentationMethods = repo;
        }
        public IActionResult OnGet(int id)
        {
            Presentations = PresentationMethods.readPresentation(id);
            return Page();
            

        }
        public IActionResult OnPost()
        {
            PresentationMethods.AddPresentation(Presentations);
            return RedirectToPage("GetPresentations");
        }
    }
}
