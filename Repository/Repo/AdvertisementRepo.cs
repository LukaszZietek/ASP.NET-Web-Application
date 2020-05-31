using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Repository.IRepo;
using Repository.Models;

namespace Repository.Repo
{
    public class AdvertisementRepo: IAdvertisementRepo
    {
        private readonly ICrudoContext _db;

        public AdvertisementRepo(ICrudoContext db)
        {
            _db = db;
        }

        public IQueryable<Advertisement> GetAdvertisements()
        {
            var advertisements = _db.Advertisements.AsNoTracking();
            return advertisements;
        }

        public IQueryable<Advertisement> GetAdvertisements(int? page = 1, int? pageSize = 10)
        {
            return _db.Advertisements.OrderByDescending(x => x.AddTime).Skip((page.Value - 1) * pageSize.Value)
                .Take(pageSize.Value).AsNoTracking();
        }

        public Advertisement GetAdvertisement(int? id)
        {
            if (id != null)
            {
                var advertisement = _db.Advertisements.Find(id);
                if (advertisement != null)
                {
                    return advertisement;
                }
                
            }
            
                throw new HttpException("We can't find advertisement which has that ID");
        }

        public void DeleteAdvertisement(int? id)
        {
            if (id != null)
            {
                var advertisement = _db.Advertisements.Find(id);
                if (advertisement != null)
                {
                    _db.Advertisements.Remove(advertisement);
                }

            }
            throw new HttpException("We can't find advertisement which has that ID");
        }

        public void AddAdvertisement(Advertisement ad, HttpPostedFileBase file)
        {
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                ad.Image = binaryReader.ReadBytes(file.ContentLength);
            }

            _db.Advertisements.Add(ad);
        }

        public void UpdateAdvertisement(Advertisement ad)
        {
            _db.Entry(ad).State = EntityState.Modified;
        }

      

        public IQueryable<Advertisement> GetAdvertisementsByCategory (int id)
        {
           return _db.Advertisements.Where(x => x.CategoriesId == id).AsNoTracking();

        }
        public static IEnumerable<SelectListItem> GetCategoriesList()
        {
            IList<SelectListItem> categories = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Ubrania", Value = "1"},
                new SelectListItem() {Text = "Samochody", Value = "2"},
                new SelectListItem() {Text = "Sport", Value = "3"},
                new SelectListItem() {Text = "Ksiązki", Value = "4"}
            };
            return categories;
        }


        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}