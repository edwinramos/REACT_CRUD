using System.Collections.Generic;

namespace WEPSYS_TEST.DataAccess.DataEntities
{
    public class DeTipoPermiso
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public List<DePermiso> Posts { get; } = new List<DePermiso>();
    }
}
