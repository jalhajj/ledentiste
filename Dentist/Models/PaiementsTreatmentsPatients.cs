using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dentist.Models
{
    public class PaiementsTreatmentsPatients
    {
        public int PaiementsTreatmentsPatientsID { get; set; }
        public int PaiementID { get; set; }
        public double Amount { get; set; }
        public DateTime? PaiementDate { get; set; }

        public string  PatientName { get; set; }
        public string TreatmentType { get; set; }

        public int PatientID { get; set; }
        public int TreatmentID { get; set; }

    }
}