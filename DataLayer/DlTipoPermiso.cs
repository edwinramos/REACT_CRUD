using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEPSYS_TEST.DataEntities;

namespace WEPSYS_TEST.DataLayer
{
    public class DlTipoPermiso
    {
        public List<TipoPermiso> GetTiposPermiso()
        {
            using (var db = new TestContext())
            {
                return db.TipoPermisos.ToList();
            }
        }

        public TipoPermiso GetTipoPermiso(int id)
        {
            using (var db = new TestContext())
            {
                return db.TipoPermisos.FirstOrDefault(x => x.Id == id) ?? new TipoPermiso();
            }
        }
        public void SaveTipoPermiso(TipoPermiso obj)
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
