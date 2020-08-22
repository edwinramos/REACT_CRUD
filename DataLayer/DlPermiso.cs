using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEPSYS_TEST.DataEntities;

namespace WEPSYS_TEST.DataLayer
{
    public class DlPermiso
    {
        public List<Permiso> GetPermisos()
        {
            using (var db = new TestContext())
            {
                return db.Permisos.ToList();
            }
        }

        public Permiso GetPermiso(int id)
        {
            using (var db = new TestContext())
            {
                return db.Permisos.FirstOrDefault(x => x.Id == id) ?? new Permiso { FechaPermiso = DateTime.Today };
            }
        }
        public void SavePermiso(Permiso obj)
        {
            using (var db = new TestContext())
            {
                if (db.Permisos.Any(x => x.Id == obj.Id))
                {
                    var dbObj = db.Permisos.FirstOrDefault(x => x.Id == obj.Id);
                    dbObj.NombreEmpleado = obj.NombreEmpleado;
                    dbObj.ApellidosEmpleado = obj.ApellidosEmpleado;
                    dbObj.TipoPermisoId = obj.TipoPermisoId;
                }
                else
                {
                    obj.FechaPermiso = DateTime.Today;
                    db.Add(obj);
                }
                db.SaveChanges();
            }
        }
        public void DeletePermiso(int id)
        {
            using (var db = new TestContext())
            {
                var dbObj = db.Permisos.FirstOrDefault(x => x.Id == id);
                db.Remove(dbObj);
                db.SaveChanges();
            }
        }
        
    }
}
