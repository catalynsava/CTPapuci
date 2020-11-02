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
//    public class ComandaController : Controller
//    {
//        private readonly CTPapuciContext _context;

//        public ComandaController(CTPapuciContext context)
//        {
//            _context = context;
//        }

//        // GET: Comandas
//        public async Task<IActionResult> Index()
//        {
//            var comenzi = _context.Comenzi.Include(c => c.StocProdus)
//                .Include(c => c.Client)
//                .AsNoTracking();
//            return View(await comenzi.ToListAsync());
//        }

//        // GET: Comandas/Details/5
//        public async Task<IActionResult> Details(long? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var comanda = await _context.Comenzi.Include(c => c.StocProdus)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (comanda == null)
//            {
//                return NotFound();
//            }

//            return View(comanda);
//        }

//        // GET: Comandas/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Comandas/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Cantitate,Data_Comanda,Data_Livrare")] Comanda comanda)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(comanda);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(comanda);
//        }

//        // GET: Comandas/Edit/5
//        public async Task<IActionResult> Edit(long? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var comanda = await _context.Comenzi.Include(c => c.StocProdus).FirstOrDefaultAsync(c => c.Id == id);
//            if (comanda == null)
//            {
//                return NotFound();
//            }
//            return View(comanda);
//        }

//        // POST: Comandas/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost, ActionName("Edit")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> EditPost(long? id)
//        {
//            if (id != comanda.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(comanda);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ComandaExists(comanda.Id))
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
//            return View(comanda);
//        }

//        // GET: Comandas/Delete/5
//        public async Task<IActionResult> Delete(long? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var comanda = await _context.Comenzi
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (comanda == null)
//            {
//                return NotFound();
//            }

//            return View(comanda);
//        }

//        // POST: Comandas/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(long id)
//        {
//            var comanda = await _context.Comenzi.FindAsync(id);
//            _context.Comenzi.Remove(comanda);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ComandaExists(long id)
//        {
//            return _context.Comenzi.Any(e => e.Id == id);
//        }
//    }
//}
