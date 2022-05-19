using _1.e_Projekt.Helpers;
using _1.e_Projekt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Services
{
    public class UserJson: IUserInterface
    {

       readonly string filename = "/Data/UserDatabase.json/";

        public void  SaveJson (Dictionary<int, Users> UserCollection)
        {
            JsonFileWriter.WriteToJson3(UserCollection, filename);

        }
        public Dictionary<int, Users> ReadJson()
        {
            return JsonFileReader.ReadJson3(filename);
        }

        public Dictionary<int, Users> GetAllUsers()
        {
            return ReadJson();
        }

        public Users FindUser(int UserId)
        {
            Dictionary<int, Users> UserCollection = GetAllUsers();
            Users FoundUsers = UserCollection[UserId];
            return FoundUsers;
        
        }

        public void DeleteUser(int UserId)
        {
            Dictionary<int, Users> UserCollection = GetAllUsers();
            UserCollection.Remove(UserId);
            JsonFileWriter.WriteToJson3(UserCollection, filename);

        }

        public void CreateUser(Users user)
        {
            Dictionary<int, Users> UserCollection = GetAllUsers();
  
            {
                if(!UserCollection.Keys.Contains(user.UserId))
              
                {
                    UserCollection.Add(user.UserId, user);
                    JsonFileWriter.WriteToJson3(UserCollection, filename);
                }
            }
        }

        public void UpdateUserInfo(Users user)
        {
            Dictionary<int, Users> UserCollection = GetAllUsers();
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

