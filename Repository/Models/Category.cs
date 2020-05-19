using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Category
    {
        public Category()
        {
            this.Advertisements = new HashSet<Advertisement>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<Advertisement> Advertisements { get; private set; }
    }
}