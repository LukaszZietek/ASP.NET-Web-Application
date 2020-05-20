using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Repository.IRepo;

namespace Repository.Models
{
    public class CrudoContext : IdentityDbContext, ICrudoContext
    {


        public CrudoContext() : base("DefaultConnection")
        {
        }

        public static CrudoContext Create()
        {
            return new CrudoContext();
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<InternalUser> WebsiteUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Advertisement>().HasRequired(x=>x.InternalUser).WithMany(x=>x.Advertisements)
                .HasForeignKey(x=>x.InternalUserId).WillCascadeOnDelete(true);

        }

        
    }
}