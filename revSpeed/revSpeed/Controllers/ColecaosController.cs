﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using revSpeed.Data;
using revSpeed.Models;

namespace revSpeed.Controllers
{
    public class ColecaosController : Controller
    {
        private RevSpeedContext db = new RevSpeedContext();

        // GET: Colecaos
        public async Task<ActionResult> Index()
        {
            return View(await db.Colecaos.ToListAsync());
        }

        // GET: Colecaos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colecao colecao = await db.Colecaos.FindAsync(id);
            if (colecao == null)
            {
                return HttpNotFound();
            }
            return View(colecao);
        }

        // GET: Colecaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colecaos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ColecaoId,Nome,Lancamento,DataCreate")] Colecao colecao)
        {
            if (ModelState.IsValid)
            {

			try{

                db.Colecaos.Add(colecao);
                await db.SaveChangesAsync();
			}
				catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
                    return View( colecao);
                    throw;
                }
                return RedirectToAction("Index");
            }

            return View(colecao);
        }

        // GET: Colecaos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colecao colecao = await db.Colecaos.FindAsync(id);
            if (colecao == null)
            {
                return HttpNotFound();
            }
            return View(colecao);
        }

        // POST: Colecaos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ColecaoId,Nome,Lancamento,DataCreate")] Colecao colecao)
        {
            if (ModelState.IsValid)
            {
			try{

                db.Entry(colecao).State = EntityState.Modified;
                await db.SaveChangesAsync();
			}
				catch (System.Exception)
					{
						ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
						return View(colecao);
						throw;
					}
                return RedirectToAction("Index");
            }
            return View(colecao);
        }

        // GET: Colecaos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colecao colecao = await db.Colecaos.FindAsync(id);
            if (colecao == null)
            {
                return HttpNotFound();
            }
            return View(colecao);
        }

        // POST: Colecaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Colecao colecao = await db.Colecaos.FindAsync(id);
            db.Colecaos.Remove(colecao);
            await db.SaveChangesAsync();
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
