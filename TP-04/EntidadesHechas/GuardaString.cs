using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EntidadesHechas
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo de extension de la clase string.
        /// Guarda el string en el archivo texto pasado por parametro.
        /// </summary>
        /// <param name="texto">String a guardar.</param>
        /// <param name="archivo">Path del archivo.</param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool salida = false;
            if (archivo != null)
            {
                StreamWriter escritor = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo, true);
                escritor.WriteLine(texto);
                salida = true;
                escritor.Close();
            }
            return salida;
        }
    }
}
