using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Repository.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tytuł")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Zawartość")]
        [Required]
        public string Content { get; set; }

        [Display(Name = "Czas wysłania wiadomości")]
        public DateTime SendTime { get; set; }

        [Display(Name = "Czas otwarcia wiadomości")]
        public DateTime OpenTime { get; set; }

        
        public string SenderId { get; set; }

        public string RecipientId { get; set; }

        public virtual InternalUser Users { get; private set; }
        }
}