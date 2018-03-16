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
    public class ProdutoController : Controller
    {
        private CPVCEntities db = new CPVCEntities();

        // GET: Produto
        public ActionResult Index()
        {
            var produto = db.Produto.Include(p => p.Cor).Include(p => p.ModeloAparelho).Include(p => p.TipoProduto);
            return View(produto.ToList());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            ViewBag.IdCor = new SelectList(db.Cor, "Id", "Descricao").OrderBy(c=> c.Text);
            ViewBag.IdModeloAparelho = new SelectList(db.ModeloAparelho, "Id", "Descricao");
            ViewBag.IdTipoProduto = new SelectList(db.TipoProduto, "Id", "Descricao");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,QtdeMinima,Sku,IdTipoProduto,IdModeloAparelho,IdCor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCor = new SelectList(db.Cor, "Id", "Descricao", produto.IdCor);
            ViewBag.IdModeloAparelho = new SelectList(db.ModeloAparelho, "Id", "Descricao", produto.IdModeloAparelho);
            ViewBag.IdTipoProduto = new SelectList(db.TipoProduto, "Id", "Descricao", produto.IdTipoProduto);
            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCor = new SelectList(db.Cor, "Id", "Descricao", produto.IdCor);
            ViewBag.IdModeloAparelho = new SelectList(db.ModeloAparelho, "Id", "Descricao", produto.IdModeloAparelho);
            ViewBag.IdTipoProduto = new SelectList(db.TipoProduto, "Id", "Descricao", produto.IdTipoProduto);
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,QtdeMinima,Sku,IdTipoProduto,IdModeloAparelho,IdCor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCor = new SelectList(db.Cor, "Id", "Descricao", produto.IdCor);
            ViewBag.IdModeloAparelho = new SelectList(db.ModeloAparelho, "Id", "Descricao", produto.IdModeloAparelho);
            ViewBag.IdTipoProduto = new SelectList(db.TipoProduto, "Id", "Descricao", produto.IdTipoProduto);
            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produto.Find(id);
            db.Produto.Remove(produto);
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
