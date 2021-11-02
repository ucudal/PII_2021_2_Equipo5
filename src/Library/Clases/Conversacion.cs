using System;
using System.Collections.Generic;


namespace Library
{

    /// <summary>
    /// La clase conversación se encarga de llevar el conteo de mensajes de cada 
    /// uno de los ususarios
    /// </summary>
    public class Conversacion
    {
        /// <summary>
        /// Guarda el id del usuario.
        /// </summary>
        /// <value></value>
        private int id {get; set;}
        /// <summary>
        /// Lista donde se guardan los mensajes.
        /// </summary>
        /// <returns></returns>
        private List<string> mensajes = new List<string>();
        /// <summary>
        /// Método encargado de agregar el mensaje enviado como parámetro a la lista de mensajes.
        /// </summary>
        /// <param name="mensaje"></param>
        void AgregarMensaje(string mensaje)
        {
            mensajes.Add(mensaje);
        }
    }
}