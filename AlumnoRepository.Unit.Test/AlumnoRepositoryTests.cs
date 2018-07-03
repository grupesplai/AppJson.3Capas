using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Configuration;
using FileServer.Common.Model;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FileServer.Infrastructure.Repository_DAO_.Tests
{
    [TestClass()]
    public class AlumnoRepositoryTests
    {
        private IAlumnoRepository mockObject;
        Alumno alumno = new Alumno();
        string path = ConfigurationManager.AppSettings["path"];

        [TestInitialize]
        public void Setup()
        {
            var mock = new Mock<IAlumnoRepository>();
            alumno.Id = 1;
            alumno.Nombre = "aaaa";
            alumno.Apellidos = "aaaa";
            alumno.DNI = "aaaa";

            mock.Setup(x => x.Add(alumno, path)).Returns(alumno);
            //Recupera el objeto mockado, con toda la configuracion realizada.
            mockObject = mock.Object;
        }
        [TestMethod()]
        public void RegistrarTest()
        {
            //mock al abjeto "encontrado"
            var result = mockObject.Add(alumno, path);
            Assert.AreEqual(alumno, result);
        }
    }
}