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
    public class MensajeController : Controller
    {

        // Dependencia para comunicarse con la API.
        private readonly IApiService _apiService;

        public MensajeController(IApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: MensajeController  
        public async Task<IActionResult> Index()
        {
            try
            {
                var mensajes = await _apiService.getMensaje();
                return View(mensajes);
            }
            catch (Exception e)
            {
                return View(new List<Mensaje>());
            }
        }

        // GET: MensajeController/Details/5 //ListarDatos
        public async Task<ActionResult> Details(int IdMensaje)
        {
            var mensajes = await _apiService.getMensaje(IdMensaje);
            if (mensajes != null)
            {
                return View(mensajes);
            }
            return RedirectToAction("Index");
        }

        // GET: MensajeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MensajeController/Create //Crear Nuevo
        [HttpPost]
        public async Task<IActionResult> Create(Mensaje mensajes)
        {
            var result = await _apiService.addMensaje(mensajes);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(mensajes);
        }

        // GET: MensajeController/Edit/5
        public async Task<IActionResult> Edit(int IdMensaje)
        {
            var mensajes = await _apiService.getMensaje(IdMensaje);
            if (mensajes != null)
            {
                return View(mensajes);
            }
            return RedirectToAction("Index");
        }

        // POST: MensajeController/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Mensaje mensajes)
        {
            var pAEditar = await _apiService.updateMensaje(mensajes.IdMensaje, mensajes);
            if (pAEditar != null)
            {
                return RedirectToAction(nameof(Index)); //Nameof se utiliza para obtener el nombre de una variable, tipo o miembro de una clase como una cadena en tiempo de compilación. 
            }
            return View(pAEditar);
        }


        // GET: MensajeController/Delete/5 //Eliminar
        public ActionResult Delete(int IdMensaje)
        {
            var pEliminar = _apiService.deleteMensaje(IdMensaje);
            return RedirectToAction(nameof(Index));

        }
    }
}
