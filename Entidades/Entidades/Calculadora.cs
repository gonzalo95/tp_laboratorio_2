using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Calculadora
    {
        /// <summary>
        /// Verifica que el operador sea valido.
        /// </summary>
        /// <param name="operador">Operador a validar.</param>
        /// <returns>Si es valido devuelve el mismo operador; caso contrario devuelve '+'.</returns>
        private static string ValidarOperador(string operador)
        {
            List<string> operadoresValidos = new List<string>() {"+", "-", "*", "/"};
            return operadoresValidos.Contains(operador) ? operador : "+";
        }

        /// <summary>
        /// Realiza una operacion matematica entre dos instancias de la clase Numero.
        /// </summary>
        /// <param name="num1">Primer operando.</param>
        /// <param name="num2">Segundo operando.</param>
        /// <param name="operador">Operacion a realizar; de ser invalida se la considerara suma.</param>
        /// <returns>Devuelve el resultado de la operacion.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            switch (ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;

                case "-":
                    resultado = num1 - num2;
                    break;

                case "*":
                    resultado = num1 * num2;
                    break;

                case "/":
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }
    }
}
