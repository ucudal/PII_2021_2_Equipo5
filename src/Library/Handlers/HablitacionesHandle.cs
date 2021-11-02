using System;
using System.Text;

namespace Library
{
    public class HabilitacionesHandler : AbstractHandler
    {
        public override void Handle (Mensaje mensaje)
        {
            
            if (mensaje.Text == "/Habilitaciones")
            {
                Output.PrintLine("");
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}
