using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Repository.Models.View
{
    public class MessageModelView
    {
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Display(Name = "Zawartość")]
        public string Content { get; set; }


        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage = "Błędny format email")]
        public string RecipientEmail { get; set; }

    }
}