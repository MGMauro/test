using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualMindTest.Repository.Interface;

namespace VirtualMindTest.Repository
{
    public class UserRepository : IUserRepository
    {
        private VirtualmindDBEntities db = new VirtualmindDBEntities();

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }
        public User GetUserById(int userId)
        {
            return db.Users.Where(u => u.UserId == userId).FirstOrDefault();
        }
        public void InsertUser(Models.User user)
        {
            User newUser = new User {
                UserName = user.Name,
                UserSurname = user.Surname,
                UserEmail = user.Email,
                UserPassword =user.Password};
            db.Users.Add(newUser);
            db.SaveChanges();
        }
        public void DeleteUserById(int userId)
        { 
            var user = db.Users.Where(u => u.UserId == userId).FirstOrDefault();
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            
        }
        public void UpdateUser(int userId, Models.User user)
        {
            var usertomodified = db.Users.Where(u => u.UserId == userId).FirstOrDefault();
            if (usertomodified != null)
            {
                usertomodified.UserName = string.IsNullOrWhiteSpace(user.Name) ? usertomodified.UserName : user.Name;
                usertomodified.UserSurname = string.IsNullOrWhiteSpace(user.Surname) ? usertomodified.UserSurname : user.Surname;
                usertomodified.UserEmail = string.IsNullOrWhiteSpace(user.Email) ? usertomodified.UserEmail : user.Email;
                usertomodified.UserPassword = string.IsNullOrWhiteSpace(user.Password) ? usertomodified.UserPassword : user.Password;
                db.SaveChanges();
            }
                          
        }
    }
}