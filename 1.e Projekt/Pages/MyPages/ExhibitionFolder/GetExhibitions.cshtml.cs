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
    [AllowAnonymous]
    public class GetExhibitionsModel : PageModel
    {
        public IExhibitionRepo Exhibition;

        public GetExhibitionsModel(IExhibitionRepo  repo)
        {
            Exhibition = repo;

        }
        [BindProperty(SupportsGet =true)]
        public Dictionary<int, Exhibition> ExhibitionCollection { get; set; }

        public IActionResult OnGet()
        {


            ExhibitionCollection = Exhibition.GetExhibitions();
            return Page();

        }
    }
}
