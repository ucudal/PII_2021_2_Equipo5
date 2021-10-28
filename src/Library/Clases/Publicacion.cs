
using System;

namespace Library
{
    public class Publicacion
    {
        private string titulo {get; set;}
        private DatosDeMateriales material {get; set;}
        private string palabrasClave;
        public string PalabrasClave
        {
            get{ return this.palabrasClave; }
            set{ this.PalabrasClave = value; }
        }
        private string FrecuenciaDeDisponibilidad {get; set;}
        private string Ubicacion {get; set;}

        public Publicacion(string titulo, DatosDeMateriales material, string PalabrasClave, string FrecuenciaDeDisponibilidad, string ubicacion)
        {
            this.titulo = titulo;
            this.material = material;
            this.PalabrasClave = PalabrasClave;
            this.FrecuenciaDeDisponibilidad = FrecuenciaDeDisponibilidad;
            this.Ubicacion = ubicacion;
        }
    }
}

