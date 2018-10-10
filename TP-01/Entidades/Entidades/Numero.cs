using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {
        private double numero;

        /// <summary>
        /// Asigna el valor de la variable 'numero'.
        /// </summary>
        private string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Verifica que un string sea la representacion de un numero valido.
        /// </summary>
        /// <param name="numero">String a validar.</param>
        /// <returns>Devuelve el numero que representa el string; 0 en caso de que sea un string invalido.</returns>
        private static double ValidarNumero(string numero)
        {
            double retorno;

            if (!Double.TryParse(numero, out retorno))
                retorno = 0;

            return retorno;
        }

        /// <summary>
        /// Constructor por defecto de la clase Numero.
        /// </summary>
        public Numero()
        { }

        /// <summary>
        /// Constructor parametrizado de la clase Numero.
        /// </summary>
        /// <param name="numero">El valor en formato double a asignar.</param>
        public Numero(double numero) : this(numero.ToString())
        { }

        /// <summary>
        /// Constructor parametrizado de la clase Numero.
        /// </summary>
        /// <param name="strNumero">El valor en formato string a asignar.</param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// Operador que permite sumar 2 instancias de la clase Numero.
        /// </summary>
        /// <param name="operando1">Primer operando.</param>
        /// <param name="operando2">Segundo operando.</param>
        /// <returns>El valor en formato double de la suma de los 2 numeros.</returns>
        public static double operator +(Numero operando1, Numero operando2)
        {
            return operando1.numero + operando2.numero;
        }

        /// <summary>
        /// Operador que permite restar 2 instancias de la clase Numero.
        /// </summary>
        /// <param name="operando1">Primer operando.</param>
        /// <param name="operando2">Segundo operando.</param>
        /// <returns>El valor en formato double de la resta de los 2 numeros.</returns>
        public static double operator -(Numero operando1, Numero operando2)
        {
            return operando1.numero - operando2.numero;
        }

        /// <summary>
        /// Operador que permite multiplicar 2 instancias de la clase Numero.
        /// </summary>
        /// <param name="operando1">Primer operando.</param>
        /// <param name="operando2">Segundo operando.</param>
        /// <returns>El valor en formato double del producto de los 2 numeros.</returns>
        public static double operator *(Numero operando1, Numero operando2)
        {
            return operando1.numero * operando2.numero;
        }

        /// <summary>
        /// Operador que permite dividir 2 instancias de la clase Numero.
        /// </summary>
        /// <param name="operando1">Primer operando.</param>
        /// <param name="operando2">Segundo operando.</param>
        /// <returns>El valor en formato double del cociente de los 2 numeros.</returns>
        public static double operator /(Numero operando1, Numero operando2)
        {
            return operando2.numero == 0 ? 0 : operando1.numero / operando2.numero;
        }

        /// <summary>
        /// Convierte un numero binario representado por un string en un numero decimal representado por un string.
        /// </summary>
        /// <param name="binario">String que representa un numero binario.</param>
        /// <returns>String convertido.</returns>
        public static string BinarioDecimal(string binario)
        {
            return Convert.ToInt32(binario, 2).ToString();
        }

        /// <summary>
        /// Convierte un numero decimal en un binario.
        /// </summary>
        /// <param name="numero">Numero decimal.</param>
        /// <returns>String que representa el numero convertido a binario.</returns>
        public static string DecimalBinario(double numero)
        {
            return Convert.ToString(Convert.ToInt32(numero), 2);
        }

        /// <summary>
        /// Convierte un numero decimal en un binario.
        /// </summary>
        /// <param name="numero">String que representa un numero decimal.</param>
        /// <returns>String que representa el numero convertido a binario.</returns>
        public static string DecimalBinario(string numero)
        {
            return Convert.ToString(Convert.ToInt32(numero), 2);
        }
    }
}
