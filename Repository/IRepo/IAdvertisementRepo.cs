using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.IRepo
{
    public interface IAdvertisementRepo
    {
        IQueryable<Advertisement> GetAdvertisements();

        Advertisement GetAdvertisement(int? id);

        void DeleteAdvertisement(int? id);

        void AddAdvertisement(Advertisement ad);

        void UpdateAdvertisement(Advertisement ad);

        void SaveChanges();



    }
}
