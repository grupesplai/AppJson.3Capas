using FileServer.Common.Model;
namespace FileServer.Infrastructure.Repository_DAO_

{
    public interface IAlumnoRepository
    {
        Alumno Add(Alumno alum, string path);
    }
}
