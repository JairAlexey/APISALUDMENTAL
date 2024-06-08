using APIWEBINFO.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIWEBINFO.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWEBINFO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public UserController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _db.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

        // GET api/<UserController>/5
        [HttpGet("{IdUsuario}")]
        public async Task<IActionResult> Get(int IdUsuario)
        {
            var usuario = await _db.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == IdUsuario);
            if (usuario != null)
            {
                return Ok(usuario);
            }
            return BadRequest("Usuario no encontrado.");
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuarios usuario)
        {
            var usuarioEncontrado = await _db.Usuarios.AnyAsync(x => x.IdUsuario == usuario.IdUsuario);
            if (!usuarioEncontrado)
            {
                await _db.Usuarios.AddAsync(usuario);
                await _db.SaveChangesAsync();
                return Ok(usuario);
            }
            return BadRequest("No se pudo crear el usuario porque ya existe.");
        }

        // PUT api/<UserController>/5
        [HttpPut("{IdUsuario}")]
        public async Task<IActionResult> Put(int IdUsuario, [FromBody] Usuarios usuarioNuevo)
        {
            var usuario = await _db.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == IdUsuario);
            if (usuario != null)
            {
                usuario.Nombre = usuarioNuevo.Nombre ?? usuario.Nombre;
                usuario.Correo = usuarioNuevo.Correo ?? usuario.Correo;
                usuario.Password = usuarioNuevo.Password ?? usuario.Password;

                _db.Usuarios.Update(usuario);
                await _db.SaveChangesAsync();
                return Ok(usuario);
            }
            return BadRequest("Usuario no encontrado.");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{IdUsuario}")]
        public async Task<IActionResult> Delete(int IdUsuario)
        {
            var usuario = await _db.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == IdUsuario);
            if (usuario != null)
            {
                _db.Usuarios.Remove(usuario);
                await _db.SaveChangesAsync();
                return NoContent(); // Correctamente se retorna NoContent en eliminaciones exitosas
            }
            return BadRequest("Usuario no encontrado.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuarios loginInfo)
        {
            var usuario = await _db.Usuarios.FirstOrDefaultAsync(x => x.Correo == loginInfo.Correo && x.Password == loginInfo.Password);
            if (usuario != null)
            {
                return Ok(new { message = "Inicio de sesión exitoso", usuario.IdUsuario });
            }
            return Unauthorized("Credenciales inválidas. Intente nuevamente.");
        }
    }
}
