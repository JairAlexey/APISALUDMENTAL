using APIWEBINFO.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIWEBINFO.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWEBINFO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LinksController : ControllerBase
    {

        private readonly ApplicationDBContext _db; //Declaracion / Solo lectura / Cuando un atributo es privado se le pone "_" (No es necesario)

        public LinksController(ApplicationDBContext db) //Inyeccion de dependecia
        {
            _db = db; 
        }


        // GET: api/<LinksController> //MOSTRAR INFROMACION / LISTAR
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Link> links = await _db.Links.ToListAsync();
            return Ok(links);
        }

        // GET api/<LinksController>/5 //MOSTRAR INFORMACION POR ID
        [HttpGet("{IdLink}")] //Para que todo cuadre
        public async Task<IActionResult> Get(int IdLink)   //el landa es cuando nos vamos en contra del arreglo
        {
            Link links = await _db.Links.FirstOrDefaultAsync(x => x.IdLink == IdLink) ; //FirstOrDefaultAsync le manda el primero o manda un dato orDefault vacio, busca un arreglo
            if (links != null) {
                return Ok(links);
            }
            return BadRequest();//Indica que la solucitud de un cliente no se pudo completar. En este caso no se encontro ningun Usuario con el idUsuario proporcionado

        }

        // POST api/<LinksController> //GUARDAR INFORMACION
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Link links) //Se guarda igual con un objeto
        {
            Link linkEncontrado = await _db.Links.FirstOrDefaultAsync(x => x.IdLink == links.IdLink); //Primero buscamos si ya existe un USUARIO con ese ID
            if (linkEncontrado == null && links != null) //Si no hay un usuario con el mismo ID y es diferente de nul, se guarda
            {
                await _db.Links.AddAsync(links);//Proceso para guardado
                await _db.SaveChangesAsync();
                return Ok(links);
            }

            //**linkEncontrado** es una variable local por ello solo se encuentra en el metodo que se la declara

            return BadRequest("No se pudo crear el link");
        }



        // PUT api/<LinksController>/5 //Actualizar
        [HttpPut("{IdLink}")]
        public async Task<IActionResult> Put(int IdLink, [FromBody] Link links) //PUT, POST Y DELETE se lleva los datos en la URL como parametros, FromDody los datos se mandan los datos en el cuerpo del mensaje.
        {
            Link linkEncontrado = await _db.Links.FirstOrDefaultAsync(x => x.IdLink == IdLink); //Primero buscamos si ya existe un USUARIO con ese ID
            if (linkEncontrado != null)
            {
                linkEncontrado.linkVideo = links.linkVideo != null ? links.linkVideo : linkEncontrado.linkVideo;
                _db.Links.Update(linkEncontrado);
                await _db.SaveChangesAsync();
                return Ok(linkEncontrado);
            }
            return BadRequest();
        }



        // DELETE api/<LinksController>/5 //Eliminar
        [HttpDelete("{IdLink}")]
        public async Task<IActionResult> Delete(int IdLink)
        {
            Link links = await _db.Links.FirstOrDefaultAsync(x => x.IdLink == IdLink); //Primero buscamos si ya existe un USUARIO con ese ID
            if (links != null)
            {
                _db.Links.Remove(links);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return BadRequest("No se encontró ningun link con el Id especificado."); // Se agrega el 'return' para devolver un resultado en caso de que la condición no se cumpla.
            }
        }

    }
}
