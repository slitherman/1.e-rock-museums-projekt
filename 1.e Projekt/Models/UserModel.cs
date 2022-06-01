using System;
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

     
        public string FirstName { get; set; }

        public string LastName { get; set; }



        //public string FullName
        //{
        //    get
        //    {
        //        return FirstName + LastName;
        //    }
        //}



        //not certain that my regular expression is correct, might have to fix it later
        //[RegularExpression("^[0-9a-zA-z]+[!.?_-,]{0-1}[0-9a-zA-z]+[@][a-zA-z]+[.][a-zA-z]{2.3}[.][a-zA-z]{2.3}$")]
        // comparing my regx to one i found online
        //[RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }
     
 
        public string Password { get; set; }
   
        public string ConfirmPassword { get; set; }
     
        public string UserIcon { get; set; }
       
     
        public int UserId { get; set; }




    
        public string Role { get; set; }
    }
}
