namespace QRInfoSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using QRInfoSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QRInfoSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(QRInfoSystem.Data.QRInfoSystemDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin") ||
                !context.Roles.Any(r => r.Name == "Teacher"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var roleAdmin = new IdentityRole { Name = "Admin" };
                var roleTeacher = new IdentityRole { Name = "Teacher" };

                manager.Create(roleAdmin);
                manager.Create(roleTeacher);
            }

            if (!context.Users.Any(u => u.UserName == "Admin@g.c"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Admin@g.c",Email = "Admin@g.c" };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
