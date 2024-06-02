using WebApplicationSaludMental.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using WebApplicationSaludMental.Configurations;
using System.Drawing;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationSaludMental.Services
{
    public class ApiService : IApiService
    {
        // URL base de la API con la que se interactúa.

        private readonly string _baseUrl; //Se separa porque se hace mas facil modificarse si se cambia la ip o el dominio

        // Cliente HTTP utilizado para hacer las peticiones a la API.
        private readonly HttpClient _httpClient;

        // Constructor: inicializa el URL base y el cliente HTTP.
        public ApiService(IOptions<ApiSettings> apiSettings, HttpClient httpClient) //Constructor
        {
            _baseUrl = apiSettings.Value.BaseUrl; //Para llamar
            _httpClient = httpClient;
        }

        public async Task<List<Usuarios>> getUsuario()
        {

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/User"); //var (ya no se recomienda usarlo muchp, mejor poner el tipo de objeto)
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<List<Usuarios>>(content);
                return usuario;
            }
            return null;
        }

        public async Task<Usuarios> getUsuario(int IdUsuario)
        {
          

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/User/{IdUsuario}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<Usuarios>(content);
                return usuario;
            }
            return null;
        }

        public async Task<bool> addUsuario(Usuarios usuarios)
        {
            var jsonString = JsonConvert.SerializeObject(usuarios);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/User/", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> updateUsuario(int IdUsuario, Usuarios usuarios)
        {
            var jsonString = JsonConvert.SerializeObject(usuarios);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/api/User/{IdUsuario}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> deleteUsuario(int IdUsuario)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/User/{IdUsuario}");

            return response.IsSuccessStatusCode;
        }




        //METODOAS DE CAPACITACIONES

        public async Task<List<Capacitaciones>> getCapacitaciones()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Capacitaciones"); //var (ya no se recomienda usarlo muchp, mejor poner el tipo de objeto)
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var capacitaciones = JsonConvert.DeserializeObject<List<Capacitaciones>>(content);
                return capacitaciones;
            }
            return null;
        }

        public async Task<Capacitaciones> getCapacitaciones(int IdCapacitaciones)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Capacitaciones/{IdCapacitaciones}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var capacitaciones = JsonConvert.DeserializeObject<Capacitaciones>(content);
                return capacitaciones;
            }
            return null;
        }

        public async Task<bool> addCapacitaciones(Capacitaciones capacitaciones)
        {
            var jsonString = JsonConvert.SerializeObject(capacitaciones);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/Capacitaciones/", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> updateCapacitaciones(int IdCapacitaciones, Capacitaciones capacitaciones)
        {

            var jsonString = JsonConvert.SerializeObject(capacitaciones);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/api/Capacitaciones/{IdCapacitaciones}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> deleteCapacitaciones(int IdCapacitaciones)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Capacitaciones/{IdCapacitaciones}");

            return response.IsSuccessStatusCode;
        }



        //METODOS DE LOGIN Y DETERMINAR ROL PARA LOS PERMISOS

        public async Task<bool> IniciarSesion(Usuarios inicioSesion)
        {
            // Asegúrate de que este método esté obteniendo los usuarios correctamente
            var usuarios = await getUsuario();

            // Verificar si hay algún usuario que coincida con las credenciales proporcionadas
            var usuario = usuarios.FirstOrDefault(u => u.Correo == inicioSesion.Correo && u.Password == inicioSesion.Password);

            // Devolver true si se encuentra un usuario que coincida con las credenciales, de lo contrario, devolver false
            return usuario != null;

        }

        public async Task<bool> DeterminarRol(Usuarios inicioSesion)
        {
            var usuarios = await getUsuario();

            // Verificar si el usuario tiene el rol de administrador
            var esAdministrador = usuarios.Any(u => u.Rol == "admin");

            // Devolver true si el usuario es administrador, de lo contrario, devolver false
            return esAdministrador;
        }

        //Formulario
        public async Task<List<Formulario>> getFormulario()
        {

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Formulario"); //var (ya no se recomienda usarlo muchp, mejor poner el tipo de objeto)
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var formulario = JsonConvert.DeserializeObject<List<Formulario>>(content);
                return formulario;
            }
            return null;
        }

        public async Task<Formulario> getFormulario(int IdFormulario)
        {


            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Formulario/{IdFormulario}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var formulario = JsonConvert.DeserializeObject<Formulario>(content);
                return formulario;
            }
            return null;
        }

        public async Task<bool> addFormulario(Formulario formularios)
        {
            var jsonString = JsonConvert.SerializeObject(formularios);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/Formulario/", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> updateFormulario(int IdFormulario, Formulario formularios)
        {
            var jsonString = JsonConvert.SerializeObject(formularios);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/api/Formulario/{IdFormulario}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> deleteFormulario(int IdFormulario)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Formulario/{IdFormulario}");

            return response.IsSuccessStatusCode;
        }

        //Link Video Portada
        public async Task<List<Link>> getLink()
        {

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Links"); //var (ya no se recomienda usarlo muchp, mejor poner el tipo de objeto)
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var link = JsonConvert.DeserializeObject<List<Link>>(content);
                return link;
            }
            return null;
        }

        public async Task<Link> getLink(int IdLink)
        {


            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Links/{IdLink}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var link = JsonConvert.DeserializeObject<Link>(content);
                return link;
            }
            return null;
        }

        public async Task<bool> addLink(Link links)
        {
            var jsonString = JsonConvert.SerializeObject(links);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/Links/", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> updateLink(int IdLink, Link links)
        {
            var jsonString = JsonConvert.SerializeObject(links);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/api/Links/{IdLink}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> deleteLink(int IdLink)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Links/{IdLink}");

            return response.IsSuccessStatusCode;
        }


        //Reservacion de capacitaciones
        public async Task<List<Reservacion>> getReservacion()
        {

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Reservacion"); //var (ya no se recomienda usarlo muchp, mejor poner el tipo de objeto)
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var reservacion = JsonConvert.DeserializeObject<List<Reservacion>>(content);
                return reservacion;
            }
            return null;
        }

        public async Task<Reservacion> getReservacion(int IdReservacion)
        {


            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Reservacion/{IdReservacion}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var reservacion = JsonConvert.DeserializeObject<Reservacion>(content);
                return reservacion;
            }
            return null;
        }

        public async Task<bool> addReservacion(Reservacion reservaciones)
        {
            var jsonString = JsonConvert.SerializeObject(reservaciones);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/Reservacion/", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> updateReservacion(int IdReservacion, Reservacion reservaciones)
        {
            var jsonString = JsonConvert.SerializeObject(reservaciones);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/api/Reservacion/{IdReservacion}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> deleteReservacion(int IdReservacion)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Reservacion/{IdReservacion}");

            return response.IsSuccessStatusCode;
        }

        //Mensajes del Usuario
        public async Task<List<Mensaje>> getMensaje()
        {

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Mensajes"); //var (ya no se recomienda usarlo muchp, mejor poner el tipo de objeto)
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var mensajes = JsonConvert.DeserializeObject<List<Mensaje>>(content);
                return mensajes;
            }
            return null;
        }

        public async Task<Mensaje> getMensaje(int IdMensaje)
        {


            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Mensajes/{IdMensaje}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var mensajes = JsonConvert.DeserializeObject<Mensaje>(content);
                return mensajes;
            }
            return null;
        }

        public async Task<bool> addMensaje(Mensaje mensajes)
        {
            var jsonString = JsonConvert.SerializeObject(mensajes);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/Mensajes/", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> updateMensaje(int IdMensaje, Mensaje mensajes)
        {
            var jsonString = JsonConvert.SerializeObject(mensajes);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/api/Mensajes/{IdMensaje}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> deleteMensaje(int IdMensaje)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Mensajes/{IdMensaje}");

            return response.IsSuccessStatusCode;
        }
    }

}
