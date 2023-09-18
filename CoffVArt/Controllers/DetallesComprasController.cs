using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffVArt.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoffVArt.Controllers
{
    public class DetallesComprasController : Controller
    {
        private readonly Coffvart2Context _context;

        public DetallesComprasController(Coffvart2Context context)
        {
            _context = context;
        }

        [Authorize]
        // GET: DetallesCompras
        public async Task<IActionResult> Index()
        {
            var coffvart2Context = _context.DetallesCompras.Include(d => d.Compra).Include(d => d.Insumo);
            return View(await coffvart2Context.ToListAsync());
        }

        // GET: DetallesCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetallesCompras == null)
            {
                return NotFound();
            }

            var detallesCompra = await _context.DetallesCompras
                .Include(d => d.Compra)
                .Include(d => d.Insumo)
                .FirstOrDefaultAsync(m => m.DetalleCompraId == id);
            if (detallesCompra == null)
            {
                return NotFound();
            }

            return View(detallesCompra);
        }

        // GET: DetallesCompras/Create
        public IActionResult Create()
        {
            ViewData["CompraId"] = new SelectList(_context.Compras, "IdCompra", "IdCompra");
            ViewData["InsumoId"] = new SelectList(_context.Insumos, "IdInsumos", "IdInsumos");
            return View();
        }

        // POST: DetallesCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetalleCompraId,CompraId,InsumoId,Cantidad,Valor")] DetallesCompra detallesCompra)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(detallesCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompraId"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", detallesCompra.CompraId);
            ViewData["InsumoId"] = new SelectList(_context.Insumos, "IdInsumos", "IdInsumos", detallesCompra.InsumoId);
            return View(detallesCompra);
        }

        // GET: DetallesCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetallesCompras == null)
            {
                return NotFound();
            }

            var detallesCompra = await _context.DetallesCompras.FindAsync(id);
            if (detallesCompra == null)
            {
                return NotFound();
            }
            ViewData["CompraId"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", detallesCompra.CompraId);
            ViewData["InsumoId"] = new SelectList(_context.Insumos, "IdInsumos", "IdInsumos", detallesCompra.InsumoId);
            return View(detallesCompra);
        }

        // POST: DetallesCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalleCompraId,CompraId,InsumoId,Cantidad,Valor")] DetallesCompra detallesCompra)
        {
            if (id != detallesCompra.DetalleCompraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallesCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesCompraExists(detallesCompra.DetalleCompraId))
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
            ViewData["CompraId"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", detallesCompra.CompraId);
            ViewData["InsumoId"] = new SelectList(_context.Insumos, "IdInsumos", "IdInsumos", detallesCompra.InsumoId);
            return View(detallesCompra);
        }

        // GET: DetallesCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetallesCompras == null)
            {
                return NotFound();
            }

            var detallesCompra = await _context.DetallesCompras
                .Include(d => d.Compra)
                .Include(d => d.Insumo)
                .FirstOrDefaultAsync(m => m.DetalleCompraId == id);
            if (detallesCompra == null)
            {
                return NotFound();
            }

            return View(detallesCompra);
        }

        // POST: DetallesCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetallesCompras == null)
            {
                return Problem("Entity set 'Coffvart2Context.DetallesCompras'  is null.");
            }
            var detallesCompra = await _context.DetallesCompras.FindAsync(id);
            if (detallesCompra != null)
            {
                _context.DetallesCompras.Remove(detallesCompra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesCompraExists(int id)
        {
          return (_context.DetallesCompras?.Any(e => e.DetalleCompraId == id)).GetValueOrDefault();
        }
    }
}
