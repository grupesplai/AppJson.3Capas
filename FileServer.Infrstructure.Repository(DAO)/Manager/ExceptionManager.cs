using log4net;
using System;
using System.Reflection;
namespace FileServer.Infrstructure.Repository_DAO_.Manager
{
    class VuelingException : Exception
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public VuelingException(string message, Exception inner)
            : base(message, inner)
        {
            log.Error("Ha ocurrido un problema al añadir el alumno: " + message.ToString());
            log.Error(inner.ToString());
        }
    }
}
