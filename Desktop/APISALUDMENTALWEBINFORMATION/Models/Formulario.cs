using System.ComponentModel.DataAnnotations;

namespace APIWEBINFO.Models
{
    public class Formulario
    {
        [Key]
        public int IdFormulario { get; set; }
        public string Nombre {  get; set; }
        public string FechaNacimiento { get; set;}
        public string FechaSuceso { get; set; }
        public string Rol { get; set; }
        public string Sexo { get; set; }
        public string Mensaje { get; set; }

    }
}
