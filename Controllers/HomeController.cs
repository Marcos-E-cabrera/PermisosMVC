using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoRol.Models;
using System.Diagnostics;

namespace ProyectoRol.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "1,2,4")]
        public IActionResult Listar()
        {
            return View();
        }

        [Authorize(Roles = "1,2,3,4")]
        public IActionResult Editar()
        {
            return View();
        }

        [Authorize(Roles = "1,2,4")]
        public IActionResult Crear()
        {
            return View();
        }

        [Authorize(Roles = "1,4")]
        public IActionResult Eliminar()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}