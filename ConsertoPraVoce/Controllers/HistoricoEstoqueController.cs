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
    public class HistoricoEstoqueController : Controller
    {
        private CPVCEntities db = new CPVCEntities();

        // GET: HistoricoEstoque
        public ActionResult Index()
        {
            return View(db.HistoricoEstoque.ToList());
        }

        // GET: HistoricoEstoque/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricoEstoque historicoEstoque = db.HistoricoEstoque.Find(id);
            if (historicoEstoque == null)
            {
                return HttpNotFound();
            }
            return View(historicoEstoque);
        }

        // GET: HistoricoEstoque/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistoricoEstoque/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Entrada")] HistoricoEstoque historicoEstoque)
        {
            if (ModelState.IsValid)
            {
                db.HistoricoEstoque.Add(historicoEstoque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historicoEstoque);
        }

        // GET: HistoricoEstoque/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricoEstoque historicoEstoque = db.HistoricoEstoque.Find(id);
            if (historicoEstoque == null)
            {
                return HttpNotFound();
            }
            return View(historicoEstoque);
        }

        // POST: HistoricoEstoque/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Entrada")] HistoricoEstoque historicoEstoque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historicoEstoque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historicoEstoque);
        }

        // GET: HistoricoEstoque/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricoEstoque historicoEstoque = db.HistoricoEstoque.Find(id);
            if (historicoEstoque == null)
            {
                return HttpNotFound();
            }
            return View(historicoEstoque);
        }

        // POST: HistoricoEstoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoricoEstoque historicoEstoque = db.HistoricoEstoque.Find(id);
            db.HistoricoEstoque.Remove(historicoEstoque);
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
