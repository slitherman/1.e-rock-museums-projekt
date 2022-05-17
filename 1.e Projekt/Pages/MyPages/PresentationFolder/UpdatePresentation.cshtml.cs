using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.e_Projekt.Interfaces;
using _1.e_Projekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _1.e_Projekt.Pages.MyPages.PresentationFolder
{
    public class UpdatePresentationModel : PageModel
    {
        public IPresentation PresentationMethods;
        [BindProperty]
        public Exhibition Presentation { get; set; }
        public UpdatePresentationModel(IPresentation repo)
        {
            PresentationMethods = repo;
        }
        public IActionResult OnGet(int id)
        {
            Presentation = PresentationMethods.readPresentation(id);
            return Page();
        }
        public IActionResult OnPost(Exhibition pre)
        {
            PresentationMethods.UpdatePresentation(pre);
            return RedirectToPage("GetPresentations");
        }
    }
}
