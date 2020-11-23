using Dentist.Models;
using Dentist.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dentist.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        // GET: Image/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Image/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        [HttpPost]
        public ActionResult Create(XrayViewModel xrayviewModel)
        {
            Xray xray = new Xray();
            try { 
            //{
            //    string fileName = Path.GetFileNameWithoutExtension(xrayviewModel.ImageFile.FileName);
            //    string extension = Path.GetExtension(xrayviewModel.ImageFile.FileName);
            //    fileName = fileName + DateTime.Now.ToString("yyyymmddss") + xrayviewModel.XrayModel.TreatmentID + xrayviewModel.XrayModel.PatientID + extension;
            //    xray.XrayPath = "~/Images/"+fileName;
            //    xray.XrayFileName = fileName;
            //    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            //    xrayviewModel.ImageFile.SaveAs(fileName);

            //    xray.UploadDate = DateTime.Now;
            //    xray.TreatmentID = xrayviewModel.XrayModel.TreatmentID;
            //    xray.PatientID = xrayviewModel.XrayModel.PatientID;


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Image/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Image/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Image/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Image/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
