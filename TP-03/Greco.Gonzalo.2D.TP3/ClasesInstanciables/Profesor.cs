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

        static Profesor()
        {
            random = new Random();
        }

        public Profesor() : this(0, "", "", "", 0) { }
        

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

    private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
        }

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

        protected override string MostrarDatos()
        {
            StringBuilder salida = new StringBuilder();
            salida.Append(base.MostrarDatos());
            salida.AppendLine(this.ParticiparEnClase());
            return salida.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

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

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
