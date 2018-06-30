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
        Alumno alumnoFound;
        string path = ConfigurationManager.AppSettings["path"];

        [TestInitialize]
        public void Setup()
        {
            var mock = new Mock<IAlumnoRepository>();
            alumno.Id = 1;
            alumno.Nombre = "aaaa";
            alumno.Apellidos = "aaaa";
            alumno.DNI = "aaaa";

            mock.Setup(x => x.Add(alumnoFound, path)).Returns(alumno);
            //Recupera el objeto mockado, con toda la configuracion realizada.
            mockObject = mock.Object;
        }
        [TestMethod()]
        public void RegistrarTest()
        {
            
            List<Alumno> listaAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(File.ReadAllText(path));
            // de la lista buscamos el objeto alumno
            Alumno matchAlumno = listaAlumnos.Find(o => o.Equals(alumno));
            //mock al abjeto "encontrado"
            alumnoFound = mockObject.Add(matchAlumno, path);

            Assert.AreEqual(alumnoFound, alumno);
        }
    }
}