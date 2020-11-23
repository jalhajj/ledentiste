using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dentist.Models
{
    public class Patient
    {

        public int PatientID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MobileNumber { get; set; }
        public String Address { get; set; }
        public String Gender { get; set; }
        public MedicalHistory MedicalHistoryModel { get; set; }
        public string medicalHistoryNote { get; set; }
        public String MedicalHistory { get; set; }
        public double Balance { get; set; }
        public String Allergies { get; set; }
        public String Alert { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastAppointment { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NextAppointment { get; set; }
    }
}