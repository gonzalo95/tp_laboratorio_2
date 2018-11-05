using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Genera un archivo de texto que almacena los datos pasados por parametro.
        /// </summary>
        /// <param name="archivo">Directorio del archivo.</param>
        /// <param name="datos">Variable a guardar.</param>
        /// <returns>True si pudo guardar el archivo, false en caso contrario.</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool salida = true;
            try
            {
                StreamWriter escritor = new StreamWriter(archivo);
                escritor.Write(datos);
                escritor.Close();
            }
            catch (Exception exc)
            {
                salida = false;
                throw new ArchivosException(exc);
            }
            return salida;
        }

        /// <summary>
        /// Recupera la informacion de un archivo de texto.
        /// </summary>
        /// <param name="archivo">Directorio del archivo</param>
        /// <param name="datos">Variable donde se almacenaran los datos</param>
        /// <returns>True si pudo leer el archivo, false en caso contrario.</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool salida = true;
            try
            {
                StreamReader lector = new StreamReader(archivo);
                datos = lector.ReadToEnd();
                lector.Close();
            }
            catch(Exception exc)
            {
                salida = false;
                throw new ArchivosException(exc);
            }
            return salida;
        }
    }
}
