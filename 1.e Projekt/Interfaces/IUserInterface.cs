using _1.e_Projekt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Interfaces
{
    interface IUserInterface
    {
        Dictionary<int, Users> GetAllUsers();
        Users FindUser(int UserId);
        void DeleteUser(int UserId);
        void CreateUser(Users user);
        void UpdateUserInfo(Users user);

    }
}
