using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSaludMental.Models;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using WebApplicationSaludMental.Services;


namespace WebApplicationSaludMental.Controllers
{
    public class ReservacionController : Controller
    {

        // Dependencia para comunicarse con la API.
        private readonly IApiService _apiService;

        public ReservacionController(IApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: LinkController  
        public async Task<IActionResult> Index()
        {
            try
            {
                var reservaciones = await _apiService.getReservacion();
                return View(reservaciones);
            }
            catch (Exception e)
            {
                return View(new List<Reservacion>());
            }
        }

        // GET: LinkController/Details/5 //ListarDatos
        public async Task<ActionResult> Details(int IdReservacion)
        {
            var reservaciones = await _apiService.getReservacion(IdReservacion);
            if (reservaciones != null)
            {
                return View(reservaciones);
            }
            return RedirectToAction("Index");
        }

        // GET: LinkController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LinkController/Create //Crear Nuevo
        [HttpPost]
        public async Task<IActionResult> Create(Reservacion reservaciones)
        {
            var result = await _apiService.addReservacion(reservaciones);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(reservaciones);
        }

        // GET: LinkController/Edit/5
        public async Task<IActionResult> Edit(int IdReservacion)
        {
            var reservaciones = await _apiService.getReservacion(IdReservacion);
            if (reservaciones != null)
            {
                return View(reservaciones);
            }
            return RedirectToAction("Index");
        }

        // POST: LinkController/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Reservacion reservaciones)
        {
            var pAEditar = await _apiService.updateReservacion(reservaciones.IdReservacion, reservaciones);
            if (pAEditar != null)
            {
                return RedirectToAction(nameof(Index)); //Nameof se utiliza para obtener el nombre de una variable, tipo o miembro de una clase como una cadena en tiempo de compilación. 
            }
            return View(pAEditar);
        }


        // GET: LinkController/Delete/5 //Eliminar
        public ActionResult Delete(int IdReservacion)
        {
            var pEliminar = _apiService.deleteReservacion(IdReservacion);
            return RedirectToAction(nameof(Index));

        }

    }
}
