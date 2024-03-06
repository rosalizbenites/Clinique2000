using Clinique2000_DataAccess.Data;
using Clinique2000_Models.Models;
using Clinique2000_Services.Services;
using Clinique2000_Services.Services.IServices;
using Clinique2000_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Clinique2000_Web.Areas.CliniqueAdmin.Controllers
{
    [Area("CliniqueAdmin")]
    [Authorize(Roles = Constants.CliniqueAdminRole + "," + Constants.AdminRole)]
    public class FileDAttentesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FileDAttentesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        // GET: FileDAttentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _unitOfWork.DbContext.FilesDAttente == null)
            {
                return NotFound();
            }

            var fileDAttente = await _unitOfWork.DbContext.FilesDAttente
                .Include(f => f.Clinique)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileDAttente == null)
            {
                return NotFound();
            }

            return View(fileDAttente);
        }

        // GET: FileDAttentes/Create
        public IActionResult Create(int? id)
        {
            ViewData["CliniqueId"] = id;
            return View();
        }

        // POST: FileDAttentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? cliniqueId, FileDAttente fileDAttente)
        {
            //fileDAttente.CliniqueId = _unitOfWork.Contexte.CliniqueCouranteId;
            //fileDAttente.PlageHoraires = new List<PlageHoraire>();
            //PlageHoraire p1 = new PlageHoraire { Debut = new TimeSpan(12, 0, 0) };
            //fileDAttente.PlageHoraires.Add(p1);

            fileDAttente = await _unitOfWork.PlageHoraire.CreerPlagesHoraires(fileDAttente);

            if (ModelState.IsValid)
            {
                await _unitOfWork.FileDAttente.CreateAsync(fileDAttente);
                return RedirectToAction("GestionFiles", "Cliniques", new { id = fileDAttente.CliniqueId });
            }
            return View();
        }

        // GET: FileDAttentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _unitOfWork.DbContext.FilesDAttente == null)
            {
                return NotFound();
            }

            var fileDAttente = await _unitOfWork.DbContext.FilesDAttente.FindAsync(id);

            if (fileDAttente == null)
            {
                return NotFound();
            }
            //ViewData["CliniqueId"] = new SelectList(_context.Cliniques, "Id", "Adresse", fileDAttente.CliniqueId);
            return View(fileDAttente);
        }

        // POST: FileDAttentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FileDAttente fileDAttente)
        {
            if (id != fileDAttente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.FileDAttente.EditAsync(fileDAttente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileDAttenteExists(fileDAttente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("GestionCliniques", "Cliniques", new { id = fileDAttente.CliniqueId });
            }
            //ViewData["CliniqueId"] = new SelectList(_context.Cliniques, "Id", "Adresse", fileDAttente.CliniqueId);
            return View(fileDAttente);
        }

        // POST: FileDAttentes/FermetureManuelle/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FermetureManuelle(int id)
        {
            FileDAttente file = await _unitOfWork.FileDAttente.GetByIdAsync(id);
            if (id != file.Id)
            {
                return NotFound();
            }

            if (file != null)
            {
                file.EstFermeeManuellement = !file.EstFermeeManuellement;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.FileDAttente.EditAsync(file);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileDAttenteExists(file.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction("Gestion", "Cliniques", new { id = fileDAttente.CliniqueId });
                return RedirectToAction("Edit", "FileDAttentes", new { id = file.Id });
            }
            return RedirectToAction("Edit", "FileDAttentes", new { id = file.Id });
        }

        // GET: FileDAttentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _unitOfWork.DbContext.FilesDAttente == null)
            {
                return NotFound();
            }

            var fileDAttente = await _unitOfWork.DbContext.FilesDAttente
                .Include(f => f.Clinique)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileDAttente == null)
            {
                return NotFound();
            }

            return View(fileDAttente);
        }

        // POST: FileDAttentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.DbContext.FilesDAttente == null)
            {
                return Problem("Entity set 'CliniqueDbContext.FilesDAttente'  is null.");
            }
            var fileDAttente = await _unitOfWork.DbContext.FilesDAttente.FindAsync(id);
            if (fileDAttente != null)
            {
                _unitOfWork.DbContext.FilesDAttente.Remove(fileDAttente);
            }

            await _unitOfWork.DbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileDAttenteExists(int id)
        {
            return (_unitOfWork.DbContext.FilesDAttente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
