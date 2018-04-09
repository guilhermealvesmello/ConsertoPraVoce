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
    public class EstoqueProdutoController : Controller
    {
        private CPVCEntities db = new CPVCEntities();

        // GET: EstoqueProduto
        public ActionResult Index()
        {
            var estoqueProduto = db.EstoqueProduto.Include(e => e.HistoricoEstoque).Include(e => e.OrdemCompra).Include(e => e.Produto);
            return View(estoqueProduto.ToList());
        }

        // GET: EstoqueProduto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstoqueProduto estoqueProduto = db.EstoqueProduto.Find(id);
            if (estoqueProduto == null)
            {
                return HttpNotFound();
            }
            return View(estoqueProduto);
        }

        // GET: EstoqueProduto/Create
        public ActionResult Create()
        {
            ViewBag.IdHistorico = new SelectList(db.HistoricoEstoque, "Id", "Descricao");
            ViewBag.IdOrdemCompra = new SelectList(db.OrdemCompra, "Id", "DescricaoCurta");
            ViewBag.IdProduto = new SelectList(db.Produto, "Id", "Descricao");
            return View();
        }

        // POST: EstoqueProduto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdProduto,IdOrdemCompra,IdOrdemServico,DataMovimentacao,IdHistorico,ValorUnitario")] EstoqueProduto estoqueProduto)
        {
            if (ModelState.IsValid)
            {
                db.EstoqueProduto.Add(estoqueProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdHistorico = new SelectList(db.HistoricoEstoque, "Id", "Descricao", estoqueProduto.IdHistorico);
            ViewBag.IdOrdemCompra = new SelectList(db.OrdemCompra, "Id", "DescricaoCurta", estoqueProduto.IdOrdemCompra);
            ViewBag.IdProduto = new SelectList(db.Produto, "Id", "Descricao", estoqueProduto.IdProduto);
            return View(estoqueProduto);
        }

        // GET: EstoqueProduto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstoqueProduto estoqueProduto = db.EstoqueProduto.Find(id);
            if (estoqueProduto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdHistorico = new SelectList(db.HistoricoEstoque, "Id", "Descricao", estoqueProduto.IdHistorico);
            ViewBag.IdOrdemCompra = new SelectList(db.OrdemCompra, "Id", "DescricaoCurta", estoqueProduto.IdOrdemCompra);
            ViewBag.IdProduto = new SelectList(db.Produto, "Id", "Descricao", estoqueProduto.IdProduto);
            return View(estoqueProduto);
        }

        // POST: EstoqueProduto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdProduto,IdOrdemCompra,IdOrdemServico,DataMovimentacao,IdHistorico,ValorUnitario")] EstoqueProduto estoqueProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estoqueProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdHistorico = new SelectList(db.HistoricoEstoque, "Id", "Descricao", estoqueProduto.IdHistorico);
            ViewBag.IdOrdemCompra = new SelectList(db.OrdemCompra, "Id", "DescricaoCurta", estoqueProduto.IdOrdemCompra);
            ViewBag.IdProduto = new SelectList(db.Produto, "Id", "Descricao", estoqueProduto.IdProduto);
            return View(estoqueProduto);
        }

        // GET: EstoqueProduto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstoqueProduto estoqueProduto = db.EstoqueProduto.Find(id);
            if (estoqueProduto == null)
            {
                return HttpNotFound();
            }
            return View(estoqueProduto);
        }

        // POST: EstoqueProduto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstoqueProduto estoqueProduto = db.EstoqueProduto.Find(id);
            db.EstoqueProduto.Remove(estoqueProduto);
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
