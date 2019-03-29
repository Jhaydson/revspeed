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
    public class TamanhosController : Controller
    {
        private RevSpeedContext db = new RevSpeedContext();

        // GET: Tamanhos
        public async Task<ActionResult> Index()
        {
            return View(await db.Tamanhos.ToListAsync());
        }

        // GET: Tamanhos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamanho tamanho = await db.Tamanhos.FindAsync(id);
            if (tamanho == null)
            {
                return HttpNotFound();
            }
            return View(tamanho);
        }

        // GET: Tamanhos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tamanhos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TamanhoId,Nome,DataCreate")] Tamanho tamanho)
        {
            if (ModelState.IsValid)
            {

			try{

                db.Tamanhos.Add(tamanho);
                await db.SaveChangesAsync();
			}
				catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
                    return View( tamanho);
                    throw;
                }
                return RedirectToAction("Index");
            }

            return View(tamanho);
        }

        // GET: Tamanhos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamanho tamanho = await db.Tamanhos.FindAsync(id);
            if (tamanho == null)
            {
                return HttpNotFound();
            }
            return View(tamanho);
        }

        // POST: Tamanhos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TamanhoId,Nome,DataCreate")] Tamanho tamanho)
        {
            if (ModelState.IsValid)
            {
			try{

                db.Entry(tamanho).State = EntityState.Modified;
                await db.SaveChangesAsync();
			}
				catch (System.Exception)
					{
						ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
						return View(tamanho);
						throw;
					}
                return RedirectToAction("Index");
            }
            return View(tamanho);
        }

        // GET: Tamanhos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamanho tamanho = await db.Tamanhos.FindAsync(id);
            if (tamanho == null)
            {
                return HttpNotFound();
            }
            return View(tamanho);
        }

        // POST: Tamanhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tamanho tamanho = await db.Tamanhos.FindAsync(id);
            db.Tamanhos.Remove(tamanho);
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
