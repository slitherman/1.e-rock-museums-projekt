using _1.e_Projekt.Helpers;
using _1.e_Projekt.Interfaces;
using _1.e_Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Services
{
    public class UserJson: IUserInterface
    {
        Random RndiD = new Random();
        readonly string filename = "/Data/UserDatabase.json/";

        public void  SaveJson (Dictionary<int, User> UserCollection)
        {
            JsonFileWriter.WriteToJson3(UserCollection, filename);

        }
        public Dictionary<int, User> ReadJson()
        {
            return JsonFileReader.ReadJson3(filename);
        }

        public Dictionary<int, User> GetAllUsers()
        {
            return ReadJson();
        }

        public User FindUser(int UserId)
        {
            Dictionary<int, User> UserCollection = GetAllUsers();
            User FoundUsers = UserCollection[UserId];
            return FoundUsers;
        
        }

        public void DeleteUser(int UserId)
        {
            Dictionary<int, User> UserCollection = GetAllUsers();
            UserCollection.Remove(UserId);
            JsonFileWriter.WriteToJson3(UserCollection, filename);

        }

        public void CreateUser(User user)
        {
            Dictionary<int, User> UserCollection = GetAllUsers();
  
            {
                if(!UserCollection.Keys.Contains(user.UserId))
              
                {
                    
                    RndiD.Equals(UserCollection[user.UserId]);
                    RndiD.Equals(user.UserId);
                    UserCollection.Add(RndiD.Next(), user);
                    JsonFileWriter.WriteToJson3(UserCollection, filename);
                }
            }
        }

        public void UpdateUserInfo(User user)
        {
            Dictionary<int, User> UserCollection = GetAllUsers();
            foreach (var ids in UserCollection.Values) 
            {
                if(ids.UserId.Equals(user.UserId))
                {
                    ids.FirstName = user.FirstName;
                    ids.LastName = user.LastName;
                    ids.Email = user.Email;
                    ids.Password = user.Password;
                    ids.UserIcon = user.UserIcon;
                    JsonFileWriter.WriteToJson3(UserCollection, filename);
                }
                if(!ids.UserId.Equals(user.UserId))
                {
                    throw new Exception("error");
                }
            }
            }
        }
    }

