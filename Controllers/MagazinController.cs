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
    public class MagazinController : Controller
    {
        private readonly CTPapuciContext _context;

        public MagazinController(CTPapuciContext context)
        {
            _context = context;
        }

        // GET: Magazin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Magazine.ToListAsync());
        }

        // GET: Magazin/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazin = await _context.Magazine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magazin == null)
            {
                return NotFound();
            }

            return View(magazin);
        }

        // GET: Magazin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Magazin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cod,Nume,Locatie")] Magazin magazin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(magazin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(magazin);
        }


        // GET: Magazin/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazin = await _context.Magazine.FindAsync(id);
            if (magazin == null)
            {
                return NotFound();
            }
            return View(magazin);
        }

        // POST: Magazin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Cod,Nume,Locatie")] Magazin magazin)
        {
            if (id != magazin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(magazin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MagazinExists(magazin.Id))
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
            return View(magazin);
        }

        // GET: Magazin/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazin = await _context.Magazine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magazin == null)
            {
                return NotFound();
            }

            return View(magazin);
        }

        // POST: Magazin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var magazin = await _context.Magazine.FindAsync(id);
            _context.Magazine.Remove(magazin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MagazinExists(long id)
        {
            return _context.Magazine.Any(e => e.Id == id);
        }




        public IActionResult AddDepartment()
        {
            return View();
        }

        // POST: Magazin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDepartment([Bind("Id")] Departament departament, Magazin magazin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(magazin);
        }




    }
}
