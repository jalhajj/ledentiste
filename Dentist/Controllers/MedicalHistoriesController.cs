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
    public class MedicalHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicalHistories
        public async Task<ActionResult> Index()
        {
            return View(await db.MedicalHistories.ToListAsync());
        }

        // GET: MedicalHistories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalHistory medicalHistory = await db.MedicalHistories.FindAsync(id);
            if (medicalHistory == null)
            {
                return HttpNotFound();
            }
            return View(medicalHistory);
        }

        // GET: MedicalHistories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MedicalHistoryID,Description")] MedicalHistory medicalHistory)
        {
            if (ModelState.IsValid)
            {
                db.MedicalHistories.Add(medicalHistory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(medicalHistory);
        }

        // GET: MedicalHistories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalHistory medicalHistory = await db.MedicalHistories.FindAsync(id);
            if (medicalHistory == null)
            {
                return HttpNotFound();
            }
            return View(medicalHistory);
        }

        // POST: MedicalHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MedicalHistoryID,Description")] MedicalHistory medicalHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalHistory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(medicalHistory);
        }

        // GET: MedicalHistories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalHistory medicalHistory = await db.MedicalHistories.FindAsync(id);
            if (medicalHistory == null)
            {
                return HttpNotFound();
            }
            return View(medicalHistory);
        }

        // POST: MedicalHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MedicalHistory medicalHistory = await db.MedicalHistories.FindAsync(id);
            db.MedicalHistories.Remove(medicalHistory);
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
