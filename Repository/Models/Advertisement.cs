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
        public string Title { get; set; }

        [Required]
        [MinLength(150, ErrorMessage = "Za krótki opis ogłoszenia")]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AddTime { get; set; }


        public User User { get; private set; }

        public Category Categories { get; private set; }

    }
}