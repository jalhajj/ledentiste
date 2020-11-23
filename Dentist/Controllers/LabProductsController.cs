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
    public class LabProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LabProducts
        public async Task<ActionResult> Index() 
        {
            Treatment treatment;
            LabproductsViewModel labproductvm;
            Patient tmpPatient;
            String patientName;
            List<LabproductsViewModel> ListOflabproductsVM = new List<LabproductsViewModel>();
            List<LabProduct> Listoflabproducts = await db.Labproducts.ToListAsync();

            foreach(var labproduct in Listoflabproducts)
            {
                treatment = await db.Treatments.FindAsync(labproduct.TreatmentID);

                labproductvm  = new LabproductsViewModel();


                labproductvm.Treatments = treatment;
                tmpPatient = await db.Patients.FindAsync(treatment.PatientID);

                patientName = tmpPatient.FirstName + " " + tmpPatient.LastName;

                labproductvm.PatientName = patientName;
                labproductvm.Labproducts = labproduct;
                ListOflabproductsVM.Add(labproductvm);

            }
            return View(ListOflabproductsVM);
        }

        

        // GET: LabProducts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabProduct labProduct = await db.Labproducts.FindAsync(id);
            if (labProduct == null)
            {
                return HttpNotFound();
            }
            return View(labProduct);
        }

        // GET: LabProducts/Create
        public async Task<ActionResult> Create(int id)
        {
            Treatment treatment = await db.Treatments.FindAsync(id);
            // Patient patient = await db.Patients.FindAsync(treatment.PatientID);
            LabProduct labproduct = new LabProduct();
            LabproductsViewModel labproductsviewModel = new LabproductsViewModel();
            labproductsviewModel.Labproducts = labproduct;

            labproductsviewModel.Labproducts.TreatmentID = treatment.TreatmentID; 
            //labproductsviewModel.Patients = patient;
            labproductsviewModel.Treatments = treatment;


            return View(labproductsviewModel);
        }

        // POST: LabProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LabproductsViewModel labproductsviewModel)
        {
            if (ModelState.IsValid)
            {
                LabProduct Labproducts = labproductsviewModel.Labproducts;
                int patientId = labproductsviewModel.Treatments.PatientID;
                db.Labproducts.Add(Labproducts);
                await db.SaveChangesAsync();


                return RedirectToAction("Index","Treatments", new { id= patientId });
            }

            return View("Error");
        }

        // GET: LabProducts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabProduct labProduct = await db.Labproducts.FindAsync(id);
            Treatment treatment = await db.Treatments.FindAsync(labProduct.TreatmentID);

            LabproductsViewModel labproductViewModel = new LabproductsViewModel();

            labproductViewModel.Treatments = treatment;

            labproductViewModel.Labproducts = labProduct;
            

            if (labProduct == null)
            {
                return HttpNotFound();
            }
            return View(labproductViewModel);
        }

        // POST: LabProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LabproductsViewModel labproductviewModel)
        {
            if (ModelState.IsValid)
            {
                LabProduct lab = labproductviewModel.Labproducts;
                db.Entry(lab).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View("Error");
        }

        // GET: LabProducts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabProduct labProduct = await db.Labproducts.FindAsync(id);
            if (labProduct == null)
            {
                return HttpNotFound();
            }
            return View(labProduct);
        }

        // POST: LabProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LabProduct labProduct = await db.Labproducts.FindAsync(id);
           // Treatment treatment = await db.Treatments.FindAsync(labProduct.TreatmentID);

       //     int patientId = treatment.PatientID;
            db.Labproducts.Remove(labProduct);
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
