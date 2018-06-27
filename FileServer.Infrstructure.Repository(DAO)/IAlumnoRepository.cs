using FileServer.Common.Model;
namespace FileServer.Infrastructure.Repository_DAO_

{
    public interface IALumnoRepository
    {
        Alumno Registrar(Alumno alum, string path);
    }
}
