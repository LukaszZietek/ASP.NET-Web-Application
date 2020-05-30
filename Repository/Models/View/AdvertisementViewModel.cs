using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repository.Models.View
{
    public class AdvertisementViewModel
    {

        [Required]
        [MaxLength(50, ErrorMessage = "Za długi tytuł ogłoszenia")]
        public string Title { get; set; }

        [Required]
        [MinLength(150, ErrorMessage = "Za krótki opis ogłoszenia")]
        public string Content { get; set; }

        [Required]
        [Description("Zdjęcie")]
        public byte[] Image { get; set; }

        public Category Categories { get; private set; }

        public SelectList CategoriesTitle { get; set; }
    }
}