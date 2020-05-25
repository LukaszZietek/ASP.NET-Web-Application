using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models.View
{
    public class AdvertisementsModelView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime AddTime { get; set; }

        public byte[] Image { get; set; }

    }
}