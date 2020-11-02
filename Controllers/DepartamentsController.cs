using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CTPapuci.Models;
using CTPapuci.Models.Data;

namespace CTPapuci.Controllers
{
    public class DepartamentsController : Controller
    {
        private readonly CTPapuciContext _context;

        public DepartamentsController(CTPapuciContext context)
        {
            _context = context;
        }

        // GET: Departaments
        public async Task<IActionResult> Index()
        {
            var cTPapuciContext = _context.Departamente
                .Include(d => d.Magazin);
            return View(await cTPapuciContext.ToListAsync());
        }

        // GET: Departaments/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departament = await _context.Departamente
                .Include(d => d.Magazin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        // GET: Departaments/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Magazine, "Id", "Nume");
            return View();
        }

        // POST: Departaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cod,Nume,IdMagazin")] Departament departament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Magazine, "Id", "Nume", departament.IdMagazin);
            return View(departament);
        }

        // GET: Departaments/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departament = await _context.Departamente.FindAsync(id);
            if (departament == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Magazine, "Id", "Nume", departament.Id);
            return View(departament);
        }

        // POST: Departaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Cod,Nume,IdMagazin")] Departament departament)
        {
            if (id != departament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentExists(departament.Id))
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
            ViewData["Id"] = new SelectList(_context.Magazine, "Id", "Locatie", departament.Id);
            return View(departament);
        }

        // GET: Departaments/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departament = await _context.Departamente
                .Include(d => d.Magazin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        // POST: Departaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var departament = await _context.Departamente.FindAsync(id);
            _context.Departamente.Remove(departament);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Departaments/ListareAngajati/5
        public async Task<IActionResult> ListareAngajati(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departament = await _context.Departamente
                .Include(d => d.Angajati)
                .ThenInclude(a => a.Functie)
                .FirstOrDefaultAsync(m => m.Id == id);
           
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        private bool DepartamentExists(long id)
        {
            return _context.Departamente.Any(e => e.Id == id);
        }
    }
}
