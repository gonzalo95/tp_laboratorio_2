using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidaNombreApellido(value);
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidaNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder salida = new StringBuilder();
            salida.AppendLine(string.Format("NOMBRE COMPLETO: {0}, {1} ", this.Apellido, this.Nombre));
            salida.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            return salida.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException();
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (Int32.TryParse(dato, out dni))
                return ValidarDni(nacionalidad, dni);
            else
                throw new DniInvalidoException();
        }

        private string ValidaNombreApellido(string dato)
        {
            return Regex.IsMatch(dato, "[a-z A-Z]") ? dato : string.Empty;
        }
    }
}
