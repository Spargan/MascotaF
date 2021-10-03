using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Consola
{
    class Program
    {
        private static IRepositorioMascota _repoMascota= new RepositorioMascota(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World EF!");
            BuscarMascota(1);
        }
        private static void AddMascota()
        {
            var mascota = new Mascota{
                Temperatura=28,
                Peso=30,
                FrecuenciaRespiratoria="Normal",
                Animo="Feliz",
                FechaVisita= new DateTime(2021, 09, 23),
                Especie="Perro",
                Raza="Labrador",
                Recomendaciones="Mucho cuidado porque esta viejito",
                IDVete="V1"
            };
            _repoMascota.AddMascota(mascota);
        }

        private static void BuscarMascota(int idMascota)
        {
            var mascota =_repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Especie+" "+mascota.Raza);
        }
    }
}
