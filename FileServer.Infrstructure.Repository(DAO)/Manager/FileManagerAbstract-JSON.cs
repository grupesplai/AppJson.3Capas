using FileServer.Common.Model;
using FileServer.Infrstructure.Repository_DAO_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrstructure.Repository_DAO_.Manager
{
    class FileManagerAbstract_JSON : FileManagerAbstract
    {
        public override Alumno CreateFile(Alumno alumno, string path)
        {
            return alumno;
        }
    }
}
