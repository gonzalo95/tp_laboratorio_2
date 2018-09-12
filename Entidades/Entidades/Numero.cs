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
            foreach(char digito in numero)
            {
                if (!char.IsDigit(digito))
                    return 0;
            }
            return Convert.ToDouble(numero);
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

        public string BinarioDecimal(string binario)
        {
            return Convert.ToInt32(binario, 2).ToString();
        }

        public string DecimalBinario(double numero)
        {
            return Convert.ToString(Convert.ToInt32(numero), 2);
        }

        public string DecimalBinario(string numero)
        {
            return Convert.ToString(Convert.ToInt32(numero), 2);
        }
    }
}
