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

        public List<Profesor> Profesores
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


        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

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

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach(Profesor p in u.Profesores)
            {
                if(p == clase)
                    return p;
            }
            throw new SinProfesorException();
        }

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

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool salida = false;
            foreach(Profesor profesor in g.Profesores)
            {
                if(profesor == i)
                {
                    salida = true;
                    break;
                }
            }
            return salida;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Profesores)
            {
                if (p != clase)
                    return p;
            }
            throw new SinProfesorException();
        }

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

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
                throw new AlumnoRepetidoException();
            else
                u.Alumnos.Add(a);
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Profesores.Add(i);
            return u;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Universidad.xml", uni);
        }

        public static Universidad Leer()
        {
            Universidad salida;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Universidad.xml", out salida);
            return salida;
        }
    }
}
