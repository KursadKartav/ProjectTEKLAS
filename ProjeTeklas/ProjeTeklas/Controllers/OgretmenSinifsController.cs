using System;
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
    public class OgretmenSinifsController : Controller
    {
        private readonly DataContext _context;

        public OgretmenSinifsController(DataContext context)
        {
            _context = context;
        }

        // GET: OgretmenSinifs
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.OgretmenSinifs.Include(o => o.Ogretmen).Include(o => o.Sinif);
            return View(await dataContext.ToListAsync());
        }

        // GET: OgretmenSinifs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmenSinif = await _context.OgretmenSinifs
                .Include(o => o.Ogretmen)
                .Include(o => o.Sinif)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogretmenSinif == null)
            {
                return NotFound();
            }

            return View(ogretmenSinif);
        }

        // GET: OgretmenSinifs/Create
        public IActionResult Create()
        {
            ViewData["OgretmenId"] = new SelectList(_context.Ogretmens, "OgretmenId", "OgretmenId");
            ViewData["SinifId"] = new SelectList(_context.Sinifs, "SinifId", "SinifAdi");
            return View();
        }

        // POST: OgretmenSinifs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SinifId,OgretmenId")] OgretmenSinif ogretmenSinif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogretmenSinif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OgretmenId"] = new SelectList(_context.Ogretmens, "OgretmenId", "OgretmenId", ogretmenSinif.OgretmenId);
            ViewData["SinifId"] = new SelectList(_context.Sinifs, "SinifId", "SinifAdi", ogretmenSinif.SinifId);
            return View(ogretmenSinif);
        }

        // GET: OgretmenSinifs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmenSinif = await _context.OgretmenSinifs.FindAsync(id);
            if (ogretmenSinif == null)
            {
                return NotFound();
            }
            ViewData["OgretmenId"] = new SelectList(_context.Ogretmens, "OgretmenId", "OgretmenId", ogretmenSinif.OgretmenId);
            ViewData["SinifId"] = new SelectList(_context.Sinifs, "SinifId", "SinifId", ogretmenSinif.SinifId);
            return View(ogretmenSinif);
        }

        // POST: OgretmenSinifs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SinifId,OgretmenId")] OgretmenSinif ogretmenSinif)
        {
            if (id != ogretmenSinif.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogretmenSinif);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgretmenSinifExists(ogretmenSinif.Id))
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
            ViewData["OgretmenId"] = new SelectList(_context.Ogretmens, "OgretmenId", "OgretmenId", ogretmenSinif.OgretmenId);
            ViewData["SinifId"] = new SelectList(_context.Sinifs, "SinifId", "SinifId", ogretmenSinif.SinifId);
            return View(ogretmenSinif);
        }

        // GET: OgretmenSinifs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmenSinif = await _context.OgretmenSinifs
                .Include(o => o.Ogretmen)
                .Include(o => o.Sinif)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogretmenSinif == null)
            {
                return NotFound();
            }

            return View(ogretmenSinif);
        }

        // POST: OgretmenSinifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ogretmenSinif = await _context.OgretmenSinifs.FindAsync(id);
            _context.OgretmenSinifs.Remove(ogretmenSinif);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgretmenSinifExists(int id)
        {
            return _context.OgretmenSinifs.Any(e => e.Id == id);
        }
    }
}
