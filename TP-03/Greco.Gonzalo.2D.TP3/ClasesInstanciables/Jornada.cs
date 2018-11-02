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

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

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

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.Alumnos.Add(a);
            return j;
        }

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

        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            return txt.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Jornada.txt", jornada.ToString());
        }

        public static string Leer()
        {
            string salida;
            Texto txt = new Texto();
            txt.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Jornada.txt", out salida);
            return salida;
        }
    }
}
