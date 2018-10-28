using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()
        {
            StringBuilder salida = new StringBuilder();
            salida.Append(base.ToString());
            salida.AppendLine("LEGAJO NUMERO: " + this.legajo);
            return salida.ToString();
        }

        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType() && this.legajo == ((Universitario)obj).legajo && this.DNI == ((Universitario)obj).DNI;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
