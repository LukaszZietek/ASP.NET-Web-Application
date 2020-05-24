using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Repository.IRepo;
using Repository.Models;

namespace Repository.Repo
{
    public class CategoryRepo: ICategoryRepo
    {
        private readonly ICrudoContext _db;

        public CategoryRepo(ICrudoContext db)
        {
            _db = db;
        }

        public IQueryable<Category> GetCategories()
        {
            return _db.Categories.AsNoTracking();
        }


        public IQueryable<Advertisement> GetAdvertisementsByCategories(int id)
        {
            var advertisements = _db.Advertisements.Where(x => x.Categories.Id == id).AsNoTracking();
            return advertisements;

        }

        public Category GetCategory(int id)
        {
            var cat = _db.Categories.Find(id);
            return cat;
        }

        public void AddCategory(Category cat)
        {
            _db.Categories.Add(cat);
        }

        public void DeleteCategory(int id)
        {
            var category = _db.Categories.Find(id);
            _db.Categories.Remove(category);
        }

        public void UpdateCategory(Category cat)
        {
            _db.Entry(cat).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}