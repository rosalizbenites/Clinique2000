using Clinique2000_DataAccess.Data;
using Clinique2000_Models.Models;
using Clinique2000_Models.ViewModels;
using Clinique2000_Services.Services;
using Clinique2000_Services.Services.IServices;
using Clinique2000_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace Clinique2000_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constants.AdminRole)]
    public class CliniquesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CliniquesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Cliniques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _unitOfWork.DbContext.Cliniques == null)
            {
                return NotFound();
            }

            var clinique = await _unitOfWork.DbContext.Cliniques
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinique == null)
            {
                return NotFound();
            }

            return View(clinique);
        }

        // POST: Cliniques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.DbContext.Cliniques == null)
            {
                return Problem("Entity set 'Clinique2000DbContext.Cliniques'  is null.");
            }
            var clinique = await _unitOfWork.DbContext.Cliniques.FindAsync(id);
            if (clinique != null)
            {
                _unitOfWork.DbContext.Cliniques.Remove(clinique);
            }

            await _unitOfWork.DbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
