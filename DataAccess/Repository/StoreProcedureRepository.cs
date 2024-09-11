using DataAccess.Interface;
using Domain.DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class StoreProcedureRepository : IStoreProcedureRepository
    {
        private readonly ExportDBContext exportDBContext;


        public StoreProcedureRepository(ExportDBContext _exportDBContext)
        {
             exportDBContext = _exportDBContext;
            
        }
        public async Task AddInsertarUsuario(Usuario usuario)
        {
            await exportDBContext.Database.ExecuteSqlRawAsync("EXEC Sp_InsertarUsuario @Nombre, @Apellido, @Edad, @Correo,  @Hobbies   ", new SqlParameter("@Nombre", usuario.Nombre), new SqlParameter("@Apellido", usuario.Apellido), new SqlParameter("@Edad", usuario.Edad), new SqlParameter("@Correo", usuario.Correo), new SqlParameter("@Hobbies", usuario.Hobbies));

        }

        public async Task<List<UsuarioDB>> GetUsuarioCreados()
        {
            var listUsuarioDB = await exportDBContext.SpListarUsuariosCreados.FromSqlRaw(" EXEC  Sp_ListarUsuariosCreados  ").ToListAsync();
            return listUsuarioDB;
        }

        public async Task<List<UsuarioDB>> GetUsuariosPorEdad(int edad)
        {
            var listUsuarioDB = await exportDBContext.SpListadoEdadUsuario.FromSqlRaw(" EXEC  Sp_ListadoEdadUsuario @Edad", new SqlParameter("@Edad", edad)).ToListAsync();
            return listUsuarioDB;
        }
    }
}
