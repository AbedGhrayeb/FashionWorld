using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FashionWorld.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [Required,StringLength(50,ErrorMessage ="Please Enter Your Name")]
        public string Name { get; set; }
        [Required, StringLength(50, ErrorMessage = "Please Enter Your Valid Emaile (example@example.com")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(50, ErrorMessage = "Please Enter Message Supject")]
        public string Supject { get; set; }
        [Required, StringLength(50, ErrorMessage = "Please Enter Your Name")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
