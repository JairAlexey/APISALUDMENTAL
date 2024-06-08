using APIWEBINFO.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIWEBINFO.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWEBINFO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MensajesController : ControllerBase
    {

        private readonly ApplicationDBContext _db; //Declaracion / Solo lectura / Cuando un atributo es privado se le pone "_" (No es necesario)

        public MensajesController(ApplicationDBContext db) //Inyeccion de dependecia
        {
            _db = db; 
        }


        // GET: api/<MensajesController> //MOSTRAR INFROMACION / LISTAR
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Mensaje> mensajes = await _db.Mensajes.ToListAsync();
            return Ok(mensajes);
        }

        // GET api/<MensajesController>/5 //MOSTRAR INFORMACION POR ID
        [HttpGet("{IdMensaje}")] //Para que todo cuadre
        public async Task<IActionResult> Get(int IdMensaje)   //el landa es cuando nos vamos en contra del arreglo
        {
            Mensaje mensajes = await _db.Mensajes.FirstOrDefaultAsync(x => x.IdMensaje == IdMensaje); //FirstOrDefaultAsync le manda el primero o manda un dato orDefault vacio, busca un arreglo
            if (mensajes != null) {
                return Ok(mensajes);
            }
            return BadRequest();//Indica que la solucitud de un cliente no se pudo completar. En este caso no se encontro ningun Usuario con el idUsuario proporcionado

        }

        // POST api/<MensajesController> //GUARDAR INFORMACION
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Mensaje mensajes) //Se guarda igual con un objeto
        {
            Mensaje mensajeEncontrado = await _db.Mensajes.FirstOrDefaultAsync(x => x.IdMensaje == mensajes.IdMensaje); //Primero buscamos si ya existe un USUARIO con ese ID
            if (mensajeEncontrado == null && mensajes != null) //Si no hay un usuario con el mismo ID y es diferente de nul, se guarda
            {
                await _db.Mensajes.AddAsync(mensajes);//Proceso para guardado
                await _db.SaveChangesAsync();
                return Ok(mensajes);
            }

            //**capacitacionEncontrada** es una variable local por ello solo se encuentra en el metodo que se la declara

            return BadRequest("No se pudo crear el mensaje");
        }


        // PUT api/<MensajesController>/5 //Actualizar
        [HttpPut("{IdMensaje}")]
        public async Task<IActionResult> Put(int IdMensaje, [FromBody] Mensaje mensajes) //PUT, POST Y DELETE se lleva los datos en la URL como parametros, FromDody los datos se mandan los datos en el cuerpo del mensaje.
        {
            Mensaje mensajeEncontrado = await _db.Mensajes.FirstOrDefaultAsync(x => x.IdMensaje == IdMensaje); //Primero buscamos si ya existe un USUARIO con ese ID
            if (mensajeEncontrado != null)
            {
                mensajeEncontrado.Nombre = mensajes.Nombre != null ? mensajes.Nombre : mensajeEncontrado.Nombre; //Se valida que no es nulo, caso contrario se queda con el mismo
                mensajeEncontrado.Correo = mensajes.Correo != null ? mensajes.Correo : mensajeEncontrado.Correo;//lo mismo
                mensajeEncontrado.Telefono = mensajes.Telefono != null ? mensajes.Telefono : mensajeEncontrado.Telefono;
                mensajeEncontrado.MensajeUsuario = mensajes.MensajeUsuario != null ? mensajes.MensajeUsuario : mensajeEncontrado.MensajeUsuario;

                _db.Mensajes.Update(mensajeEncontrado);
                await _db.SaveChangesAsync();
                return Ok(mensajeEncontrado);
            }
            return BadRequest();
        }


        // DELETE api/<MensajesController>/5 //Eliminar
        [HttpDelete("{IdMensaje}")]
        public async Task<IActionResult> Delete(int IdMensaje)
        {
            Mensaje mensajes = await _db.Mensajes.FirstOrDefaultAsync(x => x.IdMensaje == IdMensaje); //Primero buscamos si ya existe un USUARIO con ese ID
            if (mensajes != null)
            {
                _db.Mensajes.Remove(mensajes);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return BadRequest("No se encontró ningun mensaje con el Id especificado."); // Se agrega el 'return' para devolver un resultado en caso de que la condición no se cumpla.
            }
        }

    }
}
