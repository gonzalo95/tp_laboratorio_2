using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using EntidadesAbstractas;
using Archivos;
using Excepciones;

namespace TP3Test
{
    [TestClass]
    public class Pruebas
    {
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestSinProfesor()
        {
            Profesor profesor = new Profesor(1, "Martin", "Campaña", "99999999", Persona.ENacionalidad.Extranjero);
            Universidad universidad = new Universidad();
            universidad += profesor;

            universidad += Universidad.EClases.Legislacion;
            universidad += Universidad.EClases.Laboratorio;
            universidad += Universidad.EClases.Programacion;
            universidad += Universidad.EClases.SPD;
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalido()
        {
            Profesor profesor2 = new Profesor(2, "Ariel", "Holan", "1223645.", Persona.ENacionalidad.Argentino);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoStringVacio()
        {
            Alumno alumno = new Alumno(3, "Fernando", "Gaibor", "", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoNull()
        {

            Alumno alumno = new Alumno(4, "Alan", "Franco", null, Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.Becado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestArchivosTextoLeer()
        {
            string aux;
            Texto txt = new Texto();
            txt.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), out aux);
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestArchivosXmlGuardar()
        {
            Alumno aux = new Alumno();
            Xml<Alumno> xml = new Xml<Alumno>();
            xml.Guardar("\\test.xml", aux);
        }

        [TestMethod]
        public void TestNoEsNullUniversidad()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Jornadas);
        }

        [TestMethod]
        public void TestValoresAlumno()
        {
            Alumno alumno = new Alumno(5, "Gaston", "Silva", "99999998", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);

            Assert.IsTrue(alumno.DNI == 99999998);
            Assert.IsTrue(alumno.Apellido == "Silva");
            Assert.IsTrue(alumno.Nombre == "Gaston");
            Assert.IsTrue(alumno.Nacionalidad == Persona.ENacionalidad.Extranjero);
        }

        [TestMethod]
        public void TestValoresProfesor()
        {
            Profesor profesor = new Profesor(6, "Emmanuel", "Gigliotti", "22222222", Persona.ENacionalidad.Argentino);

            Assert.IsTrue(profesor.Apellido == "Gigliotti");
            Assert.IsTrue(profesor.Nombre == "Emmanuel");
            Assert.IsTrue(profesor.Nacionalidad == Persona.ENacionalidad.Argentino);
            Assert.IsTrue(profesor.DNI == 22222222);
        }
    }
}
