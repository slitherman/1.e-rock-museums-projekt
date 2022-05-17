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
    public class GetPresentationsModel : PageModel
    {
        public IPresentation PresentationMethods;
        [BindProperty]
        private  Dictionary<int, Exhibition> Presentations { get; set; }
        public GetPresentationsModel(IPresentation repo)
        {
            PresentationMethods = repo;

        }
        public IActionResult OnGet()
        {
            return Page();

        }
        public IActionResult OnPost()
        {
            Presentations = PresentationMethods.GetPreentations();
            return Page();
        }
    }
}
