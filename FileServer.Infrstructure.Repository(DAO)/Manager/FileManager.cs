using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using log4net;

namespace FileServer.Infrstructure.Repository_DAO_
{
    public class FileManager
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static string FilePath(int i)
        {
            string path = "";
            switch (i)
            {
                case 0:
                    log.Info("Elección del usuario: 'App.config'");
                    path = ConfigurationManager.AppSettings["path"];
                    break;
                case 1:
                    log.Info("Elección del usuario: 'Variable de Entorno'");
                    if (Environment.GetEnvironmentVariable("VUELING_HOME") == null)
                        Environment.SetEnvironmentVariable("VUELING_HOME", ConfigurationManager.AppSettings["pathEnVa"]);

                    string pathEnv = Environment.GetEnvironmentVariable("VUELING_HOME");
                    path = string.Concat(pathEnv, "\\alumnosJson-EV.json");
                    break;
            }
            return path;
        }
        //falta variable statica FILEPATH para te traiga el path completo. así NO
        //romper con DRY (dont repeat yoursef)
    }
}
