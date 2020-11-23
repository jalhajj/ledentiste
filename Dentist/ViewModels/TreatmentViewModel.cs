using Dentist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dentist.ViewModels
{
    public class TreatmentViewModel
    {

        public Treatment Treatment { get; set; }
        public List<TreatmentType> Treatments { get; set; }
    }
}