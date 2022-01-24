using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Seminar
    {
        public int SeminarID { get; set; }
        [Display(Name = "Organizer")]
        [Required]
        public int OrganizerID { get; set; }
        [Display(Name = "Seminar Title")]
        [Required]
        public string SeminarTitle { get; set; }
        public string SeminarDescription { get; set; }
        [Required]
        [Display(Name = "Seminar Type")]
        public string SeminarType { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Display(Name = "Seminar Date")]
        [Required]
        public System.DateTime SeminarDate { get; set; }
        [Required]
        public string SeminarStartTime { get; set; }
        [Required]
        public string SeminarEndTime { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}