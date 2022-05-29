﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace _1.e_Projekt.Models
{
    public class UserModel
    {
  
        [Required(ErrorMessage = "you must enter something, literally anything")]
        [DisplayName("First Name")]
        [StringLength(40, MinimumLength = 4)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "you must enter something, literally anything")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "you must enter something, literally anything")]
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        //not certain that my regular expression is correct, might have to fix it later
        //[RegularExpression("^[0-9a-zA-z]+[!.?_-,]{0-1}[0-9a-zA-z]+[@][a-zA-z]+[.][a-zA-z]{2.3}[.][a-zA-z]{2.3}$")]
        // comparing my regx to one i found online
        //[RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }
        [Required(ErrorMessage = "you must enter something, literally anything")]
        [DataType(DataType.Password)]
        [RegularExpression("^[0-9]{1.10}")] 
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "passwords do not match")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.ImageUrl)]
        public string UserIcon { get; set; }
        [Key]
        [DataType(DataType.Custom)]
        public int UserId { get; set; }


        //given user role. Not every user should have administrative permissions 

        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 3)]
        public string Role { get; set; }
    }
}