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
    public class CorController : Controller
    {
        private CPVCEntities db = new CPVCEntities();

        // GET: Cor
        public ActionResult Index()
        {
            return View(db.Cor.ToList());
        }

        // GET: Cor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = db.Cor.Find(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // GET: Cor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] Cor cor)
        {
            if (ModelState.IsValid)
            {
                db.Cor.Add(cor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cor);
        }

        // GET: Cor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = db.Cor.Find(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // POST: Cor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] Cor cor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cor);
        }

        // GET: Cor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = db.Cor.Find(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // POST: Cor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cor cor = db.Cor.Find(id);
            db.Cor.Remove(cor);
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
