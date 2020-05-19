using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.IRepo
{
    public interface ICrudoContext
    {

       DbSet<Advertisement> Advertisements { get; set; }
       DbSet<Category> Categories { get; set; }
       DbSet<User> WebsiteUsers { get; set; }

        int SaveChanges();
        Database Database { get; }

        DbEntityEntry Entry(object entity);
    }
}
