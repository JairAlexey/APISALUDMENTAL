namespace WebApplicationSaludMental.Models
{
    public class Reservacion
    {
        public int IdReservacion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string Mensaje { get; set; }
        public int CapacitacionId { get; set; }

    }
}
