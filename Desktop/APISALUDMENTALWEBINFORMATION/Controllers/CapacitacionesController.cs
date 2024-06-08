using APIWEBINFO.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIWEBINFO.Models;
using static System.Net.Mime.MediaTypeNames;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWEBINFO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CapacitacionesController : ControllerBase
    {
        private readonly ApplicationDBContext _db; //Declaracion / Solo lectura / Cuando un atributo es privado se le pone "_" (No es necesario)

        public CapacitacionesController(ApplicationDBContext db) //Inyeccion de dependecia
        {
            _db = db; 

        }


        // GET: api/<CapacitacionesController> //MOSTRAR INFROMACION / LISTAR
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Capacitaciones> capacitaciones = await _db.Capacitaciones.ToListAsync();
            return Ok(capacitaciones);
        }

        // GET api/<CapacitacionesController>/5 //MOSTRAR INFORMACION POR ID
        [HttpGet("{IdCapacitaciones}")] //Para que todo cuadre
        public async Task<IActionResult> Get(int IdCapacitaciones)   //el landa es cuando nos vamos en contra del arreglo
        {
            Capacitaciones capacitaciones = await _db.Capacitaciones.FirstOrDefaultAsync(x => x.IdCapacitaciones == IdCapacitaciones); //FirstOrDefaultAsync le manda el primero o manda un dato orDefault vacio, busca un arreglo
            if (capacitaciones != null) {
                return Ok(capacitaciones);
            }
            return BadRequest();//Indica que la solucitud de un cliente no se pudo completar. En este caso no se encontro ningun Usuario con el idUsuario proporcionado

        }

        // POST: Crear una nueva capacitación con imagen cargada
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Capacitaciones capacitaciones) //Se guarda igual con un objeto
        {
            Capacitaciones capacitacionEncontrada = await _db.Capacitaciones.FirstOrDefaultAsync(x => x.IdCapacitaciones == capacitaciones.IdCapacitaciones); //Primero buscamos si ya existe un USUARIO con ese ID
            if (capacitacionEncontrada == null && capacitaciones != null) //Si no hay un usuario con el mismo ID y es diferente de nul, se guarda
            {
                await _db.Capacitaciones.AddAsync(capacitaciones);//Proceso para guardado
                await _db.SaveChangesAsync();
                return Ok(capacitaciones);
            }

            //**formularioEncontrado** es una variable local por ello solo se encuentra en el metodo que se la declara

            return BadRequest("No se pudo crear el formulario");
        }


        // PUT api/<FormularioController>/5 //Actualizar
        [HttpPut("{IdCapacitaciones}")]
        public async Task<IActionResult> Put(int IdCapacitaciones, [FromBody] Capacitaciones capacitaciones) //PUT, POST Y DELETE se lleva los datos en la URL como parametros, FromDody los datos se mandan los datos en el cuerpo del mensaje.
        {
            Capacitaciones capacitacionEncontrada = await _db.Capacitaciones.FirstOrDefaultAsync(x => x.IdCapacitaciones == IdCapacitaciones); //Primero buscamos si ya existe un USUARIO con ese ID
            if (capacitacionEncontrada != null)
            {
                capacitacionEncontrada.Titulo = capacitaciones.Titulo != null ? capacitaciones.Titulo : capacitacionEncontrada.Titulo; //Se valida que no es nulo, caso contrario se queda con el mismo
                capacitacionEncontrada.Descripcion = capacitaciones.Descripcion != null ? capacitaciones.Descripcion : capacitacionEncontrada.Descripcion;//lo mismo
                capacitacionEncontrada.FechaInicio = capacitaciones.FechaInicio != null ? capacitaciones.FechaInicio : capacitacionEncontrada.FechaInicio;
                capacitacionEncontrada.FechaFin = capacitaciones.FechaFin != null ? capacitaciones.FechaFin : capacitacionEncontrada.FechaFin;
                capacitacionEncontrada.Precio = capacitaciones.Precio != null ? capacitaciones.Precio : capacitacionEncontrada.Precio;
                capacitacionEncontrada.Modalidad = capacitaciones.Modalidad != null ? capacitaciones.Modalidad : capacitacionEncontrada.Modalidad;
                capacitacionEncontrada.Lugar = capacitaciones.Lugar != null ? capacitaciones.Lugar : capacitacionEncontrada.Lugar;
                capacitacionEncontrada.URLImagen = capacitaciones.URLImagen != null ? capacitaciones.URLImagen : capacitacionEncontrada.URLImagen;

                _db.Capacitaciones.Update(capacitacionEncontrada);
                await _db.SaveChangesAsync();
                return Ok(capacitacionEncontrada);
            }
            return BadRequest();
        }



        // DELETE api/<UsuarioController>/5 //Eliminar
        [HttpDelete("{IdCapacitaciones}")]
        public async Task<IActionResult> Delete(int IdCapacitaciones)
        {
            Capacitaciones capacitaciones = await _db.Capacitaciones.FirstOrDefaultAsync(x => x.IdCapacitaciones == IdCapacitaciones); //Primero buscamos si ya existe un USUARIO con ese ID
            if (capacitaciones != null)
            {
                _db.Capacitaciones.Remove(capacitaciones);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return BadRequest("No se encontró ninguna capacitacion con el Id especificado."); // Se agrega el 'return' para devolver un resultado en caso de que la condición no se cumpla.
            }
        }

    }
}
