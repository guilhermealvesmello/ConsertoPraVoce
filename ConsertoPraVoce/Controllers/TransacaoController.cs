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
    public class TransacaoController : Controller
    {
        private CPVCEntities db = new CPVCEntities();

        // GET: Transacao
        public ActionResult Index()
        {
            var transacao = db.Transacao.Include(t => t.CategoriaTransacao).Include(t => t.Cliente).Include(t => t.Conta).Include(t => t.OrdemServico);
            return View(transacao.ToList());
        }

        // GET: Transacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacao.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // GET: Transacao/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoriaTransacao = new SelectList(db.CategoriaTransacao, "Id", "Descricao");
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome");
            ViewBag.IdConta = new SelectList(db.Conta, "Id", "Descricao");
            ViewBag.IdOrdemServico = new SelectList(db.OrdemServico, "Id", "DescricaoCurta");
            return View();
        }

        // POST: Transacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataTransacao,Descricao,ValorBruto,ValorLiquido,IdCategoriaTransacao,IdCliente,PagamentoEfetuado,Detalhes,IdConta,IdOrdemServico,TipoEntrada")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                db.Transacao.Add(transacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoriaTransacao = new SelectList(db.CategoriaTransacao, "Id", "Descricao", transacao.IdCategoriaTransacao);
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome", transacao.IdCliente);
            ViewBag.IdConta = new SelectList(db.Conta, "Id", "Descricao", transacao.IdConta);
            ViewBag.IdOrdemServico = new SelectList(db.OrdemServico, "Id", "DescricaoCurta", transacao.IdOrdemServico);
            return View(transacao);
        }

        // GET: Transacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacao.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoriaTransacao = new SelectList(db.CategoriaTransacao, "Id", "Descricao", transacao.IdCategoriaTransacao);
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome", transacao.IdCliente);
            ViewBag.IdConta = new SelectList(db.Conta, "Id", "Descricao", transacao.IdConta);
            ViewBag.IdOrdemServico = new SelectList(db.OrdemServico, "Id", "DescricaoCurta", transacao.IdOrdemServico);
            return View(transacao);
        }

        // POST: Transacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataTransacao,Descricao,ValorBruto,ValorLiquido,IdCategoriaTransacao,IdCliente,PagamentoEfetuado,Detalhes,IdConta,IdOrdemServico,TipoEntrada")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoriaTransacao = new SelectList(db.CategoriaTransacao, "Id", "Descricao", transacao.IdCategoriaTransacao);
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome", transacao.IdCliente);
            ViewBag.IdConta = new SelectList(db.Conta, "Id", "Descricao", transacao.IdConta);
            ViewBag.IdOrdemServico = new SelectList(db.OrdemServico, "Id", "DescricaoCurta", transacao.IdOrdemServico);
            return View(transacao);
        }

        // GET: Transacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacao.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // POST: Transacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transacao transacao = db.Transacao.Find(id);
            db.Transacao.Remove(transacao);
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
