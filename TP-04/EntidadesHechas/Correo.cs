using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Excepciones;

namespace EntidadesHechas
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Paquete> paquetes;
        private List<Thread> mockPaquetes;

        public Correo()
        {
            paquetes = new List<Paquete>();
            mockPaquetes = new List<Thread>();
        }

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        #region Alumno

        /// <summary>
        /// a.	Controlar si el paquete ya está en la lista. En el caso de que esté, se lanzará la excepción TrackingIdRepetidoException.
        /// b.	Agregar el paquete a la lista de paquetes.
        /// c.	Crear un hilo para el método MockCicloDeVida del paquete, y agregar dicho hilo a mockPaquetes.
        /// d.	Ejecutar el hilo.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            try
            {
                foreach (Paquete paquete in c.Paquetes)
                {
                    if (paquete == p)
                        throw new TrackingIdRepetidoException(string.Format("El tracking ID {0} ya figura en la lista de envios.", p.TrackingID));
                }
                c.Paquetes.Add(p);
                Thread hilo = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(hilo);
                hilo.Start();
                return c;
            }
            catch (OperationCanceledException exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Utilizará string.Format con el siguiente formato "{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()
        /// para retornar los datos de todos los paquetes de su lista
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> l = (List<Paquete>)((Correo)elementos).paquetes;
            StringBuilder salida = new StringBuilder();
            foreach (Paquete p in l)
            {
                salida.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }
            return salida.ToString();
        }

        /// <summary>
        /// Cerrará todos los hilos ACTIVOS
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
            {
                if (hilo.IsAlive)
                    hilo.Abort();
            }
        }

        #endregion
    }
}
