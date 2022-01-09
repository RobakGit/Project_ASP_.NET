using CookBook.Models;
using System;
using System.Linq;

namespace CookBook.Data
{
    public class DbInitializer
    {
        public static void Initialize(CookBookContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
            new User{Login="root",Password="toor",Role="ADMIN"},
            new User{Login="user",Password="resu",Role="USER"},
            };
            foreach (User user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}
