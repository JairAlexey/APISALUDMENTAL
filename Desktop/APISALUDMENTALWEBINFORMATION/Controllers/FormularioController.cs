using APIWEBINFO.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIWEBINFO.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWEBINFO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FormularioController : ControllerBase
    {

        private readonly ApplicationDBContext _db; //Declaracion / Solo lectura / Cuando un atributo es privado se le pone "_" (No es necesario)

        public FormularioController(ApplicationDBContext db) //Inyeccion de dependecia
        {
            _db = db; 
        }


        // GET: api/<FormularioController> //MOSTRAR INFROMACION / LISTAR
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Formulario> formularios = await _db.Formulario.ToListAsync();
            return Ok(formularios);
        }

        // GET api/<FormularioController>/5 //MOSTRAR INFORMACION POR ID
        [HttpGet("{IdFormulario}")] //Para que todo cuadre
        public async Task<IActionResult> Get(int IdFormulario)   //el landa es cuando nos vamos en contra del arreglo
        {
            Formulario formularios = await _db.Formulario.FirstOrDefaultAsync(x => x.IdFormulario == IdFormulario); //FirstOrDefaultAsync le manda el primero o manda un dato orDefault vacio, busca un arreglo
            if (formularios != null) {
                return Ok(formularios);
            }
            return BadRequest();//Indica que la solucitud de un cliente no se pudo completar. En este caso no se encontro ningun Usuario con el idUsuario proporcionado

        }

        // POST api/<FormularioController> //GUARDAR INFORMACION
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Formulario formularios) //Se guarda igual con un objeto
        {
            Formulario formularioEncontrado = await _db.Formulario.FirstOrDefaultAsync(x => x.IdFormulario == formularios.IdFormulario); //Primero buscamos si ya existe un USUARIO con ese ID
            if (formularioEncontrado == null && formularios != null) //Si no hay un usuario con el mismo ID y es diferente de nul, se guarda
            {
                await _db.Formulario.AddAsync(formularios);//Proceso para guardado
                await _db.SaveChangesAsync();
                return Ok(formularios);
            }

            //**formularioEncontrado** es una variable local por ello solo se encuentra en el metodo que se la declara

            return BadRequest("No se pudo crear el formulario");
        }


        // PUT api/<FormularioController>/5 //Actualizar
        [HttpPut("{IdFormulario}")]
        public async Task<IActionResult> Put(int IdFormulario, [FromBody] Formulario formularios) //PUT, POST Y DELETE se lleva los datos en la URL como parametros, FromDody los datos se mandan los datos en el cuerpo del mensaje.
        {
            Formulario formularioEncontrado = await _db.Formulario.FirstOrDefaultAsync(x => x.IdFormulario == IdFormulario); //Primero buscamos si ya existe un USUARIO con ese ID
            if (formularioEncontrado != null)
            {
                formularioEncontrado.Nombre = formularios.Nombre != null ? formularios.Nombre : formularioEncontrado.Nombre; //Se valida que no es nulo, caso contrario se queda con el mismo
                formularioEncontrado.FechaNacimiento = formularios.FechaNacimiento != null ? formularios.FechaNacimiento : formularioEncontrado.FechaNacimiento;//lo mismo
                formularioEncontrado.FechaSuceso = formularios.FechaSuceso != null ? formularios.FechaSuceso : formularioEncontrado.FechaSuceso;
                formularioEncontrado.Rol = formularios.Rol != null ? formularios.Rol : formularioEncontrado.Rol;
                formularioEncontrado.Sexo = formularios.Sexo != null ? formularios.Sexo : formularioEncontrado.Sexo;
                formularioEncontrado.Mensaje = formularios.Mensaje != null ? formularios.Mensaje : formularioEncontrado.Mensaje;

                _db.Formulario.Update(formularioEncontrado);
                await _db.SaveChangesAsync();
                return Ok(formularioEncontrado);
            }
            return BadRequest();
        }


        // DELETE api/<FormularioController>/5 //Eliminar
        [HttpDelete("{IdFormulario}")]
        public async Task<IActionResult> Delete(int IdFormulario)
        {
            Formulario formularios = await _db.Formulario.FirstOrDefaultAsync(x => x.IdFormulario == IdFormulario); //Primero buscamos si ya existe un USUARIO con ese ID
            if (formularios != null)
            {
                _db.Formulario.Remove(formularios);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return BadRequest("No se encontró ningun formualrio con el Id especificado."); // Se agrega el 'return' para devolver un resultado en caso de que la condición no se cumpla.
            }
        }

    }
}
