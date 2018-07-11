using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using log4net;
using FileServer.Common.Model;
using System.IO;
using Newtonsoft.Json;
using FileServer.Infrstructure.Repository_DAO_.Manager;

namespace FileServer.Infrstructure.Repository_DAO_
{
    public class FileManager
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public static string FilePath(int enviroment, int extension)
        {
            string path = "";
            try
            {
                switch (enviroment)
                {
                    case 0:
                        path = string.Concat(ConfigurationManager.AppSettings["fileName"], GetExtesion(extension));
                        break;
                    case 1:
                        string pathEnv = Environment.GetEnvironmentVariable(ConfigurationManager.AppSettings["enviroment"]);
                        path = string.Concat(pathEnv, string.Concat(ConfigurationManager.AppSettings["fileName"], GetExtesion(extension)));
                        break;
                }
                log.Debug("Ruta escogida por el usuario: '" + path + "'");
            }
            catch (ArgumentException e){ ExceptionManager.ExceptionCaption(e);}
            catch (ConfigurationErrorsException e) {ExceptionManager.ExceptionCaption(e);}
            return path;
        }

        public static string GetExtesion(int extension)
        {
            string extensionSelected = "";
            try
            {
                switch (extension)
                {
                    case 0:
                        extensionSelected = ConfigurationManager.AppSettings["json"];
                        break;
                    case 1:
                        extensionSelected = ConfigurationManager.AppSettings["xml"];
                        break;
                    case 2:
                        extensionSelected = ConfigurationManager.AppSettings["txt"];
                        break;
                }
                log.Debug("Extensión elegida por usuario: '" + extensionSelected + "'");
            }
            catch(ConfigurationErrorsException e)
            {
                ExceptionManager.ExceptionCaption(e);
            }
            return extensionSelected;
        }
        public static void Validation(Alumno alumno, Alumno createdAlumno)
        {
            if (alumno.Equals(createdAlumno))
                log.Debug("Alumno creado correctamente: "+ createdAlumno.ToString());
            else
                log.Error("Error al crear el alumno: "+ createdAlumno.ToString());
        }

        public static List<Alumno> FileExists(Alumno alumno, string path)
        {
            StreamReader sr = null;
            List<Alumno> listaAlumno = null;
            try
            {
                if (File.Exists(path))
                {
                    log.Debug("Se crea fichero nuevo con ruta: " + path);
                    using (sr = new StreamReader(path))
                    {
                        string read = sr.ReadToEnd();
                        listaAlumno = JsonConvert.DeserializeObject<List<Alumno>>(read);
                    }
                    listaAlumno.Add(alumno);
                }else
                {
                    log.Debug("El fichero con ruta " + path + " ya existe, se reutiliza fichero.");
                    listaAlumno = new List<Alumno> { alumno };
                }
            }
            catch(OutOfMemoryException e) { ExceptionManager.ExceptionCaption(e); }
            catch (FileNotFoundException e) { ExceptionManager.ExceptionCaption(e); }
            return listaAlumno;
        }
    }
}
