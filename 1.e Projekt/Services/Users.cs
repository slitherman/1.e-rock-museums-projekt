using _1.e_Projekt.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Services
{
    public class Users : IUserInterface
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
        [RegularExpression("^[0-9a-zA-z]+[!.?_-,]{0-1}[0-9a-zA-z]+[@][a-zA-z]+[.][a-zA-z]{2.3}[.][a-zA-z]{2.3}$")]
        public string Email { get; set; }
        [Required(ErrorMessage = "you must enter something, literally anything")]
        [DataType(DataType.Password)]
        [RegularExpression("^[0-9]{1.10}")]
        public string Password { get; set; }
        public string UserIcon { get; set; }
        [Key]
        [DataType(DataType.Custom)]
        [Required(ErrorMessage = "you must enter something, literally anything")]
        public int UserId { get; set; }

        public Dictionary<int, Users> UserCollection { get; set; }

        public Users()
        {
            UserCollection = new Dictionary<int, Users>();

            UserCollection.Add(1, new Users() { FirstName = "Lachy", LastName = "Shannon", Email = "lachyshannon@gmail.com", Password = "12345", UserIcon = "UserIcon.png", UserId=1 });
            UserCollection.Add(2, new Users() { FirstName = "Brandon", LastName = "Mccartney", Email = "brandonmccartney@gmail.com", Password = "44443", UserIcon = "UserIcon.png", UserId=2});
            UserCollection.Add(3, new Users() { FirstName = "Larry", LastName = "David", Email = "larrydavid@gmail.com", Password = "11111", UserIcon = "UserIcon.png" , UserId=3});
            UserCollection.Add(4, new Users() { FirstName = "Saloth ", LastName = "Sar", Email = "PolPot@gmail.com", Password = "22222", UserIcon = "UserIcon.png" , UserId=4});

        }

        public Dictionary<int, Users> GetAllUsers()
        {
            return UserCollection;
        }

        public Users FindUser(int UserId)
        {
            return UserCollection[UserId];
        }
        public void DeleteUser( int UserId)
        {
            UserCollection.Remove(UserId);
        } 
        public void CreateUser(Users user)
        {
           if(!UserCollection.Keys.Contains(UserId))
            {
                UserCollection.Add(UserId, user);
            }
        }
        public void UpdateUserInfo(Users user)
        {
            foreach (var ids in UserCollection.Values)
            {
                if (UserId.Equals(user.UserId))
                {
                  // the user shouldnt be able to change their own id
                    ids.FirstName = user.FirstName;
                    ids.LastName = user.LastName;
                    ids.Email = user.Email;
                    ids.Password = user.Password;
                    ids.UserIcon = user.UserIcon;
                }
            }
            
        }
        }
    }

