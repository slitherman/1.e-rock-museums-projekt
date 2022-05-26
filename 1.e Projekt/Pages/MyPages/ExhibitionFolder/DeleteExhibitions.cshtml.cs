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

    //[Authorize]
    public class DeleteExhibitionsModel : PageModel
    {
         public IExhibitionRepo Exhibition;
        [BindProperty]
        public Exhibition DeletedExhibition { get; set; }
        public DeleteExhibitionsModel(IExhibitionRepo repo)
        {
            Exhibition = repo;
        }
   
        public IActionResult OnGet(int id)
        {
            DeletedExhibition = Exhibition.GetExhibition(id);
            return Page();

        }
        public IActionResult OnPost(int id)
        {
            Exhibition.DeleteExhibition(id);
            return RedirectToPage("GetExhibitions");
        }
    }
}
