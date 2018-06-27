using FileServer.Common.Model;
namespace FileServer.Infrastructure.Repository_DAO_

{
    public interface IAlumnoRepository
    {
        Alumno Registrar(Alumno alum, string path);
    }
}
