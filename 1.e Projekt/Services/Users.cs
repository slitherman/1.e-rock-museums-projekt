using _1.e_Projekt.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using _1.e_Projekt.Models;
using _1.e_Projekt.Helpers;

namespace _1.e_Projekt.Services
{
    public class Users : IUserInterface
    {
     

      public List<UserModel> UserCollection { get; set; }
      public Random RndiD = new Random();
        private int _counter = 0;

        public int UniqueID
        {
            get
            {
                return _counter++;
            }
        }

        public Users()
        {
         
       
            UserCollection = new List<UserModel>();

            UserCollection.Add(new UserModel() { FirstName = "Lachy", LastName = "Shannon", Email = "lachyshannon@gmail.com", Password = "12345", UserIcon = "UserIcon.png", Role="Admin", UserId= UniqueID });
            UserCollection.Add(new UserModel() { FirstName = "Brandon", LastName = "Mccartney", Email = "brandonmccartney@gmail.com", Password = "44443", UserIcon = "UserIcon.png", Role="Admin", UserId= UniqueID });
            UserCollection.Add(new UserModel() { FirstName = "Larry", LastName = "David", Email = "larrydavid@gmail.com", Password = "11111", UserIcon = "UserIcon.png", Role="User", UserId= UniqueID });
            UserCollection.Add(new UserModel() { FirstName = "Saloth ", LastName = "Sar", Email = "PolPot@gmail.com", Password = "22222", UserIcon = "UserIcon.png", Role="User", UserId= UniqueID });

        }

       
        public void GetRandId()
        {
          
        } 
        public List<UserModel> GetAllUsers()
        {
            return UserCollection;
        }

        public UserModel FindUser(int UserId)
        {
            return UserCollection[UserId];
        }
        public void DeleteUser( int UserId)
        {
            UserCollection.RemoveAt(UserId);
        } 
        //???
        public void CreateUser(UserModel user)
        {
            if(user.UserId >= 0 && user.UserId < _counter)
            {
                user.UserId = UniqueID;
                UserCollection.Add(user);
            }

           //if(!UserCollection.Keys.ToList().Contains(user.UserId))
           // {
           //     RndiD.Equals(UserCollection[user.UserId]);
           //     RndiD.Equals(user.UserId);
           //     UserCollection.Add(RndiD.Next(), user);
           // }
        }
        public void UpdateUserInfo(UserModel user)
        {
            foreach (var ids in UserCollection)
            {
                //if (ids.UserId.Equals(user.UserId))
                //{
                //    // the user shouldnt be able to change their own id
                //    ids.FirstName = user.FirstName;
                //    ids.LastName = user.LastName;
                //    ids.Email = user.Email;
                //    ids.Password = user.Password;
                //    ids.UserIcon = user.UserIcon;
                //    if (!ids.UserId.Equals(user.UserId))
                //    {
                //        throw new Exception("error");
                //    }
                    UserCollection[user.UserId] = user;
                }
            }

        }
    }
     

       
    
   

