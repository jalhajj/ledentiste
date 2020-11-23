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

namespace Dentist.Controllers
{
    
    public class TreatmentPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

      
        public async Task<ActionResult> LoadingTreatmentPlan()
        {
            return  View( db.TreatmentPlan.ToListAsync());
        }

        // GET: TreatmentPlans/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentPlan treatmentPlan = await db.TreatmentPlan.FindAsync(id);
            if (treatmentPlan == null)
            {
                return HttpNotFound();
            }
            return View(treatmentPlan);
        }

        // GET: TreatmentPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TreatmentPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TreatmentPlanID,TreatmentDescription,PatientID")] TreatmentPlan treatmentPlan)
        {
            if (ModelState.IsValid)
            {
                db.TreatmentPlan.Add(treatmentPlan);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(treatmentPlan);
        }

        // GET: TreatmentPlans/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentPlan treatmentPlan = await db.TreatmentPlan.FindAsync(id);
            if (treatmentPlan == null)
            {
                return HttpNotFound();
            }
            return View(treatmentPlan);
        }

        // POST: TreatmentPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TreatmentPlanID,TreatmentDescription,PatientID")] TreatmentPlan treatmentPlan)
        {
            if (ModelState.IsValid)
            {
                int patientID = treatmentPlan.PatientID;
                db.Entry(treatmentPlan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Treatments", new { id = patientID });
            }
            return View(treatmentPlan);
        }

        // GET: TreatmentPlans/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentPlan treatmentPlan = await db.TreatmentPlan.FindAsync(id);
            if (treatmentPlan == null)
            {
                return HttpNotFound();
            }
            return View(treatmentPlan);
        }

        // POST: TreatmentPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TreatmentPlan treatmentPlan = await db.TreatmentPlan.FindAsync(id);
            int patientId = treatmentPlan.PatientID;
            db.TreatmentPlan.Remove(treatmentPlan);
            await db.SaveChangesAsync();
            return RedirectToAction("Index","Treatments",new { id = patientId});
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
