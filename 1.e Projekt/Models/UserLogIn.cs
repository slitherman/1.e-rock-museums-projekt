using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Models
{
    public class UserLogin
    {
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        [Required(ErrorMessage = "error you forgot to enter your email")]
        //[RegularExpression("^[0-9a-zA-z]+[!.?_-,]{0-1}[0-9a-zA-z]+[@][a-zA-z]+[.][a-zA-z]{2.3}[.][a-zA-z]{2.3}$")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        //[RegularExpression("^[0-9]{1.10}")]
        public string Password { get; set; }
        [DisplayName(" Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "passwords do not match")]
        public string ConfirmPassword { get; set; }

    }
}
