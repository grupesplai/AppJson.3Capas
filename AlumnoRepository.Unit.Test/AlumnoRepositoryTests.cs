using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Configuration;
using FileServer.Infrastructure.Repository_DAO_;
using FileServer.Common.Model;
using System.Collections.Generic;

namespace FileServer.Infrastructure.Repository_DAO_.Tests
{
    [TestClass()]
    public class AlumnoRepositoryTests
    {
        private IAlumnoRepository mockObject;

        [TestInitialize]
        public void Setup()
        {
            var mock = new Mock<IAlumnoRepository>();
            Alumno al = new Alumno
            {
                Id = 1,
                Nombre = "aaaa",
                Apellidos = "bbbb cccc",
                DNI = "1234567890A"
            };
            mock.Setup(x => x.Registrar(al, ConfigurationManager.AppSettings["path"])).Returns(al);
            mockObject = mock.Object; //Recupera el objeto mockado, con toda la configuracion realizada.
        }
        [TestMethod()]
        public void RegistrarTest()
        {
            List<Alumno> alumnoEnLista =  mockObject.Registrar(al, ConfigurationManager.AppSettings["path"]);

            Assert.AreEqual(alumnoEnLista, result);
        }
    }
}