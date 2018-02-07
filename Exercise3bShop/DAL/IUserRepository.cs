using Exercise3bShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise3bShop.DAL
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int UserID);

        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int UserID);
        void Save();
    }
}