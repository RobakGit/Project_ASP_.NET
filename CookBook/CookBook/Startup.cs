using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CookBook.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using CookBook.Models;

namespace CookBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<CookBookContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CookBookDb")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/deniedAccess";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


                using (var serviceScope = app.ApplicationServices.CreateScope())
                {

                    var dbContext = serviceScope.ServiceProvider.GetRequiredService<CookBookContext>();

                    dbContext.Database.EnsureCreated();
                    if (!dbContext.Users.Any())
                    {
                        User admin = new() { Login = "root", Password = "toor", Role = "ADMIN" };
                        User user = new() { Login = "user", Password = "resu", Role = "USER" };

                        var users = new User[] { admin, user };

                        Category testCategory = new()
                        {
                            Name = "TestCategory"
                        };

                        Ingredient testIngredient1 = new()
                        {
                            Name = "TestIngredient1"
                        };
                        Ingredient testIngredient2 = new()
                        {
                            Name = "TestIngredient2"
                        };
                        Ingredient testIngredient3 = new()
                        {
                            Name = "TestIngredient3"
                        };

                        var ingredients = new Ingredient[] { testIngredient1, testIngredient2, testIngredient3 };

                        Measure testMeasure1 = new()
                        {
                            Name = "g"
                        };

                        Measure testMeasure2 = new()
                        {
                            Name = "L"
                        };

                        var measures = new Measure[] { testMeasure1, testMeasure2 };

                        RecipeIngredient testRecipeIngredient1 = new()
                        {
                            Ingredient = testIngredient1,
                            Measure = testMeasure1,
                            Ammount = 200
                        };
                        RecipeIngredient testRecipeIngredient2 = new()
                        {
                            Ingredient = testIngredient2,
                            Measure = testMeasure2,
                            Ammount = 200
                        };
                        RecipeIngredient testRecipeIngredient3 = new()
                        {
                            Ingredient = testIngredient3,
                            Measure = testMeasure2,
                            Ammount = 200
                        };

                        List<RecipeIngredient> recipeIngredients = new()
                        {
                            testRecipeIngredient1,
                            testRecipeIngredient2,
                            testRecipeIngredient3
                        };

                        Recipe testRecipe = new()
                        {
                            Name = "TestRecipe",
                            Category = testCategory,
                            RecipeIngredients = recipeIngredients,
                            Owner = user,
                            CookingTime = new(1, 30, 0)
                        };

                        foreach (User u in users)
                        {
                            dbContext.Users.Add(u);
                        }


                        foreach (Ingredient i in ingredients)
                        {
                            dbContext.Ingredients.Add(i);
                        }

                        foreach (Measure m in measures)
                        {
                            dbContext.Measures.Add(m);
                        }

                        foreach (RecipeIngredient ri in recipeIngredients)
                        {
                            dbContext.RecipeIngredients.Add(ri);
                        }

                        dbContext.Recipes.Add(testRecipe);

                        dbContext.SaveChanges();
                    }

                }

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
