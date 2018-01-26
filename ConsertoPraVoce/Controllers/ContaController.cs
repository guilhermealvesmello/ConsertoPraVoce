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
    public class ContaController : Controller
    {
        private CPVCEntities db = new CPVCEntities();

        // GET: Conta
        public ActionResult Index()
        {
            return View(db.Conta.ToList());
        }

        // GET: Conta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = db.Conta.Find(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        }

        // GET: Conta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,DataCriacao")] Conta conta)
        {
            if (ModelState.IsValid)
            {
                db.Conta.Add(conta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conta);
        }

        // GET: Conta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = db.Conta.Find(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        }

        // POST: Conta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,DataCriacao")] Conta conta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conta);
        }

        // GET: Conta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = db.Conta.Find(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        }

        // POST: Conta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Conta conta = db.Conta.Find(id);
            db.Conta.Remove(conta);
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
