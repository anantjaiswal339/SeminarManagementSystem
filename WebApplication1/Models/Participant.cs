using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Participant
    {
        public int ParticipantID { get; set; }
        [Display(Name = "Seminar")]
        [Required]
        public int SeminarID { get; set; }
        [Display(Name = "Participant Name")]
        [Required]
        public string ParticipantName { get; set; }
        [Required]
        [EmailAddress]
        public string ParticipantEmail { get; set; }
        public string ParticipantMobileNo { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Display(Name = "Participant DOB")]
        public Nullable<System.DateTime> ParticipantDOB { get; set; }
        public Nullable<bool> IsAttended { get; set; }
    }
}