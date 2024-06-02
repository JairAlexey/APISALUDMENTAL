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
    public class LinkController : Controller
    {

        // Dependencia para comunicarse con la API.
        private readonly IApiService _apiService;

        public LinkController(IApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: LinkController  
        public async Task<IActionResult> Index()
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

        // GET: LinkController/Details/5 //ListarDatos
        public async Task<ActionResult> Details(int IdLink)
        {
            var links = await _apiService.getLink(IdLink);
            if (links != null)
            {
                return View(links);
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
        public async Task<IActionResult> Create(Link link)
        {
            // Transforma el enlace según tus requisitos
            string embedLink = TransformarLink(link.linkVideo);

            // Asigna el enlace transformado al objeto Link
            link.linkVideo = embedLink;

            // Guarda el nuevo enlace transformado en la API
            var result = await _apiService.addLink(link);

            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(link);
        }


        private string TransformarLink(string linkVideo)
        {
            // Verificar si el enlace es válido
            if (Uri.TryCreate(linkVideo, UriKind.Absolute, out Uri uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                // Obtener la parte de la consulta del enlace
                string queryString = uri.Query;

                // Verificar si el enlace tiene una consulta
                if (!string.IsNullOrEmpty(queryString))
                {
                    // Obtener el valor del parámetro 'v' de la consulta
                    var queryParameters = System.Web.HttpUtility.ParseQueryString(queryString);
                    string videoId = queryParameters.Get("v");

                    // Verificar si se encontró el ID del video en la consulta
                    if (!string.IsNullOrEmpty(videoId))
                    {
                        // Construir el nuevo enlace con el ID del video transformado
                        string embedLink = $"https://www.youtube.com/embed/{videoId}?autoplay=1&mute=1&loop=1&playlist={videoId}";
                        return embedLink;
                    }
                }
                else
                {
                    // Si el enlace no tiene una consulta, intentar obtener el ID del video de otras formas
                    // por ejemplo, a través de la ruta del enlace
                    string[] segments = uri.Segments;
                    foreach (var segment in segments)
                    {
                        if (segment.Contains("watch"))
                        {
                            string[] parts = segment.Split('=');
                            if (parts.Length > 1)
                            {
                                string videoId = parts[1];
                                // Construir el nuevo enlace con el ID del video transformado
                                string embedLink = $"https://www.youtube.com/embed/{videoId}?autoplay=1&mute=1&loop=1&playlist={videoId}";
                                return embedLink;
                            }
                        }
                    }
                }
            }

            // Si no se puede transformar el enlace, devolver el enlace original
            return "No se pudo trasformar";
        }



        // GET: LinkController/Edit/5
        public async Task<IActionResult> Edit(int IdLink)
        {
            var links = await _apiService.getLink(IdLink);
            if (links != null)
            {
                return View(links);
            }
            return RedirectToAction("Index");
        }

        // POST: LinkController/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Link links)
        {
            // Transforma el enlace según tus requisitos
            string embedLink = TransformarLink(links.linkVideo);

            // Asigna el enlace transformado al objeto Link
            links.linkVideo = embedLink;

            var pAEditar = await _apiService.updateLink(links.IdLink, links);
            if (pAEditar != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(pAEditar);
        }



        // GET: LinkController/Delete/5 //Eliminar
        public ActionResult Delete(int IdLink)
        {
            var pEliminar = _apiService.deleteLink(IdLink);
            return RedirectToAction(nameof(Index));

        }
    }
}
