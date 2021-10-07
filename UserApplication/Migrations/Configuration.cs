namespace UserApplication.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using UserApplication.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UserApplication.Models.ApplicationDbContext>
    {


        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

        }

        protected override void Seed(UserApplication.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            try { 
               if (!context.Roles.Any(r => r.Name == "Admin"))
               {
                   var store = new RoleStore<IdentityRole>(context);
                   var manager = new RoleManager<IdentityRole>(store);
                   var role = new IdentityRole { Name = "Admin" };

                   manager.Create(role);
               }
               if (!context.Roles.Any(r => r.Name == "Operator"))
               {
                   var store = new RoleStore<IdentityRole>(context);
                   var manager = new RoleManager<IdentityRole>(store);
                   var role = new IdentityRole { Name = "Operator" };

                   manager.Create(role);
               }
               if (!context.Users.Any(u => u.Email== "admin@gmail.com"))
               {
                   var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                   var user = new ApplicationUser
                   {
                       FirstName="Nadia",
                       LastName="Arshad",
                       Email = "admin@gmail.com",
                       UserName = "nadia",
                       PhoneNumber = "+111111111111",
                       EmailConfirmed = true,
                       PhoneNumberConfirmed = true,
                       SecurityStamp = Guid.NewGuid().ToString("D"),
                       PasswordHash = userManager.PasswordHasher.HashPassword("12345"),
                       LockoutEnabled = true,
                   };
                   userManager.Create(user);
                   userManager.AddToRole(user.Id, "Admin");
               }

               if (!context.Users.Any(u => u.Email == "operator@gmail.com"))
               {
                   var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                   var user = new ApplicationUser
                   {
                       FirstName = "operator",
                       LastName = "operator",
                       Email = "operator@gmail.com",
                       UserName = "operator",
                       PhoneNumber = "+2222222",
                       EmailConfirmed = true,
                       PhoneNumberConfirmed = true,
                       SecurityStamp = Guid.NewGuid().ToString("D"),
                       PasswordHash = userManager.PasswordHasher.HashPassword("123456"),
                       LockoutEnabled = true,
                   };
                   userManager.Create(user);
                   userManager.AddToRole(user.Id, "Operator");
               }

               context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {

                var sb = new System.Text.StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }





        }




        /* if (!context.Users.Any(u => u.UserName == "founder"))
          {
              var store = new UserStore<ApplicationUser>(context);
              var manager = new UserManager<ApplicationUser>(store);
              var user = new ApplicationUser { UserName = "founder" };

              manager.Create(user, "ChangeItAsap!");
              manager.AddToRole(user.Id, "AppAdmin");
          }*/

    }
    }
