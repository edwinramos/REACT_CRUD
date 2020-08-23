using System;
using System.Collections.Generic;
using System.Text;
using WEPSYS_TEST.DataAccess.DataEntities;
using WEPSYS_TEST.DataAccess.DataLayer;
namespace WEPSYS_TEST.DataAccess.BusinessLayer
{
    public static class BlTipoPermiso
    {
        public static List<DeTipoPermiso> GetTiposPermiso()
        {
            return new DlTipoPermiso().GetTiposPermiso();
        }

        public static DeTipoPermiso GetTipoPermiso(int id)
        {
            return new DlTipoPermiso().GetTipoPermiso(id);
        }
        public static void SaveTipoPermiso(DeTipoPermiso obj)
        {
            new DlTipoPermiso().SaveTipoPermiso(obj);
        }
    }
}
