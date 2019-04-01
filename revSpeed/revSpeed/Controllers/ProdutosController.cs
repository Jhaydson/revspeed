using System;
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
using revSpeed.Models.ViewsModels;

namespace revSpeed.Controllers
{
    public class ProdutosController : Controller
    {
        private RevSpeedContext db = new RevSpeedContext();

        // GET: Produtos
        public async Task<ActionResult> Index()
        {
            var produtoes = db.Produtoes.Include(p => p.Colecoes).Include(p => p.Cores);
            return View(await produtoes.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = await db.Produtoes.FindAsync(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {

            ProdutoViewModel model = new ProdutoViewModel();
            model.Produtos = new Produto();
            model.Custos = new CustoProduto();

            ViewBag.Cor = new SelectList(db.Cors, "CorId", "Nome");
            ViewBag.Material = new SelectList(db.Materials, "MaterialId", "Nome");
            ViewBag.Colecao = new SelectList(db.Colecaos, "ColecaoId", "Nome");

            var tamanhos = db.Tamanhos.Select(c => new
            {
                TamanhoID = c.TamanhoId,
                TamNome = c.Nome
            }).ToList();


            ViewBag.Tamanhos = new MultiSelectList(tamanhos, "TamanhoID", "TamNome");
            return View(model);
        }

        // POST: Produtos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int[] tamanhoId, ProdutoViewModel produto)
        {

            if (ModelState.IsValid)
            {
                
                if (tamanhoId.Count() > 0)
                {
                    var ProdTams = db.Tamanhos.Where(w => tamanhoId.Contains(w.TamanhoId)).ToList();
                    produto.Produtos.Tamanhos.AddRange(ProdTams);
                }

                try
                {
                    db.Produtoes.Add(produto.Produtos);
                    await db.SaveChangesAsync();
                }
                catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
                    return View(produto);
                    throw;
                }
                return RedirectToAction("Index");
            }
           



            ViewBag.ColecaoId = new SelectList(db.Colecaos, "ColecaoId", "Nome", produto.Produtos.ColecaoId);
            ViewBag.CorId = new SelectList(db.Cors, "CorId", "Nome", produto.Produtos.ColecaoId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = await db.Produtoes.FindAsync(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColecaoId = new SelectList(db.Colecaos, "ColecaoId", "Nome", produto.ColecaoId);
            ViewBag.CorId = new SelectList(db.Cors, "CorId", "Nome", produto.CorId);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProdutoId,Nome,CodProduto,ValorVenda,SugestaoPreco,CorId,ColecaoId,Pontos,DataCreate")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    db.Entry(produto).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
                    return View(produto);
                    throw;
                }
                return RedirectToAction("Index");
            }
            ViewBag.ColecaoId = new SelectList(db.Colecaos, "ColecaoId", "Nome", produto.ColecaoId);
            ViewBag.CorId = new SelectList(db.Cors, "CorId", "Nome", produto.CorId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = await db.Produtoes.FindAsync(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Produto produto = await db.Produtoes.FindAsync(id);
            db.Produtoes.Remove(produto);
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
