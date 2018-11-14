using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesHechas;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void IdRepetido()
        {
            Correo correo = new Correo();
            Paquete paqueteUno = new Paquete("Mitre 470", "000-000-0001");
            Paquete paqueteDos = new Paquete("Mitre 750", "000-000-0001");
            correo += paqueteUno;
            correo += paqueteDos;
        }

        [TestMethod]
        public void PaquetesNoEsNull()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }
    }
}
