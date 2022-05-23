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

namespace _1.e_Projekt.Pages.MyPages
{
    [Authorize]
    public class UpdateExhibitionsModel : PageModel
    {
        public IExhibitionRepo Exhibition;
        [BindProperty]
        public Exhibition UpdatedExhibition { get; set; }

        public UpdateExhibitionsModel(IExhibitionRepo repo)
        {
            Exhibition = repo;
        }

        public IActionResult OnGet(int id)
        {
            UpdatedExhibition = Exhibition.GetExhibition(id);
            return Page();
        }

    
        public IActionResult OnPost(Exhibition ex)
        {
            Exhibition.UpdateExhibition(ex);
            return RedirectToPage("GetExhibitions");
        }
    }
}
