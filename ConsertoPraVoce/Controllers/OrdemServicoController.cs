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
    public class OrdemServicoController : Controller
    {
        private CPVCEntities db = new CPVCEntities();

        // GET: OrdemServico
        public ActionResult Index()
        {
            return View(db.OrdemServico.ToList());
        }

        // GET: OrdemServico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemServico ordemServico = db.OrdemServico.Find(id);
            if (ordemServico == null)
            {
                return HttpNotFound();
            }
            return View(ordemServico);
        }

        // GET: OrdemServico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdemServico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DescricaoCurta,DescricaoLonga,DataCriacao,DataEdicao,Prazo")] OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                db.OrdemServico.Add(ordemServico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordemServico);
        }

        // GET: OrdemServico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemServico ordemServico = db.OrdemServico.Find(id);
            if (ordemServico == null)
            {
                return HttpNotFound();
            }
            return View(ordemServico);
        }

        // POST: OrdemServico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DescricaoCurta,DescricaoLonga,DataCriacao,DataEdicao,Prazo")] OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordemServico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordemServico);
        }

        // GET: OrdemServico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemServico ordemServico = db.OrdemServico.Find(id);
            if (ordemServico == null)
            {
                return HttpNotFound();
            }
            return View(ordemServico);
        }

        // POST: OrdemServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdemServico ordemServico = db.OrdemServico.Find(id);
            db.OrdemServico.Remove(ordemServico);
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
