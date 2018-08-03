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
	public class ClienteController : Controller
	{
		private CPVCEntities db = new CPVCEntities();

		private Cliente LoadDefaultParameters()
		{
			var cli = new Cliente();
			cli.Data = DateTime.Now;
			return cli;
		}


		// GET: Cliente
		public ActionResult Index()
		{
			var cliente = db.Cliente.Include(c => c.ModeloAparelho);
			return View(cliente.ToList());
		}

		// GET: Cliente/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Cliente cliente = db.Cliente.Find(id);
			if (cliente == null)
			{
				return HttpNotFound();
			}
			return View(cliente);
		}

		// GET: Cliente/Create
		public ActionResult Create()
		{
			var cli = LoadDefaultParameters();
			ViewBag.IdModeloAparelho = new SelectList(db.ModeloAparelho, "Id", "Descricao");
			return View(cli);
		}

		// POST: Cliente/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Nome,Email,Telefone1,Telefone2,DataNascimento,Notas,Data,IdModeloAparelho")] Cliente cliente)
		{
			if (ModelState.IsValid)
			{
				db.Cliente.Add(cliente);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.IdModeloAparelho = new SelectList(db.ModeloAparelho, "Id", "Descricao");
			return View(cliente);
		}

		// GET: Cliente/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Cliente cliente = db.Cliente.Find(id);
			if (cliente == null)
			{
				return HttpNotFound();
			}
			ViewBag.IdModeloAparelho = new SelectList(db.ModeloAparelho, "Id", "Descricao", cliente.IdModeloAparelho);
			return View(cliente);
		}

		// POST: Cliente/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Nome,Email,Telefone1,Telefone2,DataNascimento,Notas,Data,IdModeloAparelho")] Cliente cliente)
		{
			if (ModelState.IsValid)
			{
				db.Entry(cliente).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.IdModeloAparelho = new SelectList(db.ModeloAparelho, "Id", "Descricao", cliente.IdModeloAparelho);
			return View(cliente);
		}

		// GET: Cliente/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Cliente cliente = db.Cliente.Find(id);
			if (cliente == null)
			{
				return HttpNotFound();
			}
			return View(cliente);
		}

		// POST: Cliente/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Cliente cliente = db.Cliente.Find(id);
			db.Cliente.Remove(cliente);
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
