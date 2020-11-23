using Dentist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dentist.ViewModels
{
    public class PatientViewModel
    {

        public Patient Patient{ get; set; }
        public List<MedicalHistory> ListOfMedicalhistory { get; set; }
    }
}