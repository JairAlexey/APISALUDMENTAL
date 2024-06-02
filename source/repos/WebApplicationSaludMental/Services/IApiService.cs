using WebApplicationSaludMental.Models;

namespace WebApplicationSaludMental.Services
{
    public interface IApiService
    {
        Task<List<Usuarios>> getUsuario();
        Task<Usuarios> getUsuario(int IdUsuario);
        Task<bool> addUsuario(Usuarios usuarios);
        Task<bool> updateUsuario(int IdUsuario, Usuarios usuarios);
        Task<bool> deleteUsuario(int IdUsuario);
        Task<bool> IniciarSesion(Usuarios inicioSesion);
        Task<bool> DeterminarRol(Usuarios inicioSesion);

        Task<List<Capacitaciones>> getCapacitaciones();
        Task<Capacitaciones> getCapacitaciones(int IdCapacitaciones);
        Task<bool> addCapacitaciones(Capacitaciones capacitaciones);
        Task<bool> updateCapacitaciones(int IdCapacitaciones, Capacitaciones capacitaciones);
        Task<bool> deleteCapacitaciones(int IdCapacitaciones);

        Task<List<Formulario>> getFormulario();
        Task<Formulario> getFormulario(int IdFormulario);
        Task<bool> addFormulario(Formulario formularios);
        Task<bool> updateFormulario(int IdFormulario, Formulario formularios);
        Task<bool> deleteFormulario(int IdFormulario);

        Task<List<Link>> getLink();
        Task<Link> getLink(int IdLink);
        Task<bool> addLink(Link link);
        Task<bool> updateLink(int IdLink, Link links);
        Task<bool> deleteLink(int IdLink);

        Task<List<Reservacion>> getReservacion();
        Task<Reservacion> getReservacion(int IdReservacion);
        Task<bool> addReservacion(Reservacion reservaciones);
        Task<bool> updateReservacion(int IdReservacion, Reservacion reservaciones);
        Task<bool> deleteReservacion(int IdReservacion);

        Task<List<Mensaje>> getMensaje();
        Task<Mensaje> getMensaje(int IdMensaje);
        Task<bool> addMensaje(Mensaje mensajes);
        Task<bool> updateMensaje(int IdMensaje, Mensaje mensajes);
        Task<bool> deleteMensaje(int IdMensaje);
    }
}
