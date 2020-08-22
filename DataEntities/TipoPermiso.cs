using System.Collections.Generic;

namespace WEPSYS_TEST.DataEntities
{
    public class TipoPermiso
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public List<Permiso> Posts { get; } = new List<Permiso>();
    }
}
