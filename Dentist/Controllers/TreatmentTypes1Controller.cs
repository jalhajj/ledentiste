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
    [Authorize]
    public class TreatmentTypes1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TreatmentTypes1
        public async Task<ActionResult> Index()
        {
            return View(await db.TreatmentTypes.ToListAsync());
        }

        // GET: TreatmentTypes1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentType treatmentType = await db.TreatmentTypes.FindAsync(id);
            if (treatmentType == null)
            {
                return HttpNotFound();
            }
            return View(treatmentType);
        }

        // GET: TreatmentTypes1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TreatmentTypes1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TreatmentTypeID,Description")] TreatmentType treatmentType)
        {
            if (ModelState.IsValid)
            {
                db.TreatmentTypes.Add(treatmentType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(treatmentType);
        }

        // GET: TreatmentTypes1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentType treatmentType = await db.TreatmentTypes.FindAsync(id);
            if (treatmentType == null)
            {
                return HttpNotFound();
            }
            return View(treatmentType);
        }

        // POST: TreatmentTypes1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TreatmentTypeID,Description")] TreatmentType treatmentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatmentType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(treatmentType);
        }

        // GET: TreatmentTypes1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentType treatmentType = await db.TreatmentTypes.FindAsync(id);
            if (treatmentType == null)
            {
                return HttpNotFound();
            }
            return View(treatmentType);
        }

        // POST: TreatmentTypes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TreatmentType treatmentType = await db.TreatmentTypes.FindAsync(id);
            db.TreatmentTypes.Remove(treatmentType);
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
    }
}
