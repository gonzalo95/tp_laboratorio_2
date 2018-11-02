using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Excepciones;
using System.Xml;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool salida = true;
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                XmlTextWriter escritor = new XmlTextWriter(archivo, Encoding.UTF8);
                serializador.Serialize(escritor, datos);
                escritor.Close();
            }
            catch(Exception exc)
            {
                salida = false;
                throw new ArchivosException(exc);
            }
            return salida;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool salida = true;
            try
            {
                XmlSerializer serilaizador = new XmlSerializer(typeof(T));
                XmlTextReader lector = new XmlTextReader(archivo);
                datos = (T)serilaizador.Deserialize(lector);
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
