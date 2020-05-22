using System.Data.Entity.Validation;
using System.Diagnostics;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Repository.Models;

namespace Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Repository.Models.CrudoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        public void RunSeed(CrudoContext db)
        {
            Seed(db);
        }

        protected override void Seed(CrudoContext context)
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
            if (!context.Users.Any(u => u.UserName == "administrator@mvc.pl"))
            {
                var store = new UserStore<InternalUser>(context);
                var manager = new UserManager<InternalUser>(store);
                var user = new InternalUser {UserName = "administrator@mvc.pl", Name = "Maciek", SurName = "Zietek",
                    EmailAddress = "administrator@mvc.pl", RegisterDate = DateTime.Now, IfConfirm = true, Email = "administrator@mvc.pl"};
                try
                {
                    var adminresult = manager.Create(user, "Maciek12_!");
                    if (adminresult.Succeeded)
                        manager.AddToRole(user.Id, "Admin");
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var validationErrors in e.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
                    }
                }
                
            }

        }

    }
}
