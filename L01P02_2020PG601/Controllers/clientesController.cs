﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L01P02_2020PG601.Models;

namespace L01P02_2020PG601.Controllers
{
    public class clientesController : Controller
    {
        private readonly restauranteDbContext _context;

        public clientesController(restauranteDbContext context)
        {
            _context = context;
        }

        // GET: clientes
        public async Task<IActionResult> Index()
        {
              return _context.clientes != null ? 
                          View(await _context.clientes.ToListAsync()) :
                          Problem("Entity set 'restauranteDbContext.clientes'  is null.");
        }

        // GET: clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var clientes = await _context.clientes
                .FirstOrDefaultAsync(m => m.clienteId == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // GET: clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("clienteId,nombreCliente,direccion")] clientes clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientes);
        }

        // GET: clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var clientes = await _context.clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }

        // POST: clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("clienteId,nombreCliente,direccion")] clientes clientes)
        {
            if (id != clientes.clienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!clientesExists(clientes.clienteId))
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
            return View(clientes);
        }

        // GET: clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var clientes = await _context.clientes
                .FirstOrDefaultAsync(m => m.clienteId == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.clientes == null)
            {
                return Problem("Entity set 'restauranteDbContext.clientes'  is null.");
            }
            var clientes = await _context.clientes.FindAsync(id);
            if (clientes != null)
            {
                _context.clientes.Remove(clientes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool clientesExists(int id)
        {
          return (_context.clientes?.Any(e => e.clienteId == id)).GetValueOrDefault();
        }
    }
}
