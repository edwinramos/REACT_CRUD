using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEPSYS_TEST.DataAccess.DataEntities;

namespace WEPSYS_TEST.DataAccess.DataLayer
{
    public class DlTipoPermiso
    {
        public List<DeTipoPermiso> GetTiposPermiso()
        {
            using (var db = new TestContext())
            {
                return db.TipoPermisos.ToList();
            }
        }

        public DeTipoPermiso GetTipoPermiso(int id)
        {
            using (var db = new TestContext())
            {
                return db.TipoPermisos.FirstOrDefault(x => x.Id == id) ?? new DeTipoPermiso();
            }
        }
        public void SaveTipoPermiso(DeTipoPermiso obj)
        {
            using (var db = new TestContext())
            {
                if (db.TipoPermisos.Any(x => x.Id == obj.Id))
                {
                    var dbObj = db.TipoPermisos.FirstOrDefault(x => x.Id == obj.Id);
                    dbObj.Descripcion = obj.Descripcion;
                }
                else
                    db.Add(obj);

                db.SaveChanges();
            }
        }
    }
}
