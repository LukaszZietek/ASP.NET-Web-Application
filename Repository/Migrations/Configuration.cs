using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Repository.Models;

namespace Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.Models.CrudoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Repository.Models.CrudoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();


            SeedRoles(context);
            SeedUsers(context);

        }

        private void SeedRoles(CrudoContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole {Name = "Admin"};

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "CommonUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole {Name = "CommonUser"};

                manager.Create(role);

            }
        }

        private void SeedUsers(CrudoContext context)
        {
            if (!context.Users.Any(u => u.UserName == "Administrator"))
            {
                var store = new UserStore<InternalUser>(context);
                var manager = new UserManager<InternalUser>(store);
                var user = new InternalUser {UserName = "Administrator"};

                manager.Create(user,"123456");
                manager.AddToRole(user.Id, "Admin");
            }

        }

    }
}
