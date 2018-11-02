using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        public DniInvalidoException() : this("El formato del DNI es invalido") { }

        public DniInvalidoException(Exception e) : this("El formato del DNI es invalido", e) { }

        public DniInvalidoException(string mensaje) : base(mensaje)
        {
            this.mensajeBase = mensaje;
        }

        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {
            this.mensajeBase = mensaje;
        }
    }
}
