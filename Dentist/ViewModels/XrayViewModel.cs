using Dentist.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dentist.ViewModels
{
    public class XrayViewModel
    {

        public HttpPostedFileBase [] ImageFile { get; set; }

        public Xray XrayModel { get; set; } // save
        public List<Xray> savedXray { get; set; } // to display all the Xrays
        public Treatment treatment { get; set; }
        public Patient patient { get; set; }

    }
}