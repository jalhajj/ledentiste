using Dentist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dentist.ViewModels
{
    public class LabproductsViewModel
    {

        public LabProduct  Labproducts { get; set; }
        public Treatment Treatments { get; set; }
        public String PatientName { get; set; }
    }
}