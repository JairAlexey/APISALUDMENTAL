using System.ComponentModel.DataAnnotations;

namespace APIWEBINFO.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set;}
        public string Nombre { get; set; }
        public string Correo { get; set;}
        public string Password { get; set;}
    }
}
