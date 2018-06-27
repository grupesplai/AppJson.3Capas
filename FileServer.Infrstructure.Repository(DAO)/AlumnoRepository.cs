using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using FileServer.Common.Model;

namespace FileServer.Infrastructure.Repository_DAO_
{
    public class AlumnoRepository : IALumnoRepository
    {
       // public static string path = @".\alumnosJson.json";
        public Alumno Registrar(Alumno alum)
        {
            try
            {
                List<Alumno> listaAlumno;

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
                {
                    listaAlumno = new List<Alumno>();
                    listaAlumno.Add(alum);
                }

                string alumJson = JsonConvert.SerializeObject(listaAlumno, Formatting.Indented);
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
