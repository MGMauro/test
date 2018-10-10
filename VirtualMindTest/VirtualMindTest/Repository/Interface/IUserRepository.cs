using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualMindTest.Repository.Interface
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserById(int userId);
        void InsertUser(Models.User user);
        void DeleteUserById(int userId);
        void UpdateUser(int userId, Models.User user);
    }
}