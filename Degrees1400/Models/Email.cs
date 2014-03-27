using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Degrees1400.Models
{
    [DataContract]
    public class Email
    {
        [Key]
        public int EmailId { get; set; }

        [Required(ErrorMessage = "Email is required"), RegularExpression(@"^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$", ErrorMessage = "Invalid Email format")]
        public string Address { get; set; }
    }
}