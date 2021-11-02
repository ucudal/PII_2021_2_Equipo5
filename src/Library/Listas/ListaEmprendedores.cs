using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase la cual contiene una lista en la cual estaran todos los emprendedores. 
    /// Cumple con el principio SRP ya que su única responsabilidad es conocer los 
    /// emprendedores.
    /// </summary>
    public class ListaEmprendedores 
    {
        /// <summary>
        /// Lista que contiene todos los emprendedores registrados.
        /// </summary>
        /// <returns></returns>
        public static List<Emprendedor> Emprendedores = new List<Emprendedor>();
    }
}