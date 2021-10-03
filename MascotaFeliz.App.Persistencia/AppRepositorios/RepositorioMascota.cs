using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota
    {
        /// <summary>
        /// Referencia al contexto de Mascota
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiliza
        /// Inyección de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepositorioMascota(AppContext appContext)
        {
            _appContext = appContext;
        }
        Mascota IRepositorioMascota.AddMascota(Mascota mascota)
        {
            var mascotaAdicionada = _appContext.Mascotas.Add(mascota);
            _appContext.SaveChanges();
            return mascotaAdicionada.Entity;
        }

        void IRepositorioMascota.DeleteMascota(int idMascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
            if (mascotaEncontrada == null)
                return;
            _appContext.Mascotas.Remove(mascotaEncontrada);
            _appContext.SaveChanges();
        }

        IEnumerable<Mascota> IRepositorioMascota.GetAllMascotas()
        {
            return _appContext.Mascotas;
        }

        Mascota IRepositorioMascota.GetMascota(int idMascota)
        {
            return _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
        }

        Mascota IRepositorioMascota.UpdateMascota(Mascota mascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(m => m.Id == mascota.Id);
            if (mascotaEncontrada!=null)
            {
                mascotaEncontrada.Temperatura=mascota.Temperatura;
                mascotaEncontrada.Peso=mascota.Peso;
                mascotaEncontrada.FrecuenciaRespiratoria=mascota.FrecuenciaRespiratoria;
                mascotaEncontrada.Animo=mascota.Animo;
                mascotaEncontrada.FechaVisita=mascota.FechaVisita;
                mascotaEncontrada.Especie=mascota.Especie;
                mascotaEncontrada.Raza=mascota.Raza;
                mascotaEncontrada.Recomendaciones=mascota.Recomendaciones;
                mascotaEncontrada.IDVete=mascota.IDVete;
                mascotaEncontrada.Cliente=mascota.Cliente;
                mascotaEncontrada.Veterinario=mascota.Veterinario;

                _appContext.SaveChanges();
            }
            return mascotaEncontrada;
        }
    }
}