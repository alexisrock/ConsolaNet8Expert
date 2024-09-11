
namespace Domain.DataAccess
{
    public class UsuarioDB 
    {
        public int id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int Edad { get; set; }
        public string? Correo { get; set; }
        public string? Hobbies { get; set; }
        public bool Activo { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

    }
}
