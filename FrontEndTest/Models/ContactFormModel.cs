using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FrontEndTest.Models
{
    public class ContactFormModel
    {
        public ContactFormModel()
        {
            Sent = false;
        }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Sent { get; set; }
    }
}