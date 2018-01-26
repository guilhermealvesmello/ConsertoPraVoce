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
    public class PrecoServicoController : Controller
    {
        private CPVCEntities db = new CPVCEntities();

        // GET: PrecoServico
        public ActionResult Index()
        {
            var precoServico = db.PrecoServico.Include(p => p.Servico);
            return View(precoServico.ToList());
        }

        // GET: PrecoServico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoServico precoServico = db.PrecoServico.Find(id);
            if (precoServico == null)
            {
                return HttpNotFound();
            }
            return View(precoServico);
        }

        // GET: PrecoServico/Create
        public ActionResult Create()
        {
            ViewBag.IdServico = new SelectList(db.Servico, "Id", "Descricao");
            return View();
        }

        // POST: PrecoServico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdServico,DataAtualizacao,PrecoDinheiro,PrecoDebito,PrecoCredito")] PrecoServico precoServico)
        {
            if (ModelState.IsValid)
            {
                db.PrecoServico.Add(precoServico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdServico = new SelectList(db.Servico, "Id", "Descricao", precoServico.IdServico);
            return View(precoServico);
        }

        // GET: PrecoServico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoServico precoServico = db.PrecoServico.Find(id);
            if (precoServico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdServico = new SelectList(db.Servico, "Id", "Descricao", precoServico.IdServico);
            return View(precoServico);
        }

        // POST: PrecoServico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdServico,DataAtualizacao,PrecoDinheiro,PrecoDebito,PrecoCredito")] PrecoServico precoServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(precoServico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdServico = new SelectList(db.Servico, "Id", "Descricao", precoServico.IdServico);
            return View(precoServico);
        }

        // GET: PrecoServico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoServico precoServico = db.PrecoServico.Find(id);
            if (precoServico == null)
            {
                return HttpNotFound();
            }
            return View(precoServico);
        }

        // POST: PrecoServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrecoServico precoServico = db.PrecoServico.Find(id);
            db.PrecoServico.Remove(precoServico);
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
