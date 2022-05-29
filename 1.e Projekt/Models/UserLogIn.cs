using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Models
{
    public class UserLogIn
    {
        public string Email { get; set; }
        [Required(ErrorMessage = "error you forgot to enter your email")]
        [DataType(DataType.Password)]
        [RegularExpression("^[0-9]{1.10}")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "passwords do not match")]
        public string ConfirmPassword { get; set; }

    }
}
