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

        /// <summary>
        /// Propiedad de lectura y escritura del campo nombre.
        /// Valida que el nombre sea valido antes de asignarlo.
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura y escritura del campo apellido.
        /// Valida que el apellido sea valido antes de asignarlo.
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura y escritura del campo dni.
        /// Valida que el dni sea valido antes de asignarlo.
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura y escritura del campo nacionalidad.
        /// </summary>
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

        /// <summary>
        /// Propiedad de solo escritura del campo dni.
        /// Permite asignar un dni mediante un dato del tipo string.
        /// Valida que el dni sea valido antes de asignarlo.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Constructor sin parametros de la clase Persona.
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Constructor de la clase Persona.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de la clase Persona.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">Dni de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor de la clase Persona.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">Dni de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Devuelve un string con los datos de la persona.
        /// </summary>
        /// <returns>Todos los datos de la persona.</returns>
        public override string ToString()
        {
            StringBuilder salida = new StringBuilder();
            salida.AppendLine(string.Format("NOMBRE COMPLETO: {0}, {1} ", this.Apellido, this.Nombre));
            salida.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            return salida.ToString();
        }

        /// <summary>
        /// Valida que el entero ingresado sea un dni valido para la nacionalidad ingresada.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">Dni a validar.</param>
        /// <returns>El dato ingresado si es valido, en caso contrario lanza una NacionalidadInvalidaException</returns>
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

        /// <summary>
        /// Valida que el string ingresado sea un dni valido para la nacionalidad ingresada.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">Dni a validar.</param>
        /// <returns>El dato ingresado en formato int si es valido, en caso contrario lanza una DniInvalidoException</returns>
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
