using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interfaz generica para manipulacion de archivos.
    /// </summary>
    /// <typeparam name="T">Tipo de dato a manipular.</typeparam>
    public interface IArchivo<T>
    {
        /// <summary>
        /// Genera un archivo que contiene los datos pasados por parametro.
        /// </summary>
        /// <param name="archivo">Directorio dels archivo.</param>
        /// <param name="datos">Variable a guardar.</param>
        /// <returns>True si pudo guardar el archivo, false en caso contrario.</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Recupera los datos de un archivo.
        /// </summary>
        /// <param name="archivo">Directorio del archivo.</param>
        /// <param name="datos">Variable donde se almacenaran los datos leidos</param>
        /// <returns>True si pudo leer el archivo, false en caso contrario.</returns>
        bool Leer(string archivo, out T datos);
    }
}
