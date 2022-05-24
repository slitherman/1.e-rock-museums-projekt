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
            Random RndiD = new Random();
            UserCollection = new Dictionary<int, User>();

            UserCollection.Add(1, new User() { FirstName = "Lachy", LastName = "Shannon", Email = "lachyshannon@gmail.com", Password = "12345", UserIcon = "UserIcon.png", Role="Admin", UserId= RndiD.Next() });
            UserCollection.Add(2, new User() { FirstName = "Brandon", LastName = "Mccartney", Email = "brandonmccartney@gmail.com", Password = "44443", UserIcon = "UserIcon.png", Role="Admin", UserId= RndiD.Next() });
            UserCollection.Add(3, new User() { FirstName = "Larry", LastName = "David", Email = "larrydavid@gmail.com", Password = "11111", UserIcon = "UserIcon.png", Role="User", UserId= RndiD.Next() });
            UserCollection.Add(4, new User() { FirstName = "Saloth ", LastName = "Sar", Email = "PolPot@gmail.com", Password = "22222", UserIcon = "UserIcon.png", Role="User", UserId=RndiD.Next()});

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
        //???
        public void CreateUser(User user)
        {
           if(!UserCollection.Keys.ToList().Contains(user.UserId))
            {

                Random RndiD = new Random();
                RndiD.Equals(UserCollection[user.UserId]);
                RndiD.Equals(user.UserId);
                UserCollection.Add(RndiD.Next(), user);

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

