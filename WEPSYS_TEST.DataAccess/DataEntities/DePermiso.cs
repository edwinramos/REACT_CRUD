using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEPSYS_TEST.DataAccess.DataEntities
{
    public class DePermiso
    {
        [Key]
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public DateTime FechaPermiso { get; set; }

        public int TipoPermisoId { get; set; }
        public DeTipoPermiso TipoPermiso { get; set; }
    }
}
