﻿using System;
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
    public class MetodoPagamentoController : Controller
    {
        private CPVCEntities db = new CPVCEntities();

        // GET: MetodoPagamento
        public ActionResult Index()
        {
            return View(db.MetodoPagamento.ToList());
        }

        // GET: MetodoPagamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoPagamento metodoPagamento = db.MetodoPagamento.Find(id);
            if (metodoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(metodoPagamento);
        }

        // GET: MetodoPagamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MetodoPagamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Parcelas,Taxa,PrazoPagamento")] MetodoPagamento metodoPagamento)
        {
            if (ModelState.IsValid)
            {
                db.MetodoPagamento.Add(metodoPagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(metodoPagamento);
        }

        // GET: MetodoPagamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoPagamento metodoPagamento = db.MetodoPagamento.Find(id);
            if (metodoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(metodoPagamento);
        }

        // POST: MetodoPagamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Parcelas,Taxa,PrazoPagamento")] MetodoPagamento metodoPagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metodoPagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metodoPagamento);
        }

        // GET: MetodoPagamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoPagamento metodoPagamento = db.MetodoPagamento.Find(id);
            if (metodoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(metodoPagamento);
        }

        // POST: MetodoPagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetodoPagamento metodoPagamento = db.MetodoPagamento.Find(id);
            db.MetodoPagamento.Remove(metodoPagamento);
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
