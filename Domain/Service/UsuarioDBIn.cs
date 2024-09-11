using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public  class UsuarioDBIn: UsuarioIn
    {
        public int id { get; set; }
        public bool Activo { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
