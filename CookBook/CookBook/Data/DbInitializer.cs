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
            var catergories = new Category[]
           {
            new Category{Name="Starters"},
            new Category{Name="Main dishes"},
            new Category{Name="Drinks"},

           };
            foreach (Category category in catergories)
            {
                context.Categories.Add(category);
            }
            var ingredients = new Ingredient[]
           {
            new Ingredient{Name=""},


           };
            foreach (Ingredient ingredient in ingredients)
            {
                context.Ingredients.Add(ingredient);
            }
            var measurments = new Measure[]
           {
            new Measure{Name="g"},
            new Measure{Name="kg"},
            new Measure{Name="L"},
            new Measure{Name="ml"},
            new Measure{Name="L"},

           };
            foreach (Measure measure in measurments)
            {
                context.Measures.Add(measure);
            }
            context.SaveChanges();
        }
    }
}
