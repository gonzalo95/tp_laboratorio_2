using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Entidades
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Constructor sin parametros de la clase Alumno.
        /// </summary>
        public Alumno() { }

        /// <summary>
        /// Constructor de la clase Alumno.
        /// </summary>
        /// <param name="id">Id del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">Dni del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno.</param>
        /// <param name="claseQueToma">Clase del alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de la clase Alumno.
        /// </summary>
        /// <param name="id">Id del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">Dni del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno.</param>
        /// <param name="claseQueToma">Clase del alumno.</param>
        /// <param name="estadoCuenta">Estado de cuenta del alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Devuelve un string con la clase que toma.
        /// </summary>
        /// <returns>String de la clase que toma el alumno.</returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASE DE {0}", this.claseQueToma);
        }

        /// <summary>
        /// Operador que permite comparar un alumno con una clase.
        /// </summary>
        /// <param name="a">ALumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>True si el alumno toma la clase y su estado de cuenta no es deudor, false ne caso contrario.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }

        /// <summary>
        /// Operador que permite comparar un alumno con una clase.
        /// </summary>
        /// <param name="a">ALumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>True si el alumno no toma la clase o su estado de cuenta deudor, false ne caso contrario.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }

        /// <summary>
        /// Devuelve todos los datos del alumno.
        /// </summary>
        /// <returns>String con los datos del alumno.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder salida = new StringBuilder();
            salida.Append(base.MostrarDatos());
            salida.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);
            salida.AppendLine(this.ParticiparEnClase());
            return salida.ToString();
        }

        /// <summary>
        /// Devuelve todos los datos del alumno.
        /// </summary>
        /// <returns>String con los datos del alumno.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
