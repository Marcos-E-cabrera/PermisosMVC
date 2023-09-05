using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProyectoRol.Models.DB;
using ProyectoRol.Models.Services;
using System.Data;
using System.Security.Claims;

namespace ProyectoRol.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IAcceso _context;

        public AccesoController(IAcceso cotext)
        {
            _context = cotext;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {
            var usuario = _context.ValidarUsuario(_usuario.Email, _usuario.Password);

            if (usuario == null)
            {
                ViewBag.Error = "Usuario o Password Incorrecto";
                return View();
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim("Email", usuario.Email),
            };

            claims.Add(new Claim(ClaimTypes.Role, usuario.IdRol.ToString()));

            var claimsIndentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIndentity));

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
