using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileServer.Common.Model;
using FileServer.Infrastructure.Repository_DAO_;
using System.Data;
using System.Collections.Generic;

namespace FileServer.Infrastructure.Repository_DAO_.Tests
{
    [TestClass()]
    public class AlumnoRepositoryTests
    {
        //IAlumnoRepository alumnoRepository = new AlumnoRepository();
        Alumno alumno = new Alumno
        {
            Id = 1,
            Nombre = "aaaa",
            Apellidos = "bbbb",
            DNI = "cccc"
        };


        List<Alumno> alumnoTest = new List<Alumno>();
        alumnoTest.add(alumno);
        [DataRow(alumnoTest)]

        [TestMethod()]
        public void RegistrarTest(Alumno alumno)
        {
            Assert.IsTrue(alumno.Equals(...));
        }
        
    }
}