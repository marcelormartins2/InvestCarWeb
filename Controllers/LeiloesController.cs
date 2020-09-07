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
    public class LeiloesController : Controller
    {
        private readonly IdentyDbContext _context;

        public LeiloesController(IdentyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Leilao.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leilao = await _context.Leilao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leilao == null)
            {
                return NotFound();
            }

            return View(leilao);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Leilaos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Leilao leilao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leilao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leilao);
        }

        // GET: Leiloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leilao = await _context.Leilao.FindAsync(id);
            if (leilao == null)
            {
                return NotFound();
            }
            return View(leilao);
        }

        // POST: Leiloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Leilao leilao)
        {
            if (id != leilao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leilao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeilaoExists(leilao.Id))
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
            return View(leilao);
        }

        // GET: Leiloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leilao = await _context.Leilao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leilao == null)
            {
                return NotFound();
            }

            return View(leilao);
        }

        // POST: Leiloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leilao = await _context.Leilao.FindAsync(id);
            _context.Leilao.Remove(leilao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeilaoExists(int id)
        {
            return _context.Leilao.Any(e => e.Id == id);
        }
    }
}
