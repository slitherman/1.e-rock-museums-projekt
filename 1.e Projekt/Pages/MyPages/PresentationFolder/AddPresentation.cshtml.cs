using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.e_Projekt.Helpers;
using _1.e_Projekt.Interfaces;
using _1.e_Projekt.Models;
using _1.e_Projekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _1.e_Projekt.Pages.MyPages.PresentationFolder
{
    //[Authorize]
    public class AddPresentationModel : PageModel
    {

        private readonly IExhibitionRepo PresentationMethods;
        [BindProperty]
        [PageRemote(PageHandler = " IsPresentationNameTaken", HttpMethod ="Get", ErrorMessage ="Error presentation already exists")]
        public Exhibition Presentation { get; set; }
        public AddPresentationModel(IExhibitionRepo repo)
        {
            PresentationMethods = repo;
        }
        public IActionResult OnGet()
        {
            return Page();
            
        }
        public IActionResult OnPost()
        {
        
            PresentationMethods.AddPresentation(Presentation);
            IsPresentationNameTaken(Presentation);
            return RedirectToPage("GetPresentations");
        }

        public JsonResult IsPresentationNameTaken(Exhibition Pre)
        {
            string filename = "Data/JsonPresentations.json";
            JsonFileReader.ReadJson2(filename);

            if (Pre.PresentationName.Contains(filename))
            {
                return new JsonResult(false);
            }
            return new JsonResult(true);
        }
    }
}
