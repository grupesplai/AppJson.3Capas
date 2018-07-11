using log4net;
using System;
using System.Reflection;
namespace FileServer.Infrstructure.Repository_DAO_.Manager
{
    class ExceptionManager
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static void ExceptionCaption(Exception excepcion)
        {
            log.Error("Ha ocurrido un problema al añadir el alumno: " + excepcion.Message);
            throw excepcion;
        }
    }
}
