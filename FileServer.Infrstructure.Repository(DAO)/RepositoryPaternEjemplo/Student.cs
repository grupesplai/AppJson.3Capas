using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrstructure.Repository_DAO_.RepositoryPaternEjemplo
{
    public class Student : EntityModel
    {
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
    }
}
