using System;
using System.Text;

namespace Library
{
    public class UbicacionHandler :IHandler
    {
        public IHandler Next {get; set;}
        public void Handle(Mensaje mensaje)
        {
            /*if (mensaje.Text.Contains("/"))
            {}
            else
            {
                this.Next.Handle(mensaje);
            }*/

            Console.WriteLine("Añadir ubicación: ");
            string ubicacion = Console.ReadLine();
        }
    }
}