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
    public class CoresController : Controller
    {
        private RevSpeedContext db = new RevSpeedContext();

        // GET: Cores
        public async Task<ActionResult> Index()
        {
            return View(await db.Cors.ToListAsync());
        }

        // GET: Cores/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = await db.Cors.FindAsync(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // GET: Cores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CorId,Nome")] Cor cor)
        {
            if (ModelState.IsValid)
            {

			try{

                db.Cors.Add(cor);
                await db.SaveChangesAsync();
			}
				catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
                    return View( cor);
                    throw;
                }
                return RedirectToAction("Index");
            }

            return View(cor);
        }

        // GET: Cores/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = await db.Cors.FindAsync(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // POST: Cores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CorId,Nome")] Cor cor)
        {
            if (ModelState.IsValid)
            {
			try{

                db.Entry(cor).State = EntityState.Modified;
                await db.SaveChangesAsync();
			}
				catch (System.Exception)
					{
						ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
						return View(cor);
						throw;
					}
                return RedirectToAction("Index");
            }
            return View(cor);
        }

        // GET: Cores/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = await db.Cors.FindAsync(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // POST: Cores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cor cor = await db.Cors.FindAsync(id);
            db.Cors.Remove(cor);
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
