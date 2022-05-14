using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.e_Projekt.Interfaces;
using _1.e_Projekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _1.e_Projekt.Pages.MyPages
{
    public class GetExhibitionsModel : PageModel
    {
        public IExhibition Exhibition;

        public GetExhibitionsModel(IExhibition  repo)
        {
            Exhibition = repo;

        }
        [BindProperty]
        private Dictionary<int, Exhibition> ExhibitionCollection { get; set; }

        public IActionResult OnGet()
        {


            ExhibitionCollection = Exhibition.GetExhibitions();
            return Page();

        }
    }
}
