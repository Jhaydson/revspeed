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
using SpeedSystem.Helpers;

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

            ProdutoViewModel model = new ProdutoViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.Produtos = await db.Produtoes.FindAsync(id);
          //  model.Custos = await db.CustoProdutoes.FindAsync(model.Produtos.ProdutoId);
            model.Custos = db.CustoProdutoes.Where( x=> x.ProdutoId ==  model.Produtos.ProdutoId).FirstOrDefault();

            if (model.Produtos == null)
            {
                return HttpNotFound();
            }

            return View(model);
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
        public async Task<ActionResult> Create(ProdutoViewModel produto, int[] tamanhoId)
        {

            produto.Produtos.DataCreate = DateTime.Now;


            if (ModelState.IsValid)
            {

                var pic = string.Empty;
                var folder = "~/Content/ProdutosImage";
                if (produto.Produtos.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(produto.Produtos.ImageFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }
                produto.Produtos.Image = pic;

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

                if (produto.Produtos.ProdutoId != 0)
                {
                    produto.Custos.ProdutoId = produto.Produtos.ProdutoId;
                    db.CustoProdutoes.Add(produto.Custos);
                    await db.SaveChangesAsync();
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
            ProdutoViewModel model = new ProdutoViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            model.Produtos = await db.Produtoes.FindAsync(id);
            model.Custos = db.CustoProdutoes.Where(x => x.ProdutoId == model.Produtos.ProdutoId).FirstOrDefault();

            if (model.Produtos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColecaoId = new SelectList(db.Colecaos, "ColecaoId", "Nome", model.Produtos.ColecaoId);
            ViewBag.CorId = new SelectList(db.Cors, "CorId", "Nome", model.Produtos.CorId);
            ViewBag.MaterialId = new SelectList(db.Cors, "MaterialId", "Nome", model.Produtos.CorId);

           //Falta realizar a consulta dos tamanhos.
            return View(model);
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
