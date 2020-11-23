using Dentist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dentist.ViewModels
{
    public class PaiementViewModel
    {
        public Patient Patient { get; set; }
        public Treatment Treatments { get; set; }
        public Paiement Paiements { get; set; }

        public List<Paiement> ListOfPaiements { get; set; }
    }
}