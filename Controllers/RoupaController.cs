using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Loja.Data;
using Loja.Models;
using System;

namespace Loja.Controllers
{
    public class RoupaController : Controller
    {
        private readonly LojaContext _context;

        public RoupaController(LojaContext context)
        {
            _context = context;
        }

        // GET: Roupa
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roupa.ToListAsync());
        }

        // GET: Roupa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roupa = await _context.Roupa
                .FirstOrDefaultAsync(m => m.RoupaId == id);
            if (roupa == null)
            {
                return NotFound();
            }

            return View(roupa);
        }

        // GET: Roupa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roupa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoupaId,Nome,Quantidade")] Roupa roupa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roupa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roupa);
        }
        public async Task<IActionResult> Pedir([Bind("RoupaId,Nome,Quantidade")] Roupa roupa)
        {
                Pedido pedido = new Pedido(roupa);
                _context.Update(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }
        // GET: Roupa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roupa = await _context.Roupa.FindAsync(id);
            if (roupa == null)
            {
                return NotFound();
            }
            return View(roupa);
        }

        // POST: Roupa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoupaId,Nome,Quantidade")] Roupa roupa)
        {
            if (id != roupa.RoupaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roupa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoupaExists(roupa.RoupaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if(roupa.Quantidade == 0)
                {
                    return RedirectToAction("Pedir", roupa);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(roupa);
        }

        // GET: Roupa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roupa = await _context.Roupa
                .FirstOrDefaultAsync(m => m.RoupaId == id);
            if (roupa == null)
            {
                return NotFound();
            }

            return View(roupa);
        }

        // POST: Roupa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roupa = await _context.Roupa.FindAsync(id);
            _context.Roupa.Remove(roupa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoupaExists(int id)
        {
            return _context.Roupa.Any(e => e.RoupaId == id);
        }
    }
}
