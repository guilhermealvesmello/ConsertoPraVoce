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
    public class ScriptsController : Controller
    {
        private CPVCEntities db = new CPVCEntities();

        // GET: Scripts
        public ActionResult Index()
        {
            return View(db.Scripts.ToList());
        }

        // GET: Scripts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scripts scripts = db.Scripts.Find(id);
            if (scripts == null)
            {
                return HttpNotFound();
            }
            return View(scripts);
        }

        // GET: Scripts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Scripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Descricao,DataExecucao")] Scripts scripts)
        {
            if (ModelState.IsValid)
            {
                db.Scripts.Add(scripts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scripts);
        }

        // GET: Scripts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scripts scripts = db.Scripts.Find(id);
            if (scripts == null)
            {
                return HttpNotFound();
            }
            return View(scripts);
        }

        // POST: Scripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Descricao,DataExecucao")] Scripts scripts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scripts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scripts);
        }

        // GET: Scripts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scripts scripts = db.Scripts.Find(id);
            if (scripts == null)
            {
                return HttpNotFound();
            }
            return View(scripts);
        }

        // POST: Scripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Scripts scripts = db.Scripts.Find(id);
            db.Scripts.Remove(scripts);
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
