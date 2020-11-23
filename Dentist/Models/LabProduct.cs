using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dentist.Models
{
    public class LabProduct
    {

        public int LabProductID { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Lab Name")]
        public string LabName { get; set; }

        [Display(Name="Cost On Patient")]
        public double CostOnPatient { get; set; }
        public double Cost { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        public int PatientID { get; set; }
        public int TreatmentID { get; set; }
    }
}