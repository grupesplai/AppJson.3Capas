using FileServer.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrstructure.Repository_DAO_.Interfaces
{
    public abstract class FileManagerAbstract
    {
        public virtual Alumno CreateFile(Alumno alumno, string path)
        {
            return alumno;
        }
    }
}
