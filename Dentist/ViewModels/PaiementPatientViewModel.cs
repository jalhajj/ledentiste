using Dentist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dentist.ViewModels
{
    public class PaiementPatientViewModel
    {

        public Patient ThePatient { get; set; }
        public List<Paiement> Paiements { get; set; }
    }
}