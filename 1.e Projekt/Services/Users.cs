using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Services
{
    public class Users
    {
        [Required(ErrorMessage ="you must enter something, literally anything"), MinLength(4), MaxLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "you must enter something, literally anything"), MinLength(4), MaxLength(100)]
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }

        public Users()
        {

        }
    }
}
