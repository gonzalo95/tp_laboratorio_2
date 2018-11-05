using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Constructor sin parametros de la calse Universitario.
        /// </summary>
        public Universitario() { }

        /// <summary>
        /// Constructor de la clase Universitario.
        /// </summary>
        /// <param name="legajo">Legajo del universitario.</param>
        /// <param name="nombre">Nombre del universitario.</param>
        /// <param name="apellido">Apellido del universitario.</param>
        /// <param name="dni">Dni del universitario.</param>
        /// <param name="nacionalidad">Nacionalidad del universitario.</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Devuelve todos los datos del universitario.
        /// </summary>
        /// <returns>String con todos los datos.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder salida = new StringBuilder();
            salida.Append(base.ToString());
            salida.AppendLine("LEGAJO NUMERO: " + this.legajo);
            return salida.ToString();
        }
         /// <summary>
         /// Compara si 2 elementos son iguales.
         /// </summary>
         /// <param name="obj">Elemento a comparar.</param>
         /// <returns>True si son iguales, false en caso contrario.</returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType() && (this.legajo == ((Universitario)obj).legajo || this.DNI == ((Universitario)obj).DNI);
        }

        /// <summary>
        /// Compara si 2 universitarios son iguales.
        /// </summary>
        /// <param name="pg1">Primer universitario.</param>
        /// <param name="pg2">Segundo universitario.</param>
        /// <returns>True si son iguales, false en caso contrario.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Compara si 2 universitarios son distintos.
        /// </summary>
        /// <param name="pg1">Primer universitario.</param>
        /// <param name="pg2">Segundo universitario.</param>
        /// <returns>True si son distintos, false en caso contrario.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
