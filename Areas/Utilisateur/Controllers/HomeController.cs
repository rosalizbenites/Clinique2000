using Clinique2000_Models.Models;
using Clinique2000_Services.Services;
using Clinique2000_Services.Services.IServices;
using Clinique2000_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Clinique2000_Web.Areas.Utilisateur.Controllers
{
    [Area("Utilisateur")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}