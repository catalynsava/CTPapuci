using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CTPapuci.Models;
using CTPapuci.Models.Data;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CTPapuci.Controllers
{
    public class AngajatsController : Controller
    {
        private readonly CTPapuciContext _context;

        public AngajatsController(CTPapuciContext context)
        {
            _context = context;
        }

        // GET: Angajats
        public async Task<IActionResult> Index()
        {
            var context = _context.Angajati
                .Include(a => a.Departament)
                .Include(a => a.Functie);
            return View(await context.ToListAsync());
        }

        // GET: Angajats/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajat = await _context.Angajati
                .Include(a => a.Departament)
                .Include(a => a.Functie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (angajat == null)
            {
                return NotFound();
            }

            return View(angajat);
        }

        // GET: Angajats/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Departamente, "Id", "Nume");
            ViewData["Id"] = new SelectList(_context.Functii, "Id", "Nume");
            PopulateFunctiiDropDownList(null);
            PopulateDepartamenteDropDownList(null);
            return View();
        }

        // POST: Angajats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Nume,Salariu,IdFunctie,IdDepartament")] Angajat angajat)
        {

            
            //ViewData["Id"] = new SelectList(_context.Functii, "Id", "Id", angajat.Id);
            //Console.WriteLine("BUNA");
            
            if (ModelState.IsValid)
            {
                _context.Add(angajat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdFunctie"] = new SelectList(_context.Functii, "Id", "Nume", angajat.Functie.Nume);
            //ViewData["IdDepartament"] = new SelectList(_context.Departamente, "Id", "Nume", angajat.Departament.Nume);
            PopulateFunctiiDropDownList(angajat.IdFunctie);
            PopulateDepartamenteDropDownList(angajat.IdDepartament);
            return View(angajat);
        }

        // GET: Angajats/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajat = await _context.Angajati
                .Include(a=> a.Departament)
                .Include(a => a.Functie)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (angajat == null)
            {
                return NotFound();
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departamente, "Id", "Nume", angajat.IdDepartament);
            ViewData["IdFunctie"] = new SelectList(_context.Functii, "Id", "Nume", angajat.Id);
            //PopulateFunctiiDropDownList(angajat.IdFunctie);
            //PopulateDepartamenteDropDownList(angajat.IdDepartament);
            return View(angajat);
        }

        // POST: Angajats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Marca,Nume,Salariu,IdFunctie,IdDepartament")] Angajat angajat)
        {
            if (id != angajat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(angajat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AngajatExists(angajat.Id))
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
            ViewData["IdDepartament"] = new SelectList(_context.Departamente, "Id", "Nume", angajat.IdDepartament);
            ViewData["IdFunctie"] = new SelectList(_context.Functii, "Id", "Nume", angajat.IdFunctie);
            //PopulateFunctiiDropDownList(angajat.IdFunctie);
            //PopulateDepartamenteDropDownList(angajat.IdDepartament);
            return View(angajat);
        }

        // GET: Angajats/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajat = await _context.Angajati
                .Include(a => a.Departament)
                .Include(a => a.Functie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (angajat == null)
            {
                return NotFound();
            }

            return View(angajat);
        }

        // POST: Angajats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var angajat = await _context.Angajati.FindAsync(id);
            _context.Angajati.Remove(angajat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AngajatExists(long id)
        {
            return _context.Angajati.Any(e => e.Id == id);
        }


        public void PopulateFunctiiDropDownList(object selected)
        {
            
            var fQ = _context.Functii.OrderBy(f => f.Nume);

            ViewBag.IdFunctie = new SelectList(fQ, "Id", "Nume", selected);
        }

        public void PopulateDepartamenteDropDownList(object selected)
        {
            var dQ = _context.Departamente.OrderBy(d => d.Nume);

            ViewBag.IdDepartament = new SelectList(dQ, "Id", "Nume", selected);
        }

    }
}
