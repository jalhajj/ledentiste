using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dentist.Models;
using Dentist.ViewModels;
using Newtonsoft.Json;
using Dentist.DTO;

namespace Dentist.Controllers
{
    [Authorize]
    public class TreatmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Treatments
        public async void test(int? PatientID)
        {
             RedirectToAction("LoadingTreatmentPlan", "TreatmentPlans", new { PatientID = PatientID });
        }

        public async Task<ActionResult> Index(int? id)
        {

            //   int patientId =(int) TempData["PatientID"];
            //  int id =(int)patientId;
            PatientTreatmentViewModel patientTreatmentViewModel = new PatientTreatmentViewModel();
            patientTreatmentViewModel=  await patientTreatmentViewModel.getViewModelFromPatient((int)id);
          //  LoadTheChart();

            return View("Index", patientTreatmentViewModel);
        }

        public async Task<ActionResult> LoadTheChart(List<Treatment> myobj)
        {

            Treatment treat = myobj.FirstOrDefault();
            TeethTreatmentViewModel teethVM = new TeethTreatmentViewModel();
            Dictionary<int, List<Treatment>> teethDico = new Dictionary<int, List<Treatment>>();


            teethDico.Add(18, myobj.Where(a => a.TeethNumber == 18).ToList());
            teethDico.Add(17, myobj.Where(a => a.TeethNumber == 17).ToList());
            teethDico.Add(16, myobj.Where(a => a.TeethNumber == 16).ToList());
            teethDico.Add(15, myobj.Where(a => a.TeethNumber == 15).ToList());
            teethDico.Add(14, myobj.Where(a => a.TeethNumber == 14).ToList());
            teethDico.Add(13, myobj.Where(a => a.TeethNumber == 13).ToList());
            teethDico.Add(12, myobj.Where(a => a.TeethNumber == 12).ToList());
            teethDico.Add(11, myobj.Where(a => a.TeethNumber == 11).ToList());
            teethDico.Add(21, myobj.Where(a => a.TeethNumber == 21).ToList());
            teethDico.Add(22, myobj.Where(a => a.TeethNumber == 22).ToList());
            teethDico.Add(23, myobj.Where(a => a.TeethNumber == 23).ToList());
            teethDico.Add(24, myobj.Where(a => a.TeethNumber == 24).ToList());
            teethDico.Add(25, myobj.Where(a => a.TeethNumber == 25).ToList());
            teethDico.Add(26, myobj.Where(a => a.TeethNumber == 26).ToList());
            teethDico.Add(27, myobj.Where(a => a.TeethNumber == 27).ToList());
            teethDico.Add(28, myobj.Where(a => a.TeethNumber == 28).ToList());


            teethDico.Add(48, myobj.Where(a => a.TeethNumber == 48).ToList());
            teethDico.Add(47, myobj.Where(a => a.TeethNumber == 47).ToList());
            teethDico.Add(46, myobj.Where(a => a.TeethNumber == 46).ToList());
            teethDico.Add(45, myobj.Where(a => a.TeethNumber == 45).ToList());
            teethDico.Add(44, myobj.Where(a => a.TeethNumber == 44).ToList());
            teethDico.Add(43, myobj.Where(a => a.TeethNumber == 43).ToList());
            teethDico.Add(42, myobj.Where(a => a.TeethNumber == 42).ToList());
            teethDico.Add(41, myobj.Where(a => a.TeethNumber == 41).ToList());
            teethDico.Add(31, myobj.Where(a => a.TeethNumber == 31).ToList());
            teethDico.Add(32, myobj.Where(a => a.TeethNumber == 32).ToList());
            teethDico.Add(33, myobj.Where(a => a.TeethNumber == 33).ToList());
            teethDico.Add(34, myobj.Where(a => a.TeethNumber == 34).ToList());
            teethDico.Add(35, myobj.Where(a => a.TeethNumber == 35).ToList());
            teethDico.Add(36, myobj.Where(a => a.TeethNumber == 36).ToList());
            teethDico.Add(37, myobj.Where(a => a.TeethNumber == 37).ToList());
            teethDico.Add(38, myobj.Where(a => a.TeethNumber == 38).ToList());

           

         //  Patient chartPatient = db.Patients.Find(myobj); 
            return PartialView("ChartView", teethDico);
        }

        // GET: Treatments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = await db.Treatments.FindAsync(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // GET: Treatments/Create
        public ActionResult Create(int patientId)
        {
            
            Treatment treatment = new Treatment();
            treatment.PatientID = patientId;

            TreatmentViewModel treatmentViewModel = new TreatmentViewModel();
            treatmentViewModel.Treatment = treatment;
            treatmentViewModel.Treatments = db.TreatmentTypes.ToList();
            return View(treatmentViewModel);
        }

        // POST: Treatments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TreatmentViewModel treatmentViewModel)
        {
            if (ModelState.IsValid)
            {
                int PatientID = treatmentViewModel.Treatment.PatientID;
                double PatientBalance;
                db.Treatments.Add(treatmentViewModel.Treatment);
             //   await db.SaveChangesAsync();
                Patient patient = await db.Patients.FindAsync(PatientID);

                PatientBalance = patient.Balance;
                PatientBalance = PatientBalance - treatmentViewModel.Treatment.Cost;
                patient.Balance = PatientBalance;

                
                db.Entry(patient).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Index", new {id = PatientID });
            }

            return View(treatmentViewModel.Treatment);
        }

        // GET: Treatments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = await db.Treatments.FindAsync(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }

            TreatmentViewModel treatmentViewModel = new TreatmentViewModel();
            treatmentViewModel.Treatment = treatment;
            treatmentViewModel.Treatments = db.TreatmentTypes.ToList();
            return View(treatmentViewModel);
        }

        // POST: Treatments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { id = treatment.PatientID });
            }
            return View(treatment);
        }

        // GET: Treatments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = await db.Treatments.FindAsync(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // POST: Treatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {


            List<LabProduct> labproducts = db.Labproducts.Where(lp => lp.TreatmentID == id).ToList();

            foreach(var lp in labproducts)
            {
                db.Labproducts.Remove(lp);
                db.Entry(lp).State = EntityState.Deleted;
            }


            Treatment treatment = await db.Treatments.FindAsync(id);
            int PatientId = treatment.PatientID;
            double cost = treatment.Cost;
            double paid = treatment.Paid;
            Patient patient = await db.Patients.FindAsync(PatientId);
            double rest = cost - paid;

            List<PaiementsTreatmentsPatients> payments =  db.AllthePaiements.Where(p=> p.TreatmentID == id).ToList();

            foreach(var p in payments)
            { 
            db.AllthePaiements.Remove(p);
            }

            List<Paiement> paymentsdb = db.Paiements.Where(p => p.TreatmentID == id).ToList();

            foreach (var pdb in paymentsdb)
            {
                db.Paiements.Remove(pdb);
            }

            patient.Balance = patient.Balance + cost - paid;

            db.Treatments.Remove(treatment);
            db.Entry(patient).State = EntityState.Modified;

            await db.SaveChangesAsync();

            return  RedirectToAction("Index", new { id = treatment.PatientID }); 
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       

        [HttpPost]
        public async Task<ActionResult> AddNewTreatmentPlan(TreatmentPlanDTO obj)
        {

            TreatmentPlan treatmentPlan = new TreatmentPlan();
            treatmentPlan.PatientID = obj.PatientID;
            treatmentPlan.TreatmentDescription = obj.TxtValue;
            int patientID = treatmentPlan.PatientID;
            db.TreatmentPlan.Add(treatmentPlan);
            //   await db.SaveChangesAsync();
            await db.SaveChangesAsync();

            return Json(Url.Action("Index", "Treatments", new { id = patientID }));


        }

        public async Task<ActionResult> AddNewPaiement(int id)
        {
            Treatment treatment = new Treatment();
            treatment =  await db.Treatments.FindAsync(id);

            //Paiement paiement = new Paiement();
            //paiement.TreatmentID = treatment.TreatmentID;
            //paiement.PatientID = treatment.PatientID;install-package bootbox -version:4.3.0

            //paiement.Amount

            return RedirectToAction("Create", "Paiements", new { id = treatment.TreatmentID });
        }

        public async Task<ActionResult> ViewPaiements(int id)
        {
            return RedirectToAction("Index", "Paiements", new { id = id });

        }

        public async Task<ActionResult> AddNewXray(int id)
        {
            
            //Paiement paiement = new Paiement();
            //paiement.TreatmentID = treatment.TreatmentID;
            //paiement.PatientID = treatment.PatientID;install-package bootbox -version:4.3.0

            //paiement.Amount

            return RedirectToAction("Index", "Xrays", new { id = id });
        }

        public async Task<ActionResult> AddToLab (int id)
        {

            return RedirectToAction("Create", "LabProducts", new { id = id });
        }

        public async Task<ActionResult> ViewPayments(int id)
        {

            return RedirectToAction("Index", "Paiements", new { id = id });
        }
        
    }

}

