using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TpDojo.DAL;
using TpDojo.DAL.Models;
using TpDojo.Business;
using TpDojo.WEB.Models;

namespace TpDojo.WEB.Controllers
{
    public class SamouraisController : Controller
    {
        private readonly SamouraiService samouraiService;

        public SamouraisController(SamouraiService samouraiService)
        {
            this.samouraiService = samouraiService;
        }

        // GET: Samourais
        public async Task<IActionResult> Index()
        {   var samouraisDTO = await samouraiService.GetSamouraisAsync();
            return View(SamouraiViewModel.FromSamouraisDTO(samouraisDTO));
        }

        // GET: Samourais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var samourai = await this.samouraiService.GetSamouraiByIdAsync(id);
            if (samourai == null)
            {
                return this.NotFound();
            }

            return this.View(SamouraiViewModel.FromSamouraiDTO(samourai));
        }

        // GET: Samourais/Create
        public IActionResult Create()
        {
            return View();
        }

/*        // POST: Samourais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Force,Nom")] ArmeEntity samourai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(samourai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(samourai);
        }*/
/*
        // GET: Samourais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Samourai == null)
            {
                return NotFound();
            }

            var samourai = await _context.Samourai.FindAsync(id);
            if (samourai == null)
            {
                return NotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Force,Nom")] SamouraiEntity samourai)
        {
            if (id != samourai.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(samourai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamouraiExists(samourai.Id))
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
            return View(samourai);
        }

        // GET: Samourais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Samourai == null)
            {
                return NotFound();
            }

            var samourai = await _context.Samourai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (samourai == null)
            {
                return NotFound();
            }

            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Samourai == null)
            {
                return Problem("Entity set 'TpDojoWEBContext.Samourai'  is null.");
            }
            var samourai = await _context.Samourai.FindAsync(id);
            if (samourai != null)
            {
                _context.Samourai.Remove(samourai);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SamouraiExists(int id)
        {
            return (_context.Samourai?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
