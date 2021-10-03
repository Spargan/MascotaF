using System;
namespace MascotaFeliz.App.Dominio
{
    public class Medicamentos
    {
        public int Id {get;set;}
        public Veterinario Veterinario{get;set;}
        public string Formula{get;set;}
        public string Dosis {get;set;}
    }
}