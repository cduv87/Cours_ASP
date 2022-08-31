using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TpDojo.Business;
using TpDojo.DAL;
using TpDojo.DAL.Models;
using TpDojo.WEB.Models;

namespace TpDojo.WEB.Controllers
{
    public class ArmesController : Controller
    {
        private readonly ArmeService armeService;

        public ArmesController(ArmeService armeService)
        {
            this.armeService = armeService;
            
        }

        // GET: Armes
        public async Task<IActionResult> Index()
        {
            var ArmesDTO = await armeService.GetArmesAsync();
            
            return ArmesDTO != null ?
                          View(ArmeViewModel.FromArmessDTO(ArmesDTO)) :
                          Problem("Armes is null.");
        }

        // GET: Armes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var arme = await armeService.GetArmeByIdAsync(id);
            if (arme == null)
            {
                return this.NotFound();
            }

            return this.View(ArmeViewModel.FromArmeDTO(arme));
        }

        // GET: Armes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Armes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArmeViewModel arme)
        {
            if (ModelState.IsValid)
            {
                var armeDto = ArmeViewModel.ToArmeDto(arme);
                await armeService.AddArmeAsync(armeDto);
                
                return RedirectToAction(nameof(Index));
            }
            return View(arme);
        }

 /*       // GET: Armes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Arme == null)
            {
                return NotFound();
            }

            var arme = await _context.Arme.FindAsync(id);
            if (arme == null)
            {
                return NotFound();
            }
            return View(arme);
        }

        // POST: Armes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Degats")] ArmeEntity arme)
        {
            if (id != arme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmeExists(arme.Id))
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
            return View(arme);
        }*/

        // GET: Armes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var arme = await this.armeService.GetArmeByIdAsync(id);
            if (arme == null)
            {
                return this.NotFound();
            }

            return this.View(ArmeViewModel.FromArmeDTO(arme));
        }

        // POST: Armes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.armeService.RemoveArmeAsync(id);
            return this.RedirectToAction(nameof(Index));
        }

        private async Task<bool> ArmeExists(int id)
        {
            return await this.armeService.ArmeExistsAsync(id);
        }
    }
}
