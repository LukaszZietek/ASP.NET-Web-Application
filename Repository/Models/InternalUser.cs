using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Repository.Models
{
    public class InternalUser : IdentityUser
    {
        public InternalUser()
        {
            this.Advertisements = new HashSet<Advertisement>();
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        [Required]
        public bool IfConfirm { get; set; }


        public virtual ICollection<Advertisement> Advertisements { get; private set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<InternalUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

  
}