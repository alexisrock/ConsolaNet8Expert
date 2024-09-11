using Domain.DataAccess;
using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IService
    {

        Task Run();
        Task AddInsertarUsuario(UsuarioIn usuarioIn);

        Task<List<UsuarioDBIn>> GetUsuarioCreados();

        Task<List<UsuarioDBIn>> GetUsuariosPorEdad(int edad);
    }
}
