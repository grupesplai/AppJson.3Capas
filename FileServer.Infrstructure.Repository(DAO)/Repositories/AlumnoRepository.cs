using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using FileServer.Common.Model;
using System.Configuration;
using log4net;
using System.Reflection;

namespace FileServer.Infrastructure.Repository_DAO_
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Alumno Add(Alumno alum, string path)
        {
            StreamReader sr = null;
            try
            {
                log.Info("Clase alumno añade el alumno al json");
                List<Alumno> listaAlumno;
                //string path = getPath();

                if (File.Exists(path))
                {
                    using (sr = new StreamReader(path))
                    {
                        string read = sr.ReadToEnd();
                        listaAlumno = JsonConvert.DeserializeObject<List<Alumno>>(read);
                    }
                    listaAlumno.Add(alum);
                }
                else
                    listaAlumno = new List<Alumno> { alum };

                string alumJson = JsonConvert.SerializeObject(listaAlumno, Formatting.Indented);
                //List<Alumno> listaAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(File.ReadAllText(path));
                using (StreamWriter sw = File.CreateText(path))
                    sw.WriteLine(alumJson);
            }
            catch (JsonException e)
            {
                log.Error("There is exist a problem with json format." + e.Message);
                throw e;
            }
            return alum;
        }
    }
}
