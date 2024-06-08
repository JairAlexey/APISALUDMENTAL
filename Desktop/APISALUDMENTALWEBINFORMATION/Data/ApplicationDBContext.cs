using APIWEBINFO.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace APIWEBINFO.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { 


        
        }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Capacitaciones> Capacitaciones { get; set; }

        public DbSet<Link> Links { get; set; }

        public DbSet<Formulario> Formulario { get; set; }

        public DbSet<Reservacion> Reservaciones { get; set; }

        public DbSet<Mensaje> Mensajes { get; set; }
    }
}
