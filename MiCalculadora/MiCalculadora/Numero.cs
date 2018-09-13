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

        private void SetNumero(string numero)
        {
            this.numero = ValidarNumero(numero);
        }

        private static double ValidarNumero(string numero)
        {
            double retorno;

            if (!Double.TryParse(numero, out retorno))
                retorno = 0;

            return retorno;
        }

        public Numero()
        {

        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            SetNumero(strNumero);
        }

        public static double operator +(Numero operando1, Numero operando2)
        {
            return operando1.numero + operando2.numero;
        }

        public static double operator -(Numero operando1, Numero operando2)
        {
            return operando1.numero - operando2.numero;
        }

        public static double operator *(Numero operando1, Numero operando2)
        {
            return operando1.numero * operando2.numero;
        }

        public static double operator /(Numero operando1, Numero operando2)
        {
            return operando2.numero == 0 ? 0 : operando1.numero / operando2.numero;
        }

        public static string BinarioDecimal(string binario)
        {
            return Convert.ToInt32(binario, 2).ToString();
        }

        public static string DecimalBinario(double numero)
        {
            return Convert.ToString(Convert.ToInt32(numero), 2);
        }

        public static string DecimalBinario(string numero)
        {
            return Convert.ToString(Convert.ToInt32(numero), 2);
        }
    }
}
