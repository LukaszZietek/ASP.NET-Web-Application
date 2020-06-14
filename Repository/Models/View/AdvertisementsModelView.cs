using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models.View
{
    public class AdvertisementsModelView
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Za długi tytuł ogłoszenia")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required]
        [MinLength(150, ErrorMessage = "Za krótki opis ogłoszenia")]
        [Display(Name = "Opis")]
        public string Content { get; set; }


        [Required]
        [Display(Name = "Kategoria")]
        public int CategoriesId { get; set; }


        [Required]
        [Display(Name = "Cena")]
        public double Price { get; set; }


        [Required]
        [Description("Zdjęcie")]
        [Display(Name = "Zdjęcie")]
        public HttpPostedFileBase Image { get; set; }

    }
}