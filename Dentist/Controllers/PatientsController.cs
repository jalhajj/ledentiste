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

namespace Dentist.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patients
        public async Task<ActionResult> Index()
        {
            return View(await db.Patients.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = await db.Patients.FindAsync(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.ListOfMedicalhistory = db.MedicalHistories.ToList();
             
            return View(patientViewModel);
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( PatientViewModel patientViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patientViewModel.Patient);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(patientViewModel.Patient);
        }

        // GET: Patients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = await db.Patients.FindAsync(id);
            if (patient == null)
            {
                return HttpNotFound();
            }

            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.Patient = patient;
            patientViewModel.ListOfMedicalhistory = db.MedicalHistories.ToList();
            return View(patientViewModel);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PatientViewModel patientViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientViewModel.Patient).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(patientViewModel.Patient);
        }



        // GET: Patients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = await db.Patients.FindAsync(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Patient patient = await db.Patients.FindAsync(id);

            List<Paiement> payments =  db.Paiements.Where(pay => pay.PatientID == id).ToList();

            foreach (var P in payments)
            {
                db.Paiements.Remove(P);
                db.Entry(P).State = EntityState.Deleted;
            }

            List<Treatment> treatments = db.Treatments.Where(tr => tr.PatientID == id).ToList();
            List<LabProduct> labproducts;
            foreach (var tr in treatments)
            {
                labproducts = db.Labproducts.Where(lp => lp.TreatmentID == tr.TreatmentID).ToList();

                foreach (var lp in labproducts)
                {
                    db.Labproducts.Remove(lp);
                    db.Entry(lp).State = EntityState.Deleted;
                }

                db.Treatments.Remove(tr);
                db.Entry(tr).State = EntityState.Deleted;

                labproducts = new List<LabProduct>();
            }



            db.Patients.Remove(patient);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        
        public async Task<ActionResult> ToTreatmentPage(int? id)
        {

            PatientTreatmentViewModel patientTreatmentViewModel = new PatientTreatmentViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           

            //  object param = JsonConvert.SerializeObject(patientTreatmentViewModel);
          // TempData["PatientID"] = id;
           return  RedirectToAction("Index", "Treatments",new { id = id });
        }

        public async Task<ActionResult> ToPaiementPage(int? id)
        {

           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            //  object param = JsonConvert.SerializeObject(patientTreatmentViewModel);
            // TempData["PatientID"] = id;
            return RedirectToAction("Index", "Paiements", new { id = id });
        }

    }
}
