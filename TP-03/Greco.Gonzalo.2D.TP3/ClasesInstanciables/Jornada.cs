using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Entidades
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Propiedad de lectura y escritura del campo alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del campo clase.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del campo instructor.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Constructor sin parametros que inicializa el campo alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de la clase Jornada.
        /// </summary>
        /// <param name="clase">Clase de la jornada.</param>
        /// <param name="instructor">Instructor de la jornada.</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Operador que permite comparar una jornada con un alumno.
        /// </summary>
        /// <param name="j">Jornada a comparar.</param>
        /// <param name="a">Alumnjo a comparar.</param>
        /// <returns>True si el alumno pertenece a esa jornada, false en caso contrario.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool salida = false;
            foreach(Alumno alumno in j.Alumnos)
            {
                if(alumno == a)
                {
                    salida = true;
                    break;
                }
            }
            return salida;
        }

        /// <summary>
        /// Operador que permite comparar una jornada con un alumno.
        /// </summary>
        /// <param name="j">Jornada a comparar.</param>
        /// <param name="a">Alumnjo a comparar.</param>
        /// <returns>True si el alumno no pertenece a esa jornada, false en caso contrario.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Operador que permite agregar un alumno a la jornada.
        /// </summary>
        /// <param name="j">Jornada.</param>
        /// <param name="a">Alumno.</param>
        /// <returns>Jornada con el alumno agregado, la jornada pasada por parametro si ya contiene el alumno.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.Alumnos.Add(a);
            return j;
        }

        /// <summary>
        /// Devuelve todos los datos de la jornada.
        /// </summary>
        /// <returns>String con todos los datos.</returns>
        public override string ToString()
        {
            StringBuilder salida = new StringBuilder();
            salida.Append(string.Format("CLASE DE {0} POR ",  this.Clase));
            salida.Append(this.Instructor.ToString());
            salida.AppendLine("ALUMNOS:");
            foreach(Alumno a in this.Alumnos)
            {
                salida.AppendLine(a.ToString());
            }
            salida.AppendLine("<------------------------------------------------>");
            return salida.ToString();
        }

        /// <summary>
        /// Guarda un jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>True si puedo guardar, false en caso contrario.</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            return txt.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee una jornada de un archivo de texto.
        /// </summary>
        /// <returns>Datos leidos.</returns>
        public static string Leer()
        {
            string salida;
            Texto txt = new Texto();
            txt.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Jornada.txt", out salida);
            return salida;
        }
    }
}
