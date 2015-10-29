using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcNHS.DAL;

namespace mvcNHS.Controllers
{
    public class GP_ServicesController : Controller
    {
        private NHSPatientServicesEntities db = new NHSPatientServicesEntities();

        // GET: GP_Services
        public ActionResult Index()
        {
            return View(db.GP_Services.ToList());
        }

        // GET: GP_Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GP_Services gP_Services = db.GP_Services.Find(id);
            if (gP_Services == null)
            {
                return HttpNotFound();
            }
            return View(gP_Services);
        }

        // GET: GP_Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GP_Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Service_ID,GP_Service_Name")] GP_Services gP_Services)
        {
            if (ModelState.IsValid)
            {
                db.GP_Services.Add(gP_Services);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gP_Services);
        }

        // GET: GP_Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GP_Services gP_Services = db.GP_Services.Find(id);
            if (gP_Services == null)
            {
                return HttpNotFound();
            }
            return View(gP_Services);
        }

        // POST: GP_Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Service_ID,GP_Service_Name")] GP_Services gP_Services)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gP_Services).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gP_Services);
        }

        // GET: GP_Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GP_Services gP_Services = db.GP_Services.Find(id);
            if (gP_Services == null)
            {
                return HttpNotFound();
            }
            return View(gP_Services);
        }

        // POST: GP_Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GP_Services gP_Services = db.GP_Services.Find(id);
            db.GP_Services.Remove(gP_Services);
            db.SaveChanges();
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
