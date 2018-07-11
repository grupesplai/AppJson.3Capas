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
        public static string FilePath(int enviroment, int extension)
        {
            string path = "";
            switch (enviroment)
            {
                case 0:
                    path = ConfigurationManager.AppSettings["fileName"]+GetExtesion(extension);
                    break;
                case 1:
                    //if (Environment.GetEnvironmentVariable("VUELING_HOME") == null)
                    //    Environment.SetEnvironmentVariable("VUELING_HOME", ConfigurationManager.AppSettings["pathEnVa"]);

                    string pathEnv = Environment.GetEnvironmentVariable(ConfigurationManager.AppSettings["enviroment"]);
                    path = string.Concat(pathEnv, string.Concat(ConfigurationManager.AppSettings["fileName"], GetExtesion(extension)));
                    break;
            }
            log.Info("Elección del usuario: '"+enviroment+"'");
            return path;
        }
        //falta variable statica FILEPATH para te traiga el path completo. así NO
        //romper con DRY (dont repeat yoursef)

        public static string GetExtesion(int extension)
        {
            string extensionSelected = "";
            switch (extension)
            {
                case 0:
                    extensionSelected = ConfigurationManager.AppSettings["json"];
                    break;
                case 1:
                    extensionSelected = ConfigurationManager.AppSettings["xml"];
                    break;
                case 3:
                    extensionSelected = ConfigurationManager.AppSettings["txt"];
                    break;
            }
            log.Info("Extensión elegida por usuario: '"+extensionSelected+"'");
            return extensionSelected;
        }
    }
}
