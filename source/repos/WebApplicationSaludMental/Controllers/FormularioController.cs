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
    public class FormularioController : Controller
    {

        // Dependencia para comunicarse con la API.
        private readonly IApiService _apiService;

        public FormularioController(IApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: FormularioController  
        public async Task<IActionResult> Index()
        {
            try
            {
                var formularios = await _apiService.getFormulario();
                return View(formularios);
            }
            catch (Exception e)
            {
                return View(new List<Formulario>());
            }
        }

        // GET: FormularioController/Details/5 //ListarDatos
        public async Task<ActionResult> Details(int IdFormulario)
        {
            var formularios = await _apiService.getFormulario(IdFormulario);
            if (formularios != null)
            {
                return View(formularios);
            }
            return RedirectToAction("Index");
        }

        // GET: FormularioController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormularioController/Create //Crear Nuevo
        [HttpPost]
        public async Task<IActionResult> Create(Formulario formularios)
        {
            var result = await _apiService.addFormulario(formularios);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(formularios);
        }

        // GET: FormularioController/Edit/5
        public async Task<IActionResult> Edit(int IdFormulario)
        {
            var formularios = await _apiService.getFormulario(IdFormulario);
            if (formularios != null)
            {
                return View(formularios);
            }
            return RedirectToAction("Index");
        }

        // POST: FormularioController/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Formulario formularios)
        {
            var pAEditar = await _apiService.updateFormulario(formularios.IdFormulario, formularios);
            if (pAEditar != null)
            {
                return RedirectToAction(nameof(Index)); //Nameof se utiliza para obtener el nombre de una variable, tipo o miembro de una clase como una cadena en tiempo de compilación. 
            }
            return View(pAEditar);
        }


        // GET: FormularioController/Delete/5 //Eliminar
        public ActionResult Delete(int IdFormulario)
        {
            var pEliminar = _apiService.deleteFormulario(IdFormulario);
            return RedirectToAction(nameof(Index));

        }
    }
}
