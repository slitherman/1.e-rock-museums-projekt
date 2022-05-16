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
    [AllowAnonymous]
    public class GetExhibitionModel : PageModel
    {
        public IExhibition Exhibitions;
        public Exhibition ReturnedExhibition { get; set; }
        public GetExhibitionModel(IExhibition repo)
        {
            Exhibitions = repo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            ReturnedExhibition = Exhibitions.GetExhibition(id);
            return RedirectToPage("GetExhibitions");
        }
    }
}
