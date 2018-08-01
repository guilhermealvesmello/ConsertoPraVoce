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
	public class TarefasController : Controller
	{
		private CPVCEntities db = new CPVCEntities();

		// GET: Tarefas
		public ActionResult Index()
		{
			return View(db.Tarefas.ToList());
		}

		// GET: Tarefas/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Tarefas tarefas = db.Tarefas.Find(id);
			if (tarefas == null)
			{
				return HttpNotFound();
			}
			return View(tarefas);
		}

		// GET: Tarefas/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Tarefas/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Descricao,Finalizada")] Tarefas tarefas)
		{
			if (ModelState.IsValid)
			{
				db.Tarefas.Add(tarefas);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(tarefas);
		}

		// GET: Tarefas/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Tarefas tarefas = db.Tarefas.Find(id);
			if (tarefas == null)
			{
				return HttpNotFound();
			}
			return View(tarefas);
		}

		// POST: Tarefas/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Descricao,Finalizada")] Tarefas tarefas)
		{
			if (ModelState.IsValid)
			{
				db.Entry(tarefas).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(tarefas);
		}

		// GET: Tarefas/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Tarefas tarefas = db.Tarefas.Find(id);
			if (tarefas == null)
			{
				return HttpNotFound();
			}
			return View(tarefas);
		}

		// POST: Tarefas/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Tarefas tarefas = db.Tarefas.Find(id);
			db.Tarefas.Remove(tarefas);
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
		[HttpGet]
		public JsonResult BuscarTarefasPendentes()
		{
			var data = db.Tarefas.ToList();
			return Json(new { data = data }, JsonRequestBehavior.AllowGet);
		}

		public JsonResult AtualizarStatusTarefa(int idTarefa, bool finalizada)
		{
			var tarefa = db.Tarefas.Find(idTarefa);
			tarefa.Finalizada = finalizada;
			db.Entry(tarefa).State = EntityState.Modified;
			db.SaveChanges();

			return Json(true, JsonRequestBehavior.AllowGet);
		}
	}
}
