using _1.e_Projekt.Models;
using _1.e_Projekt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Interfaces
{
   public interface IUserInterface
    {
        List<User> GetAllUsers();
        User FindUser(int UserId);
        void DeleteUser(int UserId);
        void CreateUser(User user);
        void UpdateUserInfo(User user);

    }
}
