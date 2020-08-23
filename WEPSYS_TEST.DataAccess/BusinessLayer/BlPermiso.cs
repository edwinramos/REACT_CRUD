using System;
using System.Collections.Generic;
using System.Text;
using WEPSYS_TEST.DataAccess.DataEntities;
using WEPSYS_TEST.DataAccess.DataLayer;

namespace WEPSYS_TEST.DataAccess.BusinessLayer
{
    public static class BlPermiso
    {
        public static List<DePermiso> GetPermisos()
        {
            return new DlPermiso().GetPermisos();
        }

        public static DePermiso GetPermiso(int id)
        {
            return new DlPermiso().GetPermiso(id);
        }
        public static void SavePermiso(DePermiso obj)
        {
            new DlPermiso().SavePermiso(obj);
        }
        public static void DeletePermiso(int id)
        {
            new DlPermiso().DeletePermiso(id);
        }
    }
}
