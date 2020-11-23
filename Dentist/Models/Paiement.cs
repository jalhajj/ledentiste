using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dentist.Models
{
    public class Paiement
    {

        public int PaiementID { get; set; }
        public double Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
        public DateTime? PaidDate { get; set; }
        public int PatientID { get; set; }
        public int TreatmentID { get; set; }
    }
}