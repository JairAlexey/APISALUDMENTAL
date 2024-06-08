using APIWEBINFO.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIWEBINFO.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWEBINFO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReservacionController : ControllerBase
    {

        private readonly ApplicationDBContext _db; //Declaracion / Solo lectura / Cuando un atributo es privado se le pone "_" (No es necesario)

        public ReservacionController(ApplicationDBContext db) //Inyeccion de dependecia
        {
            _db = db;
        }


        // GET: api/<ReservacionController> //MOSTRAR INFROMACION / LISTAR
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Reservacion> reservacions = await _db.Reservaciones.ToListAsync();
            return Ok(reservacions);
        }

        // GET api/<ReservacionController>/5 //MOSTRAR INFORMACION POR ID
        [HttpGet("{IdReservacion}")] //Para que todo cuadre
        public async Task<IActionResult> Get(int IdReservacion)
        {
            Reservacion reservaciones = await _db.Reservaciones.FirstOrDefaultAsync(x => x.IdReservacion == IdReservacion); //FirstOrDefaultAsync le manda el primero o manda un dato orDefault vacio, busca un arreglo
            if (reservaciones != null)
            {
                return Ok(reservaciones);
            }
            return BadRequest();//Indica que la solucitud de un cliente no se pudo completar. En este caso no se encontro ningun Usuario con el idUsuario proporcionado

        }

        // POST api/<ReservacionController> //GUARDAR INFORMACION
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reservacion reservaciones) //Se guarda igual con un objeto
        {
            Reservacion reservacionEncontrada = await _db.Reservaciones.FirstOrDefaultAsync(x => x.IdReservacion == reservaciones.IdReservacion); //Primero buscamos si ya existe un USUARIO con ese ID
            if (reservacionEncontrada == null && reservaciones != null) //Si no hay un usuario con el mismo ID y es diferente de nul, se guarda
            {
                await _db.Reservaciones.AddAsync(reservaciones);//Proceso para guardado
                await _db.SaveChangesAsync();
                return Ok(reservaciones);
            }

            //**reservacionEncontrada** es una variable local por ello solo se encuentra en el metodo que se la declara

            return BadRequest("No se pudo crear la reservacion");
        }


        // PUT api/<ReservacionController>/5 //Actualizar
        [HttpPut("{IdReservacion}")]
        public async Task<IActionResult> Put(int IdReservacion, [FromBody] Reservacion reservaciones) //PUT, POST Y DELETE se lleva los datos en la URL como parametros, FromDody los datos se mandan los datos en el cuerpo del mensaje.
        {
            Reservacion reservacionEncontrada = await _db.Reservaciones.FirstOrDefaultAsync(x => x.IdReservacion == IdReservacion); //Primero buscamos si ya existe un USUARIO con ese ID
            if (reservacionEncontrada != null)
            {
                reservacionEncontrada.Nombre = reservaciones.Nombre != null ? reservaciones.Nombre : reservacionEncontrada.Nombre;
                reservacionEncontrada.Correo = reservaciones.Correo != null ? reservaciones.Correo : reservacionEncontrada.Correo; //Se valida que no es nulo, caso contrario se queda con el mismo
                reservacionEncontrada.Telefono = reservaciones.Telefono != null ? reservaciones.Telefono : reservacionEncontrada.Telefono;//lo mismo
                reservacionEncontrada.Mensaje = reservaciones.Mensaje != null ? reservaciones.Mensaje : reservacionEncontrada.Mensaje;
                reservacionEncontrada.CapacitacionId = reservaciones.CapacitacionId != null ? reservaciones.CapacitacionId : reservacionEncontrada.CapacitacionId;
                _db.Reservaciones.Update(reservacionEncontrada);
                await _db.SaveChangesAsync();
                return Ok(reservacionEncontrada);
            }
            return BadRequest();
        }


        // DELETE api/<ReservacionController>/5 //Eliminar
        [HttpDelete("{IdReservacion}")]
        public async Task<IActionResult> Delete(int IdReservacion)
        {
            Reservacion reservaciones = await _db.Reservaciones.FirstOrDefaultAsync(x => x.IdReservacion == IdReservacion); //Primero buscamos si ya existe un USUARIO con ese ID
            if (reservaciones != null)
            {
                _db.Reservaciones.Remove(reservaciones);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return BadRequest("No se encontró ningúna reservacion con el Id especificado."); // Se agrega el 'return' para devolver un resultado en caso de que la condición no se cumpla.
            }
        }
    }
}
