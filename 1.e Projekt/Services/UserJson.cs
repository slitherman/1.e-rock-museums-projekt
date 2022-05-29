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
        public int _counter = 0;
        
        public int UniqueId
        {
            get
            {
               return _counter++;
            }
        }

        readonly string filename = "/Data/UserDatabase.json/";

        public void  SaveJson (List<UserModel> UserCollection)
        {
            JsonFileWriter.WriteToJson3(UserCollection, filename);

        }
        public List<UserModel> ReadJson()
        {
            return JsonFileReader.ReadJson3(filename);
        }

        public List<UserModel> GetAllUsers()
        {
            return ReadJson();
        }

        public UserModel FindUser(int UserId)
        {
            List<UserModel> UserCollection = GetAllUsers();
            UserModel FoundUsers = UserCollection[UserId];
            return FoundUsers;
        
        }

        public void DeleteUser(int UserId)
        {
            List<UserModel> UserCollection = GetAllUsers();
            UserCollection.RemoveAt(UserId);
            JsonFileWriter.WriteToJson3(UserCollection, filename);

        }

        public void CreateUser(UserModel user)
        {
            List<UserModel> UserCollection = GetAllUsers();
  
            {
                if(user.UserId >= 0 && user.UserId < _counter)
              
                {

                    user.UserId = UniqueId;

                    UserCollection.Add(user);

                    JsonFileWriter.WriteToJson3(UserCollection, filename);
                }
            }
        }

        public void UpdateUserInfo(UserModel user)
        {
            List<UserModel> UserCollection = GetAllUsers();
            foreach (var ids in UserCollection) 
            {
                //if(ids.UserId.Equals(user.UserId))
                //{
                //    ids.FirstName = user.FirstName;
                //    ids.LastName = user.LastName;
                //    ids.Email = user.Email;
                //    ids.Password = user.Password;
                //    ids.UserIcon = user.UserIcon;
                //    JsonFileWriter.WriteToJson3(UserCollection, filename);
                //}
                //if(!ids.UserId.Equals(user.UserId))
                //{
                //    throw new Exception("error");
                //}
                UserCollection[user.UserId] = user;
            }
            }
        }
    }

