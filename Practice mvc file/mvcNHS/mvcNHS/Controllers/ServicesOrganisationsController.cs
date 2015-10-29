using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcNHS.DAL;
using DotNet.Highcharts;

namespace mvcNHS.Controllers
{
    public class ServicesOrganisationsController : Controller
    {
        private NHSPatientServicesEntities db = new NHSPatientServicesEntities();

        // GET: ServicesOrganisations
        public ActionResult Index()
        {
            var servicesOrganisations = db.ServicesOrganisations.Include(s => s.GP_Services).Include(s => s.Organisation_Details);
           

            return View(servicesOrganisations.ToList());
        }

        // GET: ServicesOrganisations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesOrganisation servicesOrganisation = db.ServicesOrganisations.Find(id);
            if (servicesOrganisation == null)
            {
                return HttpNotFound();
            }
            return View(servicesOrganisation);
        }

        // GET: ServicesOrganisations/Create
        public ActionResult Create()
        {
            ViewBag.Ref_Service_ID = new SelectList(db.GP_Services, "Service_ID", "GP_Service_Name");
            ViewBag.Ref_Organisation_Details_ID = new SelectList(db.Organisation_Details, "ID", "Organisation_Name");
            return View();
        }

        // POST: ServicesOrganisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Services_Organisation_ID,Ref_Organisation_Details_ID,Ref_Service_ID")] ServicesOrganisation servicesOrganisation)
        {
            if (ModelState.IsValid)
            {
                db.ServicesOrganisations.Add(servicesOrganisation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ref_Service_ID = new SelectList(db.GP_Services, "Service_ID", "GP_Service_Name", servicesOrganisation.Ref_Service_ID);
            ViewBag.Ref_Organisation_Details_ID = new SelectList(db.Organisation_Details, "ID", "Organisation_Name", servicesOrganisation.Ref_Organisation_Details_ID);
            return View(servicesOrganisation);
        }

        // GET: ServicesOrganisations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesOrganisation servicesOrganisation = db.ServicesOrganisations.Find(id);
            if (servicesOrganisation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ref_Service_ID = new SelectList(db.GP_Services, "Service_ID", "GP_Service_Name", servicesOrganisation.Ref_Service_ID);
            ViewBag.Ref_Organisation_Details_ID = new SelectList(db.Organisation_Details, "ID", "Organisation_Name", servicesOrganisation.Ref_Organisation_Details_ID);
            return View(servicesOrganisation);
        }

        // POST: ServicesOrganisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Services_Organisation_ID,Ref_Organisation_Details_ID,Ref_Service_ID")] ServicesOrganisation servicesOrganisation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicesOrganisation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ref_Service_ID = new SelectList(db.GP_Services, "Service_ID", "GP_Service_Name", servicesOrganisation.Ref_Service_ID);
            ViewBag.Ref_Organisation_Details_ID = new SelectList(db.Organisation_Details, "ID", "Organisation_Name", servicesOrganisation.Ref_Organisation_Details_ID);
            return View(servicesOrganisation);
        }

        // GET: ServicesOrganisations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesOrganisation servicesOrganisation = db.ServicesOrganisations.Find(id);
            if (servicesOrganisation == null)
            {
                return HttpNotFound();
            }
            return View(servicesOrganisation);
        }

        // POST: ServicesOrganisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicesOrganisation servicesOrganisation = db.ServicesOrganisations.Find(id);
            db.ServicesOrganisations.Remove(servicesOrganisation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ReportTest()
        {
            var model = new Models.ServiceTotals();

            model.TotalServiceType1 = db.ServicesOrganisations.Where(x => x.GP_Services.Service_ID == (int)8).Count();
            model.TotalServiceType2 = db.ServicesOrganisations.Where(x => x.GP_Services.Service_ID == (int)1).Count();

            return View(model);

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
