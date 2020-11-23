using Dentist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dentist.ViewModels
{
    public class TeethTreatmentViewModel
    {

        public Teeth teeth{ get; set; }

        public List<Treatment> treatments;
    }
}