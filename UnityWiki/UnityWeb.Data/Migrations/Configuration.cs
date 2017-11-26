namespace UnityWeb.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UnityWiki.DataModels;

    internal sealed class Configuration : DbMigrationsConfiguration<UnityWeb.Data.UnityWikiDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(UnityWeb.Data.UnityWikiDbContext context)
        {
            string[] roles = new string[]
            {
                "Admin"
            };

            // Seeding users with roles based on the same index
            string[] emails = new string[]
            {
                "admin@mail.bg"
            };

            // Create roles
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            foreach (var role in roles)
            {
                if (!(context.Set<IdentityRole>().Any(r => r.Name == role)))
                {
                    roleManager.Create(new IdentityRole() { Name = role });
                }
            }

            // Create user
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            for (int i = 0; i < emails.Length; i++)
            {
                string email = emails[i];
                if (!(context.Set<User>().Any(u => u.Email == email)))
                {
                    CreateUser(userManager, roles[i], email, "12345q");
                }
            }

            context.SaveChanges();
        }

        private static void CreateUser(UserManager<User> userManager, string role, string email, string password)
        {
            var superAdmin = new User { UserName = email, Email = email };
            userManager.Create(superAdmin, password);
            userManager.AddToRole(superAdmin.Id, role);
        }
    }
}
