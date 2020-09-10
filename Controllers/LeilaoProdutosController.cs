using InvestCarWeb.Data;
using InvestCarWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InvestCarWeb.Controllers
{
    public class LeilaoProdutosController : Controller
    {
        private readonly IdentyDbContext _context;

        public LeilaoProdutosController(IdentyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.LeilaoProduto.ToListAsync());
        }

        public async Task<IActionResult> Details(int? produtoId, int? leilaoId)
        {
            if (produtoId == null || leilaoId == null)
            {
                return NotFound();
            }

            var leilaoProduto = await _context.LeilaoProduto
                .FirstOrDefaultAsync(m => m.Produto.Id == produtoId && m.Leilao.Id == leilaoId);
            if (leilaoProduto == null)
            {
                return NotFound();
            }

            return View(leilaoProduto);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: LeilaoProdutos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeilaoProduto leilaoProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leilaoProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leilaoProduto);
        }

        // GET: LeilaoProdutos/Edit/5
        public async Task<IActionResult> Edit(int? produtoId, int? leilaoId)
        {
            if (produtoId == null || leilaoId == null)
            {
                return NotFound();
            }

            var leilaoProduto = await _context.LeilaoProduto.FindAsync(produtoId, leilaoId);
            if (leilaoProduto == null)
            {
                return NotFound();
            }
            return View(leilaoProduto);
        }

        // POST: LeilaoProdutos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int leilaoId, int produtoId, LeilaoProduto leilaoProduto)
        {
            if (leilaoId != leilaoProduto.Leilao.Id || produtoId != leilaoProduto.Produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leilaoProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!leilaoProdutoExists(leilaoProduto.Produto.Id, leilaoProduto.Leilao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leilaoProduto);
        }

        // GET: LeilaoProdutos/Delete/5
        public async Task<IActionResult> Delete(int? produtoId, int? leilaoId)
        {
            if (produtoId == null || leilaoId == null)
            {
                return NotFound();
            }

            var leilaoProduto = await _context.LeilaoProduto
                .FirstOrDefaultAsync(m => m.Produto.Id == produtoId && m.Leilao.Id == leilaoId);
            if (leilaoProduto == null)
            {
                return NotFound();
            }

            return View(leilaoProduto);
        }

        // POST: LeilaoProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? produtoId, int? leilaoId)
        {
            var leilaoProduto = await _context.Veiculo.FindAsync(produtoId, leilaoId);
            _context.Veiculo.Remove(leilaoProduto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool leilaoProdutoExists(int? produtoId, int? leilaoId)
        {
            return _context.LeilaoProduto.Any(e => e.Produto.Id == produtoId && e.Leilao.Id == leilaoId);
        }
    }
}
