using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.IRepo
{
    public interface ICategoryRepo
    {

        IQueryable<Category> GetCategories();

        IQueryable<Advertisement> GetAdvertisementsByCategories(int id);

        Category GetCategory(int id);

        void AddCategory(Category cat);

        void DeleteCategory(int id);

        void UpdateCategory(Category cat);

        void SaveChanges();

    }
}
