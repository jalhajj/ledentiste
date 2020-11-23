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

namespace Dentist.Controllers
{
    [Authorize]
    public class PaiementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


       

        // GET: Paiements
        public async Task<ActionResult> Index(int? id)
        {

          if(id == null)
            {
                return View(db.AllthePaiements.ToList());
            }

            return View(db.AllthePaiements.Where(p => p.PatientID == id).ToList());
        }

        // GET: Paiements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paiement paiement = await db.Paiements.FindAsync(id);
            if (paiement == null)
            {
                return HttpNotFound();
            }
            return View(paiement);
        }

        // GET: Paiements/Create
        public async Task<ActionResult> Create(int?id)
        {
            Treatment treatment = await db.Treatments.FindAsync(id); ;
            Patient patient = await db.Patients.FindAsync(treatment.PatientID);
            Paiement paiement = new Paiement();
            List<Paiement> ListOfPaiements;
            paiement.PatientID = treatment.PatientID;
            paiement.TreatmentID = treatment.TreatmentID;

            patient.FirstName = patient.FirstName + " " + patient.LastName; // display purposes
            PaiementViewModel paiementVM = new PaiementViewModel();
            paiementVM.Paiements = paiement;
            paiementVM.Patient = patient;
            paiementVM.Treatments = treatment;
            ListOfPaiements = await db.Paiements.Where(t => t.TreatmentID == treatment.TreatmentID).ToListAsync();
            paiementVM.ListOfPaiements = ListOfPaiements;

            return View(paiementVM);
        }

        // POST: Paiements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( PaiementViewModel paiementViewModel)
        {
            if (ModelState.IsValid)
            {

                Paiement paiement = paiementViewModel.Paiements;
                //  paiement.PaidDate = DateTime.Now;
                db.Paiements.Add(paiement);

                Patient patient = await db.Patients.FindAsync(paiement.PatientID);
                Treatment treatment = await db.Treatments.FindAsync(paiement.TreatmentID);

                patient.Balance = patient.Balance + paiement.Amount;
                treatment.Paid = treatment.Paid + paiement.Amount;

                db.Entry(treatment).State = EntityState.Modified;
                db.Entry(patient).State = EntityState.Modified;

                PaiementsTreatmentsPatients paiementsTP = new PaiementsTreatmentsPatients();
                paiementsTP.Amount = paiement.Amount;
                paiementsTP.PaiementDate = paiement.PaidDate;
                paiementsTP.PatientID = paiement.PatientID;
                paiementsTP.PatientName = patient.FirstName + " " + patient.LastName;
                paiementsTP.TreatmentID = treatment.TreatmentID;
                paiementsTP.TreatmentType = treatment.TeatmentType;


                await db.SaveChangesAsync();
                paiementsTP.PaiementID = paiement.PaiementID;

                db.AllthePaiements.Add(paiementsTP);
                await db.SaveChangesAsync();

                return RedirectToAction("Index","Treatments",new { id = treatment.PatientID });
            }

            return View("Paiement wasn't succefull");
        }

        // GET: Paiements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paiement paiement = await db.Paiements.FindAsync(id);
            if (paiement == null)
            {
                return HttpNotFound();
            }
            return View(paiement);
        }

        // POST: Paiements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PaiementID,Amount,PaidDate,PatientID,TreatmentID")] Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paiement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paiement);
        }

        // GET: Paiements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paiement paiement = await db.Paiements.FindAsync(id);
            if (paiement == null)
            {
                return HttpNotFound();
            }
            return View(paiement);
        }

        // POST: Paiements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Paiement paiement = await db.Paiements.FindAsync(id);
            Treatment treatment = await db.Treatments.FindAsync(paiement.TreatmentID);
            Patient patient = await db.Patients.FindAsync(paiement.PatientID);

            patient.Balance = patient.Balance - paiement.Amount;
            treatment.Paid = treatment.Paid - paiement.Amount;

            db.Entry(treatment).State = EntityState.Modified;
            db.Entry(patient).State = EntityState.Modified;

            db.Paiements.Remove(paiement);
            await db.SaveChangesAsync();
            return RedirectToAction("Index","Treatments",new { id = treatment.PatientID});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
