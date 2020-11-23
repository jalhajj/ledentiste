using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dentist.Models
{
    public class Treatment
    {
        public int TreatmentID { get; set; }
        public String TeatmentType { get; set; }
        public double Cost { get; set; }
        public double Paid { get; set; }
        [Display(Name ="Teeth Number")]
        public int TeethNumber { get; set; }
        [Display(Name ="Status")]
        public string Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? Date { get; set; }

        public String Note { get; set; }
        public string AddedBy { get; set; }
        public int PatientID { get; set; }

    }
}