﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjeTeklas.Data;
using ProjeTeklas.Models;

namespace ProjeTeklas.Controllers
{
    public class SinifsController : Controller
    {
        private readonly DataContext _context;

        public SinifsController(DataContext context)
        {
            _context = context;
        }

        // GET: Sinifs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sinifs.ToListAsync());
        }

        // GET: Sinifs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinif = await _context.Sinifs
                .FirstOrDefaultAsync(m => m.SinifId == id);
            if (sinif == null)
            {
                return NotFound();
            }

            return View(sinif);
        }

        // GET: Sinifs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sinifs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SinifId,SinifAdi")] Sinif sinif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sinif);
        }

        // GET: Sinifs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinif = await _context.Sinifs.FindAsync(id);
            if (sinif == null)
            {
                return NotFound();
            }
            return View(sinif);
        }

        // POST: Sinifs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SinifId,SinifAdi")] Sinif sinif)
        {
            if (id != sinif.SinifId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinif);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinifExists(sinif.SinifId))
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
            return View(sinif);
        }

        // GET: Sinifs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinif = await _context.Sinifs
                .FirstOrDefaultAsync(m => m.SinifId == id);
            if (sinif == null)
            {
                return NotFound();
            }

            return View(sinif);
        }

        // POST: Sinifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sinif = await _context.Sinifs.FindAsync(id);
            _context.Sinifs.Remove(sinif);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinifExists(int id)
        {
            return _context.Sinifs.Any(e => e.SinifId == id);
        }
    }
}
