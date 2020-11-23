using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dentist.Models
{
    public class Xray
    {

        public int XrayID { get; set; }


        public string XrayFileName { get; set; }
        public string XrayPath { get; set; }
        public DateTime UploadDate { get; set; }
        public string FileContentType { get; set; }

        public int PatientID { get; set; }
        public int TreatmentID { get; set; }




    }
}