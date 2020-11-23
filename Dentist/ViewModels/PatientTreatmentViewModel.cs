using Dentist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dentist.ViewModels
{
    public class PatientTreatmentViewModel
    {
        public Patient Patient { get; set; }
        public List<Treatment> Treatments { get; set; }
        public List<TreatmentPlan> TreatmentPlans { get; set; }

        public TeethTreatmentViewModel teethTreatmentVM { get; set; }

        public double rest { get; set; }

        private ApplicationDbContext db = new ApplicationDbContext();

        


        public async System.Threading.Tasks.Task<PatientTreatmentViewModel> getViewModelFromPatient(int id)

        {
            PatientTreatmentViewModel patientTreatmentViewModel = new PatientTreatmentViewModel();
            Patient patient = await db.Patients.FindAsync(id);
           

            patientTreatmentViewModel.Patient = patient;
            patientTreatmentViewModel.Treatments = db.Treatments.Where(t => t.PatientID == patient.PatientID).ToList();
            patientTreatmentViewModel.TreatmentPlans = db.TreatmentPlan.Where(t => t.PatientID == patient.PatientID).ToList();

            return patientTreatmentViewModel;
        }

    }

    
}