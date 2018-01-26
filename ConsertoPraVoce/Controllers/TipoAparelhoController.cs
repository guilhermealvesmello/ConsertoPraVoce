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
    public class TipoAparelhoController : Controller
    {
        private CPVCEntities db = new CPVCEntities();

        // GET: TipoAparelho
        public ActionResult Index()
        {
            return View(db.TipoAparelho.ToList());
        }

        // GET: TipoAparelho/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAparelho tipoAparelho = db.TipoAparelho.Find(id);
            if (tipoAparelho == null)
            {
                return HttpNotFound();
            }
            return View(tipoAparelho);
        }

        // GET: TipoAparelho/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoAparelho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] TipoAparelho tipoAparelho)
        {
            if (ModelState.IsValid)
            {
                db.TipoAparelho.Add(tipoAparelho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoAparelho);
        }

        // GET: TipoAparelho/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAparelho tipoAparelho = db.TipoAparelho.Find(id);
            if (tipoAparelho == null)
            {
                return HttpNotFound();
            }
            return View(tipoAparelho);
        }

        // POST: TipoAparelho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] TipoAparelho tipoAparelho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAparelho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAparelho);
        }

        // GET: TipoAparelho/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAparelho tipoAparelho = db.TipoAparelho.Find(id);
            if (tipoAparelho == null)
            {
                return HttpNotFound();
            }
            return View(tipoAparelho);
        }

        // POST: TipoAparelho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAparelho tipoAparelho = db.TipoAparelho.Find(id);
            db.TipoAparelho.Remove(tipoAparelho);
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
