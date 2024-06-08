using System.ComponentModel.DataAnnotations;

namespace APIWEBINFO.Models
{
    public class Mensaje
    {
        [Key]
        public int IdMensaje { get; set; }
        public string Nombre {  get; set; }
        public string Correo { get; set;}
        public int Telefono { get; set; }
        public string MensajeUsuario { get; set; }

    }
}
