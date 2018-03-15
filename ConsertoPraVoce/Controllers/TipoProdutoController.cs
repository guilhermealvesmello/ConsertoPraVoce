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
    public class TipoProdutoController : Controller
    {
        private CPVCEntities db = new CPVCEntities();

        // GET: TipoProduto
        public ActionResult Index()
        {
            return View(db.TipoProduto.ToList());
        }

        // GET: TipoProduto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProduto tipoProduto = db.TipoProduto.Find(id);
            if (tipoProduto == null)
            {
                return HttpNotFound();
            }
            return View(tipoProduto);
        }

        // GET: TipoProduto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoProduto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] TipoProduto tipoProduto)
        {
            if (ModelState.IsValid)
            {
                db.TipoProduto.Add(tipoProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoProduto);
        }

        // GET: TipoProduto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProduto tipoProduto = db.TipoProduto.Find(id);
            if (tipoProduto == null)
            {
                return HttpNotFound();
            }
            return View(tipoProduto);
        }

        // POST: TipoProduto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] TipoProduto tipoProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoProduto);
        }

        // GET: TipoProduto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProduto tipoProduto = db.TipoProduto.Find(id);
            if (tipoProduto == null)
            {
                return HttpNotFound();
            }
            return View(tipoProduto);
        }

        // POST: TipoProduto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoProduto tipoProduto = db.TipoProduto.Find(id);
            db.TipoProduto.Remove(tipoProduto);
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
