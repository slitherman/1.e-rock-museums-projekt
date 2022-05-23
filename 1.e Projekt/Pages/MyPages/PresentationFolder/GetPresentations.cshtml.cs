using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.e_Projekt.Interfaces;
using _1.e_Projekt.Models;
using _1.e_Projekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _1.e_Projekt.Pages.MyPages.PresentationFolder
{
    [AllowAnonymous]
    public class GetPresentationsModel : PageModel
    {
        public IExhibitionRepo PresentationMethods;
        [BindProperty(SupportsGet =true)]
       public  Dictionary<int, Exhibition> Presentations { get; set; }
        public GetPresentationsModel(IExhibitionRepo repo)
        {
            PresentationMethods = repo;

        }
        public IActionResult OnGet()
        {
            Presentations = PresentationMethods.GetPreentations();
            return Page();

        }
      
    }
}
