using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using FileServer.Common.Model;
using log4net;
using System.Reflection;
using FileServer.Infrstructure.Repository_DAO_.Manager;
using FileServer.Infrstructure.Repository_DAO_;

namespace FileServer.Infrastructure.Repository_DAO_
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public AlumnoRepository()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        public Alumno Add(Alumno alumno, string path)
        {
            log.Debug("Alumno a añadir: " + alumno.ToString());
            log.Debug("Con ruta: " + path);
            
            try
            {
                log.Debug("Agregando alumno al fichero con ruta: " + path);
                List<Alumno> listaAlumno = FileManager.FileExists(alumno, path);
                string alumJson = JsonConvert.SerializeObject(listaAlumno, Formatting.Indented);
                //List<Alumno> listaAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(File.ReadAllText(path));
                using (StreamWriter sw = File.CreateText(path))
                    sw.WriteLine(alumJson);
            }
            catch (JsonException e)
            {
                ExceptionManager.ExceptionCaption(e);
            }
            return alumno;
        }
    }
}
