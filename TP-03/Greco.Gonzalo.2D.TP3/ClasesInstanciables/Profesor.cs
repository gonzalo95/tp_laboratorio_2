using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Entidades
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Constructor estatico de la clase Profesor.
        /// Inicializa el campo random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de instancia sin parametros de la clase Profesor.
        /// </summary>
        public Profesor() : this(0, "", "", "", 0) { }
        
        /// <summary>
        /// Constructor de instancia de la clase PRofesor.
        /// </summary>
        /// <param name="id">Id del profesor.</param>
        /// <param name="nombre">Nombre del profesor.</param>
        /// <param name="apellido">Apellido del profesor.</param>
        /// <param name="dni">Dni del profesor.</param>
        /// <param name="nacionalidad">Nacionalidad del profesor.</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// Asigna 2 clases aleatorias.
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
        }

        /// <summary>
        /// Devuelve las clases del dia.
        /// </summary>
        /// <returns>String con las clases del dia.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder salida = new StringBuilder();
            salida.AppendLine("CLASES DEL DIA: ");
            foreach(Universidad.EClases clase in this.clasesDelDia)
            {
                salida.AppendLine(clase.ToString());
            }
            return salida.ToString();
        }

        /// <summary>
        /// Devuelve todos los datos del profesor.
        /// </summary>
        /// <returns>String con todos los datos.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder salida = new StringBuilder();
            salida.Append(base.MostrarDatos());
            salida.AppendLine(this.ParticiparEnClase());
            return salida.ToString();
        }

        /// <summary>
        /// Devuelve todos los datos del profesor.
        /// </summary>
        /// <returns>String con todos los datos.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Operador que permite comparar un profesor con una clase.
        /// </summary>
        /// <param name="i">Profesor a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>True si el profesor da esa clase, false en caso contrario.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool salida = false;
            foreach (Universidad.EClases c in i.clasesDelDia)
            {
                if(c == clase)
                {
                    salida = true;
                    break;
                }
            }
            return salida;
        }

        /// <summary>
        /// Operador que permite comparar un profesor con una clase.
        /// </summary>
        /// <param name="i">Profesor a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>True si el profesor no da esa clase, false en caso contrario.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
