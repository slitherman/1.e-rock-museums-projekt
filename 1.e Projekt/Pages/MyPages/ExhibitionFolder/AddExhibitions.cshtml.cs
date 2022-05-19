using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.e_Projekt.Helpers;
using _1.e_Projekt.Interfaces;
using _1.e_Projekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _1.e_Projekt.Pages.MyPages
{
    [Authorize]
   
    public class AddExhibitionsModel : PageModel
    {
        
        public IExhibition Exhibition;
        [BindProperty]
        [PageRemote(PageHandler = " IsExhibitionNameInUse ", HttpMethod ="Get", ErrorMessage ="Exhibition name is already in use")]
        public Exhibition AddedExhibition { get; set; }

        public AddExhibitionsModel(IExhibition repo)
        {
            Exhibition = repo;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(Exhibition ex)
        {
            AddedExhibition.AddExhibition(ex);
            return RedirectToPage("GetAllExhibitions");
        }
        public JsonResult IsExhibitionNameInUse (Exhibition ex)
        {
            string filename = "/Data/UserDatabase.json/";
            JsonFileReader.ReadJson(filename);
            if (ex.ExhibitionName.Contains(filename))
            {
                return new JsonResult(false);
            }
            return new JsonResult(true);
        }
    }
}
