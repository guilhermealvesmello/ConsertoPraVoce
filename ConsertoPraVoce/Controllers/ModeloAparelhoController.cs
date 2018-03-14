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
    public class ModeloAparelhoController : Controller
    {
        private CPVCEntities db = new CPVCEntities();

        // GET: ModeloAparelho
        public ActionResult Index()
        {
            var modeloAparelho = db.ModeloAparelho.Include(m => m.Marca).Include(m => m.TipoAparelho);
            return View(modeloAparelho.ToList());
        }

        // GET: ModeloAparelho/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloAparelho modeloAparelho = db.ModeloAparelho.Find(id);
            if (modeloAparelho == null)
            {
                return HttpNotFound();
            }
            return View(modeloAparelho);
        }

        // GET: ModeloAparelho/Create
        public ActionResult Create()
        {
            ViewBag.IdMarca = new SelectList(db.Marca, "Id", "Descricao");
            ViewBag.IdTipoAparelho = new SelectList(db.TipoAparelho, "Id", "Descricao");
            return View();
        }

        // POST: ModeloAparelho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,NumeroModelo,IdTipoAparelho,IdMarca")] ModeloAparelho modeloAparelho)
        {
            if (ModelState.IsValid)
            {
                db.ModeloAparelho.Add(modeloAparelho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMarca = new SelectList(db.Marca, "Id", "Descricao", modeloAparelho.IdMarca);
            ViewBag.IdTipoAparelho = new SelectList(db.TipoAparelho, "Id", "Descricao", modeloAparelho.IdTipoAparelho);
            return View(modeloAparelho);
        }

        // GET: ModeloAparelho/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloAparelho modeloAparelho = db.ModeloAparelho.Find(id);
            if (modeloAparelho == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMarca = new SelectList(db.Marca, "Id", "Descricao", modeloAparelho.IdMarca);
            ViewBag.IdTipoAparelho = new SelectList(db.TipoAparelho, "Id", "Descricao", modeloAparelho.IdTipoAparelho);
            return View(modeloAparelho);
        }

        // POST: ModeloAparelho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,NumeroModelo,IdTipoAparelho,IdMarca")] ModeloAparelho modeloAparelho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modeloAparelho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMarca = new SelectList(db.Marca, "Id", "Descricao", modeloAparelho.IdMarca);
            ViewBag.IdTipoAparelho = new SelectList(db.TipoAparelho, "Id", "Descricao", modeloAparelho.IdTipoAparelho);
            return View(modeloAparelho);
        }

        // GET: ModeloAparelho/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloAparelho modeloAparelho = db.ModeloAparelho.Find(id);
            if (modeloAparelho == null)
            {
                return HttpNotFound();
            }
            return View(modeloAparelho);
        }

        // POST: ModeloAparelho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModeloAparelho modeloAparelho = db.ModeloAparelho.Find(id);
            db.ModeloAparelho.Remove(modeloAparelho);
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
