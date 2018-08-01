using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConsertoPraVoce.Model;
using ConsertoPraVoce.Regras.ViewModel;
using ConsertoPraVoce.Regras.Regras;

namespace ConsertoPraVoce.Controllers
{
	public class OrdemCompraController : Controller
	{
		private CPVCEntities db = new CPVCEntities();

		// GET: OrdemCompra
		public ActionResult Index()
		{
			var ordemCompra = db.OrdemCompra.Include(o => o.Fornecedor);
			return View(ordemCompra.ToList());
		}

		// GET: OrdemCompra/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			OrdemCompra ordemCompra = db.OrdemCompra.Find(id);
			if (ordemCompra == null)
			{
				return HttpNotFound();
			}
			return View(ordemCompra);
		}

		// GET: OrdemCompra/Create
		public ActionResult Create()
		{
			ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "Id", "Nome");
			var oc = new OrdemCompra();
			oc.DataCriacao = DateTime.Now;
			return View(oc);
		}

		// POST: OrdemCompra/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,DescricaoCurta,DescricaoLonga,DataCriacao,DataEdicao,IdFornecedor")] OrdemCompra ordemCompra)
		{
			if (ModelState.IsValid)
			{
				db.OrdemCompra.Add(ordemCompra);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "Id", "Nome", ordemCompra.IdFornecedor);
			return View(ordemCompra);
		}

		// GET: OrdemCompra/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			OrdemCompra ordemCompra = db.OrdemCompra.Find(id);
			if (ordemCompra == null)
			{
				return HttpNotFound();
			}
			ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "Id", "Nome", ordemCompra.IdFornecedor);
			return View(ordemCompra);
		}

		// POST: OrdemCompra/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,DescricaoCurta,DescricaoLonga,DataCriacao,DataEdicao,IdFornecedor")] OrdemCompra ordemCompra)
		{
			if (ModelState.IsValid)
			{
				db.Entry(ordemCompra).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "Id", "Nome", ordemCompra.IdFornecedor);
			return View(ordemCompra);
		}

		// GET: OrdemCompra/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			OrdemCompra ordemCompra = db.OrdemCompra.Find(id);
			if (ordemCompra == null)
			{
				return HttpNotFound();
			}
			return View(ordemCompra);
		}

		// POST: OrdemCompra/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			OrdemCompra ordemCompra = db.OrdemCompra.Find(id);
			db.OrdemCompra.Remove(ordemCompra);
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
		public JsonResult BuscarMarcas()
		{
			var data = new SelectList(db.Marca, "Id", "Descricao");
			return Json(new { data = data }, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public JsonResult BuscarModelosAparelhos(int? idMarca)
		{
			if (idMarca.HasValue)
			{
				var data = new SelectList(db.ModeloAparelho.Where(c => c.IdMarca == idMarca.Value).OrderBy(c=> c.Descricao) , "Id", "Descricao");
				return Json(new { data = data }, JsonRequestBehavior.AllowGet);
			}

			return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public JsonResult BuscarTiposProdutos(int? idModelo)
		{
			if (idModelo.HasValue)
			{
				var tipos = from t in db.TipoProduto
							join m in db.Produto on t.Id equals m.IdTipoProduto
							where m.IdModeloAparelho == idModelo.Value
							orderby t.Descricao
							select t;

				var data = new SelectList(tipos, "Id", "Descricao");
				return Json(new { data = data }, JsonRequestBehavior.AllowGet);
			}

			return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
		}


		[HttpGet]
		public JsonResult BuscarCores(int? idModelo, int? idTipo)
		{
			if (idModelo.HasValue)
			{
				var cores = from c in db.Cor
							join p in db.Produto on c.Id equals p.IdCor
							where p.IdModeloAparelho == idModelo.Value
								&& p.IdTipoProduto == idTipo.Value
							orderby c.Descricao
							select c;

				var data = new SelectList(cores, "Id", "Descricao");
				return Json(new { data = data }, JsonRequestBehavior.AllowGet);
			}

			return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public JsonResult BuscarMetodosDePagamento()
		{
			var data = new SelectList(db.MetodoPagamento, "Id", "Descricao");
			return Json(new { data = data }, JsonRequestBehavior.AllowGet);
		}

		public JsonResult CriarOrdemDeCompra(CriarOrdemDeCompraVM ordemCompra)
		{
			OrdemCompraRegras oc = new OrdemCompraRegras(ordemCompra);
			oc.SalvarOrdemDeCompra();
			
			return Json(true, JsonRequestBehavior.AllowGet);
		}





	}
}
