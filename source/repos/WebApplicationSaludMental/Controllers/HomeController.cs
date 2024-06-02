using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationSaludMental.Models;
using WebApplicationSaludMental.Services;

namespace WebApplicationSaludMental.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;

        public HomeController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public ActionResult Entrada()
        {
            return View();
        }

        public ActionResult Ayuda()
        {
            return View();
        }
        public ActionResult Llamanos()
        {
            return View();
        }
        public ActionResult Nosotros()
        {
            return View();
        }

        public ActionResult IndexBullying()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Legal()
        {
            return View();
        }
        public ActionResult Juegos()
        {
            return View();
        }

        public ActionResult AcosoIndex()
        {
            return View();
        }
        public ActionResult TrastornoIndex()
        {
            return View();
        }

        public ActionResult Preventiva()
        {
            return View();
        }

        public ActionResult Durante()
        {
            return View();
        }

        public ActionResult Despues()
        {
            return View();
        }

        public ActionResult Seguridad()
        {
            return View();
        }

        public ActionResult Psicologia()
        {
            return View();
        }

        public ActionResult Curar()
        {
            return View();
        }

        public ActionResult Metodos()
        {
            return View();
        }

        public ActionResult Identificar()
        {
            return View();
        }

        public ActionResult App()
        {
            return View();
        }

        public ActionResult Tipos()
        {
            return View();
        }

        public ActionResult Alerta()
        {
            return View();
        }

        public ActionResult Aplicacion()
        {
            return View();
        }

        public ActionResult Libros()
        {
            return View();
        }

        public ActionResult Ninos()
        {
            return View();
        }

        public ActionResult Jovenes()
        {
            return View();
        }

        public ActionResult Otros()
        {
            return View();
        }
        public ActionResult MiedoInseguridadesNinos()
        {
            return View();
        }

        public ActionResult MiedoInseguridadesJovenes()
        {
            return View();
        }

        public ActionResult EstadoAnimoJovenes()
        {
            return View();
        }

        public ActionResult EstadoAnimoNinos()
        {
            return View();
        }
        public ActionResult FelicidadNinos()
        {
            return View();
        }
        public ActionResult FelicidadJovenes()
        {
            return View();
        }
        public ActionResult ResponsabilidadNinos()
        {
            return View();
        }
        public ActionResult ResponsabilidadJovenes()
        {
            return View();
        }

        public IActionResult TerminosCondiciones()
        {
            return View();
        }

        public IActionResult PoliticasPrivacidad()
        {
            return View();
        }

        public async Task<IActionResult> PaginaInicio()
        {
            try
            {
                var links = await _apiService.getLink();
                return View(links);
            }
            catch (Exception e)
            {
                return View(new List<Link>());
            }
        }

        // GET: Create
        public ActionResult Reservacion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.IdCapacitacion = id;
            return View();
        }


        // POST: LinkController/Create //Crear Nuevo
        [HttpPost]
        public async Task<IActionResult> Reservacion(Reservacion reservaciones)
        {
            var result = await _apiService.addReservacion(reservaciones);
            if (result)
            {
                return RedirectToAction("PaginaInicio", "Home");
            }
            return View(reservaciones);
        }


        // GET: Create
        public IActionResult Contactanos()
        {
            return View();
        }

        // POST: MensajeController/Create //Crear Nuevo
        [HttpPost]
        public async Task<IActionResult> Contactanos(Mensaje mensajes)
        {
            var result = await _apiService.addMensaje(mensajes);
            if (result)
            {
                return RedirectToAction("PaginaInicio", "Home");
            }
            return View(mensajes);
        }

        // GET: Create
        public IActionResult Formulario()
        {
            return View();
        }


        // POST: MensajeController/Create //Crear Nuevo
        [HttpPost]
        public async Task<IActionResult> Formulario(Formulario formularios)
        {
            var result = await _apiService.addFormulario(formularios);
            if (result)
            {
                return RedirectToAction("PaginaInicio", "Home");
            }
            return View(formularios);
        }

        // Visualizar capacitaciones 
        public async Task<IActionResult> Capacitaciones()
        {
            try
            {
                var capacitaciones = await _apiService.getCapacitaciones();
                return View(capacitaciones);
            }
            catch (Exception e)
            {
                return View(new List<Capacitaciones>());
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
