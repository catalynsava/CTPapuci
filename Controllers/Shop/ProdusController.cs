//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using CTPapuci.Models;
//using CTPapuci.Models.Data;

//namespace CTPapuci.Controllers
//{
//    public class ProdusController : Controller
//    {
//        private readonly CTPapuciContext _context;

//        public ProdusController(CTPapuciContext context)
//        {
//            _context = context;
//        }

//        // GET: Produs
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Produse.ToListAsync());
//        }

//        // GET: Produs/Details/5
//        public async Task<IActionResult> Details(long? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var produs = await _context.Produse
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (produs == null)
//            {
//                return NotFound();
//            }

//            return View(produs);
//        }

//        // GET: Produs/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Produs/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Cod,Nume,Pret")] Produs produs)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(produs);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(produs);
//        }

//        // GET: Produs/Edit/5
//        public async Task<IActionResult> Edit(long? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var produs = await _context.Produse.FindAsync(id);
//            if (produs == null)
//            {
//                return NotFound();
//            }
//            return View(produs);
//        }

//        // POST: Produs/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(long id, [Bind("Id,Cod,Nume,Pret")] Produs produs)
//        {
//            if (id != produs.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(produs);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ProdusExists(produs.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(produs);
//        }

//        private void GasesteStocuri(object selectedProduct = null)
//        {
//            var stocuri = from s in _context.Stocuri
//                          orderby s.Id
//                          select s;
//            ViewBag.StocId = new SelectList(stocuri.AsNoTracking());
//        }

//        // GET: Produs/Delete/5
//        public async Task<IActionResult> Delete(long? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var produs = await _context.Produse
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (produs == null)
//            {
//                return NotFound();
//            }

//            return View(produs);
//        }

//        // POST: Produs/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(long id)
//        {
//            var produs = await _context.Produse.FindAsync(id);
//            _context.Produse.Remove(produs);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ProdusExists(long id)
//        {
//            return _context.Produse.Any(e => e.Id == id);
//        }
//    }
//}
