using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Models
{
    public class Exhibition
    {

        [Key]
        [Required(ErrorMessage = "ExhibitionId is required")]
        [DisplayName("ExhibitionId")]

        public int ExhibitionId { get; set; }
        [Required(ErrorMessage = "Exhibition Name is required")]
        [DisplayName("Exhibition´Name")]
        [StringLength(60, MinimumLength = 3)]
    
        public string ExhibitionName { get; set; }
        [Required(ErrorMessage = "Presentation Name  is required")]
        [DisplayName("Presentation Name")]
        [StringLength(60, MinimumLength = 3)]
        public string PresentationName { get; set; }
        [Key]
        [Required(ErrorMessage = "Presentation Id is required")]
        [DisplayName("Presentation Id")]
        public int PresentationId { get; set; }

        [DisplayName("Image Name")]
        public string ImageName { get; set; }

    }
}
