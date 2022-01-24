using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Organizer
    {
        public int OrganizerID { get; set; }
        [Display(Name = "Organizer Name")]
        [Required]
        public string OrganizerName { get; set; }
        [EmailAddress]
        public string OrganizerEmail { get; set; }
        public string OrganizerMobileNo { get; set; }
        public string OrganizerAddress { get; set; }
    }
}