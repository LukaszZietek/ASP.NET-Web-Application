using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class User
    {
        public User()
        {
            this.Advertisements = new HashSet<Advertisement>();
        }

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [RegularExpression(@"^(?=.*[a - z])(?=.*[A - Z])(?=.*\d)(?=.*[^\da - zA - Z]).{8, 15}$", ErrorMessage = "Podane hasło musi" +
                                                                                                                "posiadać jedną dużą literę i znak specjalny")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]", ErrorMessage = "Podaj pierwszą literę imienia dużą literą")]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        [Required]
        public bool IfConfirm { get; set; }


        public virtual ICollection<Advertisement> Advertisements { get; private set; }

    }
}