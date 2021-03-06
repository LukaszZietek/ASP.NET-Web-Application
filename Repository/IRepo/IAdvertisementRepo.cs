﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Repository.Models;

namespace Repository.IRepo
{
    public interface IAdvertisementRepo
    {
        IQueryable<Advertisement> GetAdvertisements(int? id = null);

        //IQueryable<Advertisement> GetAdvertisements(int? page, int? pageSize);

        IQueryable<Advertisement> GetUserAdvertisements(string userId);

        IQueryable<Advertisement> GetAdvertisementsWhichContain(string searchValue);



        Advertisement GetAdvertisement(int? id);

        void DeleteAdvertisement(int? id);

        void AddAdvertisement(Advertisement ad);

        void UpdateAdvertisement(Advertisement ad);


        IQueryable<Advertisement> GetAdvertisementsByCategory(int id);

        void SaveChanges();



    }
}
