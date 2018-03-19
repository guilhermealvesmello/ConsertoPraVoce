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
	public class CategoriaTransacaoController : Controller
	{
		private CPVCEntities db = new CPVCEntities();

		// GET: CategoriaTransacao
		public ActionResult Index()
		{
			var categoriaTransacao = db.CategoriaTransacao.Include(c => c.CategoriaTransacao2);
			return View(categoriaTransacao.ToList());
		}

		// GET: CategoriaTransacao/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CategoriaTransacao categoriaTransacao = db.CategoriaTransacao.Find(id);
			if (categoriaTransacao == null)
			{
				return HttpNotFound();
			}
			return View(categoriaTransacao);
		}

		// GET: CategoriaTransacao/Create
		public ActionResult Create()
		{
			ViewBag.IdCategoriaPai = new SelectList(db.CategoriaTransacao, "Id", "Descricao");
			PreencherTipoDespesa();
			return View();
		}

		// POST: CategoriaTransacao/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Descricao,DescricaoLonga,IdCategoriaPai,TipoDespesa")] CategoriaTransacao categoriaTransacao)
		{
			if (ModelState.IsValid)
			{
				db.CategoriaTransacao.Add(categoriaTransacao);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.IdCategoriaPai = new SelectList(db.CategoriaTransacao, "Id", "Descricao", categoriaTransacao.IdCategoriaPai);
			return View(categoriaTransacao);
		}

		// GET: CategoriaTransacao/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CategoriaTransacao categoriaTransacao = db.CategoriaTransacao.Find(id);
			if (categoriaTransacao == null)
			{
				return HttpNotFound();
			}
			ViewBag.IdCategoriaPai = new SelectList(db.CategoriaTransacao, "Id", "Descricao", categoriaTransacao.IdCategoriaPai);
			PreencherTipoDespesa();
			return View(categoriaTransacao);
		}

		// POST: CategoriaTransacao/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Descricao,DescricaoLonga,IdCategoriaPai,TipoDespesa")] CategoriaTransacao categoriaTransacao)
		{
			if (ModelState.IsValid)
			{
				db.Entry(categoriaTransacao).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.IdCategoriaPai = new SelectList(db.CategoriaTransacao, "Id", "Descricao", categoriaTransacao.IdCategoriaPai);
			PreencherTipoDespesa();
			return View(categoriaTransacao);
		}

		// GET: CategoriaTransacao/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CategoriaTransacao categoriaTransacao = db.CategoriaTransacao.Find(id);
			if (categoriaTransacao == null)
			{
				return HttpNotFound();
			}
			return View(categoriaTransacao);
		}

		// POST: CategoriaTransacao/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			CategoriaTransacao categoriaTransacao = db.CategoriaTransacao.Find(id);
			db.CategoriaTransacao.Remove(categoriaTransacao);
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

		private void PreencherTipoDespesa()
		{
			ViewBag.TipoDespesa = new List<SelectListItem>() { new SelectListItem() { Text = "Crédito", Value = "C" }, new SelectListItem() { Text = "Débito", Value = "D" } };
		}
	}
}
