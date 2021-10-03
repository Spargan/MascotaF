using Microsoft.EntityFrameworkCore;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas {get;set;}
        public DbSet<Cliente> Clientes {get;set;}
        public DbSet<HistorialVisitas> HistorialesDeVisita {get;set;}
        public DbSet<Mascota> Mascotas {get;set;}
        public DbSet<MascotaAfiliada> MascotasAfiliadas {get;set;}
        public DbSet<Medicamentos> Medicamento {get;set;}
        public DbSet<Veterinario> Veterinarios {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {       
            if(!optionsBuilder.IsConfigured) 
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog =MascotaFelizData");
            }
        }
    }
}