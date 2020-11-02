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
    public class FunctiiController : Controller
    {
        private readonly CTPapuciContext _context;

        public FunctiiController(CTPapuciContext context)
        {
            _context = context;
        }

        // GET: Functii
        public async Task<IActionResult> Index()
        {
            return View(await _context.Functii.ToListAsync());
        }

        // GET: Functii/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functie = await _context.Functii
                .FirstOrDefaultAsync(m => m.Id == id);
            if (functie == null)
            {
                return NotFound();
            }

            return View(functie);
        }

        // GET: Functii/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Functii/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Descriere")] Functie functie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(functie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(functie);
        }

        // GET: Functii/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functie = await _context.Functii.FindAsync(id);
            if (functie == null)
            {
                return NotFound();
            }
            return View(functie);
        }

        // POST: Functii/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nume,Descriere")] Functie functie)
        {
            if (id != functie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(functie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FunctieExists(functie.Id))
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
            return View(functie);
        }

        // GET: Functii/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functie = await _context.Functii
                .FirstOrDefaultAsync(m => m.Id == id);
            if (functie == null)
            {
                return NotFound();
            }

            return View(functie);
        }

        // POST: Functii/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var functie = await _context.Functii.FindAsync(id);
            _context.Functii.Remove(functie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FunctieExists(long id)
        {
            return _context.Functii.Any(e => e.Id == id);
        }
    }
}
