using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ParticipantViewModel
    {
        public int ParticipantID { get; set; }
        public string SeminarTitle { get; set; }
        public string ParticipantName { get; set; }
        public string ParticipantEmail { get; set; }
        public string ParticipantMobileNo { get; set; }       
        public Nullable<System.DateTime> ParticipantDOB { get; set; }
        public Nullable<bool> IsAttended { get; set; }
    }
}