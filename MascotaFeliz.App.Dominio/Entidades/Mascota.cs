using System;
namespace MascotaFeliz.App.Dominio
{
    public class Mascota
    {
        public int Id{get;set;}
        public Cliente Cliente{get;set;}
        public Veterinario Veterinario{get;set;}
        public int Temperatura {get;set;}
        public int Peso {get;set;}
        public string FrecuenciaRespiratoria {get;set;}
        public string Animo {get;set;}
        public DateTime FechaVisita {get;set;}
        public string IDVete {get;set;}
        public string Especie {get;set;}
        public string Raza {get;set;}
        public string Recomendaciones {get;set;}
    }
}