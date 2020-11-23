using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dentist.Models
{
    public class Teeth
    {
        public int TeethID { get; set; }
        public int TeethNumber { get; set; }
        public string TeethName { get; set; }
        public string Picture { get; set; }
        public int TreatmentID { get; set; }
    }
}