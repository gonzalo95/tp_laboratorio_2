using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Jornada> Jornada
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
                if (i >= 0 && i < this.Jornada.Count)
                    return this.Jornada[i];
                else
                    throw new IndexOutOfRangeException("Indice fuera de rango");
            }
            set
            {
                if (i >= 0 && i < this.Jornada.Count)
                    this.Jornada[i] = value;
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
            salida.AppendLine("Alumnos:");
            foreach (Alumno a in this.Alumnos)
            {
                salida.Append(a.ToString());
            }
            salida.AppendLine("Jornadas:");
            foreach (Jornada j in this.Jornada)
            {
                salida.Append(j.ToString());
            }
            salida.AppendLine("Profesores:");
            foreach (Profesor p in this.Profesores)
            {
                salida.Append(p.ToString());
            }
            return salida.ToString();
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

        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
