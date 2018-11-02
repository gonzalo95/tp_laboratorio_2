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
