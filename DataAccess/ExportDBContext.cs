using Domain.DataAccess;
using Microsoft.EntityFrameworkCore;



namespace DataAccess
{
    public class ExportDBContext : DbContext
    {
        public ExportDBContext(DbContextOptions<ExportDBContext> options) : base(options) { }


        public virtual DbSet<UsuarioDB> SpListarUsuariosCreados { get; set; }
        public virtual DbSet<UsuarioDB> SpListadoEdadUsuario { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UsuarioDB>().HasNoKey().ToView("Sp_ListarUsuariosCreados");
            modelBuilder.Entity<UsuarioDB>().HasNoKey().ToView("Sp_ListadoEdadUsuario");

        }
    }

}
