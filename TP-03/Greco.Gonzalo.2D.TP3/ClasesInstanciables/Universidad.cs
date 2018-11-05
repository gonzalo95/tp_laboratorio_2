using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Entidades
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

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
        /// Propiedad de lectura y escritura del campo jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del campo profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Indexador del campo jornadas.
        /// Permite manipular el campo jornadas mediante indices.
        /// </summary>
        /// <param name="i">Indice.</param>
        /// <returns>Elemento en el indice i, de ser un indice invalido lanza IndexOutOfRangeException.</returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Jornadas.Count)
                    return this.Jornadas[i];
                else
                    throw new IndexOutOfRangeException("Indice fuera de rango");
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                    this.Jornadas[i] = value;
                else
                    throw new IndexOutOfRangeException("Indice fuera de rango");
            }
        }

        /// <summary>
        /// Constructor sin parametros de la clase Universidad.
        /// Inicializa todos los campos.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        /// <summary>
        /// Devuelve todos los datos de la universidad.
        /// </summary>
        /// <returns>String con todos los datos.</returns>
        private string MostrarDatos()
        {
            StringBuilder salida = new StringBuilder();
            foreach (Jornada j in this.Jornadas)
            {
                salida.AppendLine("JORNADA:");
                salida.Append(j.ToString());
            }
            return salida.ToString();
        }

        /// <summary>
        /// Operador que devuelve un profesor que pueda dar la clase.
        /// </summary>
        /// <param name="u">Universidad a comparar.</param>
        /// <param name="clase">clase a comparar.</param>
        /// <returns>Primer profesor valido, de no existir lanza SinProfesorException.</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach(Profesor p in u.Instructores)
            {
                if(p == clase)
                    return p;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Operador que nos permite comparar una universidad con un alumno.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>True si el alumno pertenece a la universidad, false en caso contrario.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool salida = false;
            foreach(Alumno alumno in g.Alumnos)
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
        /// Operador que nos permite comparar una universidad con un profesor.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="i">Profesor a comparar.</param>
        /// <returns>True si el profesor pertenece a la universidad, false en caso contrario.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool salida = false;
            foreach(Profesor profesor in g.Instructores)
            {
                if(profesor == i)
                {
                    salida = true;
                    break;
                }
            }
            return salida;
        }

        /// <summary>
        /// Operador que nos permite comparar una universidad con un alumno.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>True si el alumno no pertenece a la universidad, false en caso contrario.</returns>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Operador que nos permite comparar una universidad con un profesor.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="i">Profesor a comparar.</param>
        /// <returns>True si el profesor no pertenece a la universidad, false en caso contrario.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// Operador que devuelve un profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u">Universidad a comparar.</param>
        /// <param name="clase">clase a comparar.</param>
        /// <returns>Primer profesor invalido para dar la clase, de no existir lanza SinProfesorException.</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p != clase)
                    return p;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Operador que permite agregar una clase a una universidad.
        /// </summary>
        /// <param name="g">Universidad.</param>
        /// <param name="clase">Clase a agregar.</param>
        /// <returns>Devuelve una universidad con la clase agregada, de no ser posible devuevlve el dato pasado por parametro.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada j = new Jornada(clase, g == clase);
            foreach (Alumno a in g.Alumnos)
            {
                if (a == clase)
                    j.Alumnos.Add(a);
            }
            g.Jornadas.Add(j);
            return g;
        }

        /// <summary>
        /// Operador que permite agregar un alumno a una universidad.
        /// </summary>
        /// <param name="g">Universidad.</param>
        /// <param name="a">Alumno a agregar.</param>
        /// <returns>Devuelve una universidad con el alumno agregado, de no ser posible devuevlve el dato pasado por parametro.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
                throw new AlumnoRepetidoException();
            else
                u.Alumnos.Add(a);
            return u;
        }

        /// <summary>
        /// Operador que permite agregar un profesor a una universidad.
        /// </summary>
        /// <param name="g">Universidad.</param>
        /// <param name="i">profesor a agregar.</param>
        /// <returns>Devuelve una universidad con el profesor agregada, de no ser posible devuevlve el dato pasado por parametro.</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);
            return u;
        }

        /// <summary>
        /// Devuelve todos los datos de la universidad.
        /// </summary>
        /// <returns>String con todos los datos.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Guarda los datos en un archivo xml.
        /// </summary>
        /// <param name="uni">Universidad a guardar.</param>
        /// <returns>True si se pudo guardar, false en caso contrario.</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Universidad.xml", uni);
        }

        /// <summary>
        /// Lee los datos de un archivo xml.
        /// </summary>
        /// <returns>True si se pudo leer, false en caso contrario.</returns>
        public static Universidad Leer()
        {
            Universidad salida;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Universidad.xml", out salida);
            return salida;
        }
    }
}
