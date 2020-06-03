using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Repository.Models
{
    public class Advertisement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Za długi tytuł ogłoszenia")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required]
        [MinLength(150, ErrorMessage = "Za krótki opis ogłoszenia")]
        [Display(Name="Opis")]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name="Data Dodania")]
        public DateTime AddTime { get; set; }

        [Required]
        [Display(Name="Cena")]
        public double Price { get; set; }

        [Required]
        [Description("Zdjęcie")]
        [Display(Name = "Zdjęcie")]
        public byte[] Image { get; set; }

        public string InternalUserId { get; set; }

        [Required]
        [Display(Name = "Kategoria")]
        public int CategoriesId { get; set; }


        public virtual InternalUser InternalUser { get; private set; }

        
        public virtual Category Categories { get; set; }

    }
}