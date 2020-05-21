using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
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

        public void AddAdvertisement(Advertisement ad)
        {
            _db.Advertisements.Add(ad);
        }

        public void UpdateAdvertisement(Advertisement ad)
        {
            _db.Entry(ad).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}