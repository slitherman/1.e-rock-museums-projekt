﻿using _1.e_Projekt.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using _1.e_Projekt.Models;

namespace _1.e_Projekt.Services
{
    public class Users : IUserInterface
    {
     

      public Dictionary<int, User> UserCollection { get; set; }

        public Users()
        {
            UserCollection = new Dictionary<int, User>();

            UserCollection.Add(1, new User() { FirstName = "Lachy", LastName = "Shannon", Email = "lachyshannon@gmail.com", Password = "12345", UserIcon = "UserIcon.png", Role="Admin", UserId=1 });
            UserCollection.Add(2, new User() { FirstName = "Brandon", LastName = "Mccartney", Email = "brandonmccartney@gmail.com", Password = "44443", UserIcon = "UserIcon.png", Role="Admin", UserId=2});
            UserCollection.Add(3, new User() { FirstName = "Larry", LastName = "David", Email = "larrydavid@gmail.com", Password = "11111", UserIcon = "UserIcon.png", Role="User", UserId=3});
            UserCollection.Add(4, new User() { FirstName = "Saloth ", LastName = "Sar", Email = "PolPot@gmail.com", Password = "22222", UserIcon = "UserIcon.png", Role="User", UserId=4});

        }

        public Dictionary<int, User> GetAllUsers()
        {
            return UserCollection;
        }

        public User FindUser(int UserId)
        {
            return UserCollection[UserId];
        }
        public void DeleteUser( int UserId)
        {
            UserCollection.Remove(UserId);
        } 
        public void CreateUser(User user)
        {
           if(!UserCollection.Keys.Contains(user.UserId))
            {
                UserCollection.Add(user.UserId, user);
            }
        }
        public void UpdateUserInfo(User user)
        {
            foreach (var ids in UserCollection.Values)
            {
                if (ids.UserId.Equals(user.UserId))
                {
                  // the user shouldnt be able to change their own id
                    ids.FirstName = user.FirstName;
                    ids.LastName = user.LastName;
                    ids.Email = user.Email;
                    ids.Password = user.Password;
                    ids.UserIcon = user.UserIcon;
                   if(!ids.UserId.Equals(user.UserId))
                    {
                        throw new Exception("error");
                    }
                }
            }
            
        }

       
    }
    }

