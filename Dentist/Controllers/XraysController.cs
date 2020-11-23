using Dentist.Models;
using Dentist.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Dentist.Controllers
{
    [Authorize]
    public class XraysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Xrays
        //public ActionResult Index()
        //{

        ////    XrayViewModel model = new XrayViewModel { FileAttach = null, ImgLst = new List<Xray>() };

        //    try
        //    {
        //        // Settings.  
        //        model.ImgLst = db.Xrays.Select(p => new Xray
        //        {
        //            XrayID = p.XrayID,
        //            XrayFileName = p.XrayFileName,
        //            FileContentType = p.FileContentType
        //        }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Info  
        //        Console.Write(ex);
        //    }

        //    return View(model);
        //}
        public async Task<ActionResult> Index( int id)
        {
            XrayViewModel xrayViewModel = new XrayViewModel();
            Xray xray = new Xray();
            List<Xray> listOfXrays;

            Treatment treat = await db.Treatments.FindAsync(id);
            Patient patient = await db.Patients.FindAsync(treat.PatientID);
            listOfXrays =  db.Xrays.Where(p => p.TreatmentID == id).ToList();

            xrayViewModel.XrayModel = xray;
            xrayViewModel.XrayModel.PatientID = treat.PatientID;
            xrayViewModel.XrayModel.TreatmentID = id;
            xrayViewModel.patient = patient;
            xrayViewModel.savedXray = listOfXrays;
            xrayViewModel.treatment = treat;



            return View(xrayViewModel);
          }

        // GET: Xrays/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Xrays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Xrays/Create
        [HttpPost]
        public async  Task<ActionResult> Create(XrayViewModel xrayviewModel)
        {

            Xray xray = new Xray();
            try
            {

                
                Treatment treat = await db.Treatments.FindAsync(xrayviewModel.XrayModel.TreatmentID);
                Patient patient = await db.Patients.FindAsync(treat.PatientID);

                DateTime datetime = DateTime.Now;
                string FolderName = string.Concat(patient.FirstName, patient.LastName)  ;
                if (!Directory.Exists(Path.Combine(Server.MapPath("~/Images/"), FolderName)))
                {
                    Directory.CreateDirectory(Path.Combine(Server.MapPath("~/Images/"), FolderName));
                }

                foreach (HttpPostedFileBase file in xrayviewModel.ImageFile)
                {
                    xray = new Xray();
                    
                    xray.XrayFileName = Path.GetFileNameWithoutExtension(file.FileName); // hay badda tsir title
                    string extension = Path.GetExtension(file.FileName);
                    string fullPath = FolderName + "/" + datetime.ToString("yyyymmddss") + "_" + treat.TreatmentID + xray.XrayFileName+extension;
                    xray.XrayPath = "~/Images/" + fullPath;
                    file.SaveAs(Path.Combine(Server.MapPath("~/Images/"), fullPath));
                    xray.UploadDate = datetime;
                    xray.TreatmentID = xrayviewModel.XrayModel.TreatmentID;
                    xray.PatientID = patient.PatientID;
                    db.Xrays.Add(xray);
                }
                 
                db.SaveChangesAsync();

                return RedirectToAction("Index", new { id = treat.TreatmentID });
            }
            catch (Exception e)
            {

                Console.WriteLine("error in XraysController, Create function");
                Console.WriteLine(e.StackTrace);
                return View("Error");
            }
        }

        // GET: Xrays/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Xrays/Edit/5
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

        // GET: Xrays/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Xrays/Delete/5
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
