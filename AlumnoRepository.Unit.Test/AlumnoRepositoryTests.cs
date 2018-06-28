using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Configuration;
using FileServer.Common.Model;
using System.Collections.Generic;
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

            mock.Setup(x => x.Registrar(alumno, path)).Returns(alumno);
            mockObject = mock.Object; //Recupera el objeto mockado, con toda la configuracion realizada.
        }
        [TestMethod()]
        public void RegistrarTest()
        {
            
            List<Alumno> listaAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(File.ReadAllText(path));

            Alumno matchAlumno = listaAlumnos.Find(o => o.Equals(alumno));
            mockObject.Registrar(matchAlumno, path);

            Assert.AreEqual(matchAlumno, alumno);
        }
    }
}