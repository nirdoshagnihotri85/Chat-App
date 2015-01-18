using LetsChatApi.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsChat.DAO
{
    public class UserDAO
    {
        LetsChatEntities entities = new LetsChatEntities();

        public Int64 Login(string username)
        {
            User user;

            if (!entities.Users.Any(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                user = new User
                {
                    Username = username,
                    LoggedIn = true
                };

                entities.Users.Add(user);
                entities.SaveChanges();
            }
            else
            {
                user = entities.Users.FirstOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

                user.LoggedIn = true;
                entities.Entry(user).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
            }

            return user.UserId;
        }

        public List<string> GetOnlineUsers(Int64 userId)
        {
            return entities.Users.Where(x => x.UserId != userId && x.LoggedIn).Select(x => x.Username).ToList();
        }

        public void LogOut(Int64 userId)
        {
            var user = entities.Users.FirstOrDefault(x => x.UserId == userId);
            user.LoggedIn = false;
            entities.Entry(user).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
        }

        public Int32 LoggedInUserCount()
        {
            return entities.Users.Count(x => x.LoggedIn);
        }
    }
}