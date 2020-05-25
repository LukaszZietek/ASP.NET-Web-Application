using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Repository.Models;

namespace Repository.IRepo
{
    public interface IAdvertisementRepo
    {
        IQueryable<Advertisement> GetAdvertisements();

        Advertisement GetAdvertisement(int? id);

        void DeleteAdvertisement(int? id);

        void AddAdvertisement(Advertisement ad, HttpPostedFileBase file);

        void UpdateAdvertisement(Advertisement ad);

        List<string> GetCategoriesName();

        void SaveChanges();



    }
}
