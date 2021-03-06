// -----------------------------------------------------------------------
// <copyright file="CrearPublicacionHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


namespace Library
{
    /// <summary>
    /// Handler para crear una publicación. Implementa AbstractHandler porque interactúa
    /// con el usuario.
    /// </summary>
    public class CrearPublicacionHandler : AbstractHandler
    {
        /// <summary>
        /// Atributo que guarda el nombre del material.
        /// </summary>
        public string NombreMaterial;
        
        /// <summary>
        /// Atributo que guarda la categoria del material.
        /// </summary>
        public string Categoria; 

        /// <summary>
        /// Atributo que guarda la unidad del material.
        /// </summary>
        public string Unidad;
        
        /// <summary>
        /// Atributo que guarda el costo del material.
        /// </summary>
        public double Costo;

        /// <summary>
        /// Atributo que guarda la cantidad del material.
        /// </summary>
        public double Cantidad;

        /// <summary>
        /// Atributo que guarda las habilidades que se necesitan para manipular el material.
        /// </summary>
        public string Habilitaciones;

        /// <summary>
        /// Atributo que guarda el titulo de la publicación.
        /// </summary>
        public string Titulo;

        /// <summary>
        /// Atributo que guarda las palabras claves de la publicación.
        /// </summary>
        public string PalabrasClave;

        /// <summary>
        /// Atributo que guarda la frecuencia del material.
        /// </summary>
        public string Frecuencia;

        /// <summary>
        /// Atributo que guarda la localización del material.
        /// </summary>
        public string Localizacion;

        /// <summary>
        /// Método que interpreta el mensaje. Si el mensaje es "/CrearPublicación", el método pide los
        /// datos de materiales y llama a la clase CrearMaterial para cumplir con el SRP. Luego, se
        /// llama a la clase CrearPublicacion por la misma razón.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        /// <returns>Retorna la respuesta a la petición del usuario.</returns>
        public override string Handle(Mensaje mensaje)
        {
            ListaEmpresa lista = new ListaEmpresa();
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            int indice = listaUsuario.Buscar(mensaje.Id);
            EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;

            if (mensaje.Text.ToLower() == "/crearpublicacion" || estado.Handler == "/crearpublicacion")
            {
                this.TextResult = new StringBuilder();
                if (lista.Verificar(mensaje.Id))
                {
                    this.TextResult = new StringBuilder();
                    estado.Handler = "/crearpublicacion";
                    switch (estado.Step)
                    {
                        case 0:
                        this.TextResult = new StringBuilder();
                        this.TextResult.Append("Ingrese el material:");
                        estado.Step++;
                        break;

                        case 1:
                        this.TextResult = new StringBuilder();
                        this.NombreMaterial = mensaje.Text;
                        this.TextResult.Append("Ingrese la categoria: \n(/Químicos\n  /Plásticos\n  /Celulósicos\n  /Eléctricos\n  /Textiles)\n");
                        estado.Step++;
                        break;

                        case 2:
                        this.TextResult = new StringBuilder();
                        this.Categoria = mensaje.Text;
                        this.TextResult.Append("Ingrese la unidad con la que cuantifica el material:");
                        estado.Step++;
                        break;

                        case 3:
                        this.TextResult = new StringBuilder();
                        this.Unidad = mensaje.Text;
                        this.TextResult.Append("Ingrese el precio por unidad:");
                        estado.Step++;
                        break;

                        case 4:
                        this.TextResult = new StringBuilder();
                        this.Costo = Convert.ToDouble(mensaje.Text, NumberFormatInfo.InvariantInfo);
                        this.TextResult.Append("Ingrese la cantidad:");
                        estado.Step++;
                        break;

                        case 5:
                        this.TextResult = new StringBuilder();
                        this.Cantidad = Convert.ToDouble(mensaje.Text, NumberFormatInfo.InvariantInfo);
                        this.TextResult.Append("Ingrese habilitaciones necesarias para manipular el material:");
                        estado.Step++;
                        break;

                        case 6:
                        this.TextResult = new StringBuilder();
                        this.Habilitaciones = mensaje.Text;
                        this.TextResult.Append("Ingrese el título:");
                        estado.Step++;
                        break;

                        case 7:
                        this.TextResult = new StringBuilder();
                        this.Titulo = mensaje.Text;
                        this.TextResult.Append("Ingrese palabras claves separadas con ',' : ");
                        estado.Step++;
                        break;

                        case 8:
                        this.TextResult = new StringBuilder();
                        this.PalabrasClave = mensaje.Text;
                        this.TextResult.Append("Ingrese frequencia de disponibilidad: ");
                        estado.Step++;
                        break;

                        case 9:
                        this.TextResult = new StringBuilder();
                        this.Frecuencia = mensaje.Text;
                        this.TextResult.Append("Ingrese dónde se encuentra: ");
                        estado.Step++;
                        break;

                        case 10:
                        this.TextResult = new StringBuilder();
                        this.Localizacion = mensaje.Text;
                        IUbicacionProvider ubicacionProvider = new UbicacionProvider();
                        IUbicacion ubi = ubicacionProvider.GetUbicacion(this.Localizacion);
                        Material material = new Material(this.NombreMaterial, this.Costo, this.Cantidad, this.Unidad, this.Habilitaciones, this.Categoria);
                        Empresa empresa = Singleton<ListaEmpresa>.Instance.Buscar(mensaje.Id);
                        Publicacion publicacion = new Publicacion(this.Titulo, material, this.PalabrasClave, this.Frecuencia, ubi, empresa);
                        this.TextResult.Append("Tú publicación ahora se encuentra activa.");
                        estado.Step = 0;
                        estado.Handler = string.Empty;

                        break;
                    }
                }
                else
                {
                    throw new SinPermisoException("No tienes permiso para crear una publicación, usted debe pertenecer a una empresa para crear publicaciones.");
                }

                return this.TextResult.ToString();
            }
            else
            {
                return this.GetNext().Handle(mensaje);
            }
        }
    }
}