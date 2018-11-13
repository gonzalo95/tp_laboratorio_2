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
        public static bool Guardar(this string texto, string archivo)
        {
            bool salida = false;
            if (archivo != null)
            {
                StreamWriter escritor = new StreamWriter(Environment.SpecialFolder.Desktop + "\\" + archivo, true);
                escritor.WriteLine(texto);
                salida = true;
                escritor.Close();
            }
            return salida;
        }
    }
}
