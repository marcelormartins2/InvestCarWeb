﻿using InvestCarWeb.Data;
using InvestCarWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InvestCarWeb.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly IdentyDbContext _context;

        public VeiculosController(IdentyDbContext context)
        {
            _context = context;
        }

        // GET: Veiculos
        public async Task<IActionResult> Index()
        {
            var veiculo = _context.Veiculo;
            return View(await veiculo.ToListAsync());
        }

        // GET: Veiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // GET: Veiculos/Create
        public IActionResult Create()
        {
            ViewData["DespesaId"] = new SelectList(_context.Despesa, "Id", "Id");
            return View();
        }

        // POST: Veiculos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa,Chassis,Cor,Dut,Hodometro,AnoFab,AnoModelo,Origem,Renavam,ValorFipe,ValorPago,ValorVenda,DespesaId,ModeloCarId")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DespesaId"] = new SelectList(_context.Despesa, "Id", "Id", veiculo.DespesaId);
            return View(veiculo);
        }

        // GET: Veiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }
            ViewData["DespesaId"] = new SelectList(_context.Despesa, "Id", "Id", veiculo.DespesaId);
            return View(veiculo);
        }

        // POST: Veiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Placa,Chassis,Cor,Dut,Hodometro,AnoFab,AnoModelo,Origem,Renavam,ValorFipe,ValorPago,ValorVenda,DespesaId,ModeloCarId")] Veiculo veiculo)
        {
            if (id != veiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculoExists(veiculo.Id))
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
            ViewData["DespesaId"] = new SelectList(_context.Despesa, "Id", "Id", veiculo.DespesaId);
            return View(veiculo);
        }

        // GET: Veiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participacao = await _context.Participacao
               .FirstOrDefaultAsync(m => m.Veiculo.Id == id);
            var despesa = await _context.Despesa
                .FirstOrDefaultAsync(m => m.Veiculo.Id == id);
            if (participacao != null || despesa != null)
            {
                var txtMensagem = "";
                if (participacao != null)
                {
                    if (despesa != null)
                    {
                        txtMensagem = "Não é possível excluir o Veiculo," +
                             " pois ele tem participações de parceiros e despesas cadastradas. Exclua todas as participações e despesas vinculadas à este veículo para depois excluí-lo";
                    }
                    else
                    {
                        txtMensagem = "Não é possível excluir o Veiculo," +
                             " pois ele tem participações de parceiros cadastradas. Exclua todas as participações vinculadas à este veículo para depois excluí-lo";
                    }
                }
                else
                {
                    txtMensagem = "Não é possível excluir o Veiculo," +
                         " pois ele tem despesas cadastradas. Exclua todas as despesas vinculadas à este veículo para depois excluí-lo";
                }
                ViewData["Mensagem"] = txtMensagem;
                return View("Error");
            }

                var veiculo = await _context.Veiculo
                .FirstOrDefaultAsync(m => m.Id == id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veiculo = await _context.Veiculo.FindAsync(id);
            _context.Veiculo.Remove(veiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculoExists(int id)
        {
            return _context.Veiculo.Any(e => e.Id == id);
        }
    }
}
