using Domain.DataAccess;


namespace DataAccess.Interface
{
    public interface IStoreProcedureRepository
    {

        Task AddInsertarUsuario(Usuario usuario);
        Task<List<UsuarioDB>> GetUsuariosPorEdad(int edad);
        Task<List<UsuarioDB>> GetUsuarioCreados();

    }
}
