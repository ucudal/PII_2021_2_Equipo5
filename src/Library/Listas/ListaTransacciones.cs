// -----------------------------------------------------------------------
// <copyright file="ListaTransacciones.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Library
{
    /// <summary>
    /// Clase que modela un contenedor de las transacciones realizadas.
    /// Tiene la responsabilidad de conocer todos las transacciones, buscar todas las transacciones que involucran cierto Id retornando
    /// una lista con las mismas.
    /// Depende de la Clase Transacción.
    /// Implementa IJsonConvertible para depender de una abstracción y no directamente de los metodos Json.Serialization. (DIP).
    /// </summary>
    public class ListaTransacciones : IJsonConvertible, IMostrar
    {
        /// <summary>
        /// Transacciones es quien tiene la lista con los objetos de la clase Transaccion.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// </summary>
        /// <returns>Lista con todas las transacciones.</returns>
        public List<Transaccion> Transacciones = Singleton<List<Transaccion>>.Instance;

        /// <summary>
        /// Se crea el método Add para añadir una Transaccion a la ListaTransacciones
        /// ya existente.
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce
        /// todas las transacciones que se realizan.
        /// </summary>
        /// <param name="transaccion">Transacción que se desea agregar a la lista.</param>
        public void Add(Transaccion transaccion)
        {
            this.Transacciones.Add(transaccion);
        }

        /// <summary>
        /// Método que devuelve una lista con todas las transacciones hechas con ese id. Se busca cumplir
        /// con Expert, ya que esta clase es la que contiene toda la información de las transacciones.
        /// </summary>
        /// <param name="id">Busca transacciones por id.</param>
        /// <returns>Devuelve una lista con todas las transacciones encontradas.</returns>
        public List<Transaccion> Buscar(long id)
        {
            List<Transaccion> resultado = new List<Transaccion>();
            ListaEmpresa lista = new ListaEmpresa();
            Empresa empresa = lista.Buscar(id);
            foreach (Transaccion transaccion in this.Transacciones)
            {
                if (transaccion.Vendedor == empresa || transaccion.Comprador.Id == id)
                {
                    resultado.Add(transaccion);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Método que crea una instancia de esta clase y convierte su atributo Transacciones en un string
        /// en formato json.
        /// </summary>
        /// <returns>String en formato json.</returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(Singleton<List<Transaccion>>.Instance);
        }

        /// <summary>
        /// Método que crea una instancia de esta clase y, a partir de un string en formato json, carga las transacciones al
        /// atributo Transacciones del objeto.
        /// </summary>
        /// <param name="json">String en formato json.</param>
        public void LoadFromJson(string json)
        {
            List<Transaccion> listaTrans = new List<Transaccion>();
            listaTrans = JsonSerializer.Deserialize<List<Transaccion>>(json);
            this.Transacciones = listaTrans;
        }

        /// <summary>
        /// Método para mostrar la lista pasada como parámetro en pantalla.
        /// </summary>
        /// <param name="lista">Lista que se desea mostrar.</param>
        /// <returns>Devuelve el stringbuilder con los elementos de la lista.</returns>
        public StringBuilder Mostrar(List<IConversorTexto> lista)
        {
            StringBuilder resultado = new StringBuilder();
            if (lista == null || lista.Count == 0)
            {
                resultado.Append("No se encontraron elementos para mostrar.");
            }
            else
            {
                foreach (IConversorTexto item in lista)
                {
                    resultado.Append(item.ConvertToString());
                }
            }

            return resultado;
        }
    }
}