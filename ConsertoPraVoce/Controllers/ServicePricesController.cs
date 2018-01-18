using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConsertoPraVoce.Model;

namespace ConsertoPraVoce.Controllers
{
    public class ServicePricesController : Controller
    {
        private CPVCEntities db = new CPVCEntities();

        // GET: ServicePrices
        public ActionResult Index()
        {
            var servicePrices = db.ServicePrices.Include(s => s.Service);
            return View(servicePrices.ToList());
        }

        // GET: ServicePrices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicePrice servicePrice = db.ServicePrices.Find(id);
            if (servicePrice == null)
            {
                return HttpNotFound();
            }
            return View(servicePrice);
        }

        // GET: ServicePrices/Create
        public ActionResult Create()
        {
            ViewBag.IdService = new SelectList(db.Services, "Id", "Description");
            return View();
        }

        // POST: ServicePrices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdService,Updated,Price")] ServicePrice servicePrice)
        {
            if (ModelState.IsValid)
            {
                db.ServicePrices.Add(servicePrice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdService = new SelectList(db.Services, "Id", "Description", servicePrice.IdService);
            return View(servicePrice);
        }

        // GET: ServicePrices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicePrice servicePrice = db.ServicePrices.Find(id);
            if (servicePrice == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdService = new SelectList(db.Services, "Id", "Description", servicePrice.IdService);
            return View(servicePrice);
        }

        // POST: ServicePrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdService,Updated,Price")] ServicePrice servicePrice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicePrice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdService = new SelectList(db.Services, "Id", "Description", servicePrice.IdService);
            return View(servicePrice);
        }

        // GET: ServicePrices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicePrice servicePrice = db.ServicePrices.Find(id);
            if (servicePrice == null)
            {
                return HttpNotFound();
            }
            return View(servicePrice);
        }

        // POST: ServicePrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicePrice servicePrice = db.ServicePrices.Find(id);
            db.ServicePrices.Remove(servicePrice);
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
