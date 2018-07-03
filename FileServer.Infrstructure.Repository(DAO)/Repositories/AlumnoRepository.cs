using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using FileServer.Common.Model;
using System.Configuration;

namespace FileServer.Infrastructure.Repository_DAO_
{
    public class AlumnoRepository : IAlumnoRepository
    {
      
        public Alumno Add(Alumno alum,string path)
        {
            try
            {
                List<Alumno> listaAlumno;
                //string path = getPath();

                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string read = sr.ReadToEnd();
                        listaAlumno = JsonConvert.DeserializeObject<List<Alumno>>(read);
                    }
                    listaAlumno.Add(alum);
                }
                else
                    listaAlumno = new List<Alumno>  { alum };

                Alumno alumno = new Alumno();
                    alumno.Id = 1;
                    alumno.Nombre = "aaaa";
                    alumno.Apellidos = "aaaa";
                    alumno.DNI = "aaaa";
                    
                string alumJson = JsonConvert.SerializeObject(listaAlumno, Formatting.Indented);

                List<Alumno> listaAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(File.ReadAllText(path));
                
                var matchedObject = from a in listaAlumnos
                                    where a.Equals(alumno)
                                    select a;
                Console.WriteLine(matchedObject.ToString());
                using (StreamWriter sw = File.CreateText(path))
                    sw.WriteLine(alumJson);
            }
            catch (JsonException e)
            {
                Console.WriteLine("Ha ocurrido un problema con el fichero.");
                Console.WriteLine(e.Message);
            }
            return alum;
        }
    }
}
