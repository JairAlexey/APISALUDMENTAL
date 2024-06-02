using Microsoft.AspNetCore.Mvc;
using WebApplicationSaludMental.Models;
using WebApplicationSaludMental.Services;
using WebApplicationSaludMental.Helpers;
using static System.Net.Mime.MediaTypeNames;


namespace WebApplicationSaludMental.Controllers
{
    public class CapacitacionesController : Controller
    {

        // Dependencia para comunicarse con la API.
        private readonly IApiService _apiService;
        private readonly IFilesHelper _filesHelper;

        public CapacitacionesController(IApiService apiService, IFilesHelper filesHelper)
        {
            _apiService = apiService;
            _filesHelper = filesHelper;
        }

        // GET: CapacitacionesController  
        public async Task<IActionResult> Index()
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

        // GET: MedicoController/Details/5 //ListarDatos
        public async Task<ActionResult> Details(int IdCapacitaciones)
        {
            var capacitaciones = await _apiService.getCapacitaciones(IdCapacitaciones);
            if (capacitaciones != null)
            {
                return View(capacitaciones);
            }
            return RedirectToAction("Index");
        }

        // GET: MedicoController/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: CapacitacionesController/UploadImage
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile Imagen)
        {
            if (Imagen != null && ModelState.IsValid)
            {
                Stream image = Imagen.OpenReadStream();
                string urlImagen = await _filesHelper.SubirArchivo(image, Imagen.FileName);

                // Retorna un JSON con el resultado
                return Json(new { success = true, url = urlImagen });
            }
            return Json(new { success = false, message = "Invalid file or model state." });
        }



        // POST: MedicoController/Create //Crear Nuevo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Capacitaciones capacitaciones, IFormFile Imagen)
        {
            if (ModelState.IsValid)
            {

                Stream image = Imagen.OpenReadStream();
                //llamamos a nuestra interfaz para subir el archivo
                string urlimagen = await _filesHelper.SubirArchivo(image, Imagen.FileName);

                try
                {

                    //agregamos la url que nos devolvio el metodo SubirArchivo, a nuestro objeto pelicula.
                    capacitaciones.URLImagen = urlimagen;
                    //agregamos el objeto en base de datos	
                    _apiService.addCapacitaciones(capacitaciones);
                    //guardamos los cambios	
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception exception)
                {
                    ViewBag.Error(exception.Message);
                }
            }
            return View(capacitaciones);
        }


        // GET: MedicoController/Edit/5
        public async Task<IActionResult> Edit(int IdCapacitaciones)
        {
            var capacitaciones = await _apiService.getCapacitaciones(IdCapacitaciones);
            if (capacitaciones != null)
            {
                return View(capacitaciones);
            }
            return RedirectToAction("Index");
        }

        // POST: MedicoController/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Capacitaciones capacitaciones)
        {
            var pAEditar = await _apiService.updateCapacitaciones(capacitaciones.IdCapacitaciones, capacitaciones);
            if (pAEditar != null)
            {
                return RedirectToAction(nameof(Index)); //Nameof se utiliza para obtener el nombre de una variable, tipo o miembro de una clase como una cadena en tiempo de compilación. 
            }
            return View(pAEditar);
        }


        // GET: MedicoController/Delete/5 //Eliminar
        public ActionResult Delete(int IdCapacitaciones)
        {
            var pEliminar = _apiService.deleteCapacitaciones(IdCapacitaciones);
            return RedirectToAction(nameof(Index));

        }
    }
}
