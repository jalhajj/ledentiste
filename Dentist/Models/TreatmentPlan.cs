using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dentist.Models
{
    public class TreatmentPlan
    {
        public int TreatmentPlanID { get; set; }
        public String TreatmentDescription { get; set; }
        public int PatientID { get; set; }
    }
}