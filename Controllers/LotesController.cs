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
    public class LotesController : Controller
    {
        private readonly IdentyDbContext _context;

        public LotesController(IdentyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Lote.ToListAsync());
        }

        public async Task<IActionResult> Details(int? produtoId, int? leilaoId)
        {
            if (produtoId == null || leilaoId == null)
            {
                return NotFound();
            }

            var Lote = await _context.Lote
                .FirstOrDefaultAsync(m => m.Produto.Id == produtoId && m.Leilao.Id == leilaoId);
            if (Lote == null)
            {
                return NotFound();
            }

            return View(Lote);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Lotes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lote Lote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Lote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Lote);
        }

        // GET: Lotes/Edit/5
        public async Task<IActionResult> Edit(int? produtoId, int? leilaoId)
        {
            if (produtoId == null || leilaoId == null)
            {
                return NotFound();
            }

            var Lote = await _context.Lote.FindAsync(produtoId, leilaoId);
            if (Lote == null)
            {
                return NotFound();
            }
            return View(Lote);
        }

        // POST: Lotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int leilaoId, int produtoId, Lote Lote)
        {
            if (leilaoId != Lote.Leilao.Id || produtoId != Lote.Produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Lote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoteExists(Lote.Produto.Id, Lote.Leilao.Id))
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
            return View(Lote);
        }

        // GET: Lotes/Delete/5
        public async Task<IActionResult> Delete(int? produtoId, int? leilaoId)
        {
            if (produtoId == null || leilaoId == null)
            {
                return NotFound();
            }

            var Lote = await _context.Lote
                .FirstOrDefaultAsync(m => m.Produto.Id == produtoId && m.Leilao.Id == leilaoId);
            if (Lote == null)
            {
                return NotFound();
            }

            return View(Lote);
        }

        // POST: Lotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? produtoId, int? leilaoId)
        {
            var Lote = await _context.Veiculo.FindAsync(produtoId, leilaoId);
            _context.Veiculo.Remove(Lote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoteExists(int? produtoId, int? leilaoId)
        {
            return _context.Lote.Any(e => e.Produto.Id == produtoId && e.Leilao.Id == leilaoId);
        }
    }
}
