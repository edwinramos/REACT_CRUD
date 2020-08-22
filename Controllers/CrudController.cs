using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEPSYS_TEST.DataEntities;
using WEPSYS_TEST.DataLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEPSYS_TEST.Controllers
{
    [Route("[controller]")]
    public class CrudController : Controller
    {
        [HttpGet("getPermisos")]
        public JsonResult GetPermisos()
        {
            return Json(new DlPermiso().GetPermisos().Select(x=>new 
            {
                x.Id,
                x.NombreEmpleado,
                x.ApellidosEmpleado,
                x.FechaPermiso,
                x.TipoPermisoId,
                TipoPermiso = new DlTipoPermiso().GetTipoPermiso(x.TipoPermisoId).Descripcion
            }));
        }
        [HttpGet("getTiposPermiso")]
        public JsonResult GetTiposPermiso()
        {
            var dlTipoPermiso = new DlTipoPermiso();
            if (!dlTipoPermiso.GetTiposPermiso().Any())
            {
                dlTipoPermiso.SaveTipoPermiso(new TipoPermiso { Descripcion = "Diligencias" });
                dlTipoPermiso.SaveTipoPermiso(new TipoPermiso { Descripcion = "Enfermedad" });
            }
            return Json(dlTipoPermiso.GetTiposPermiso().Select(x=>new 
            {
                x.Id,
                x.Descripcion
            }));
        }

        [HttpGet("getPermiso/{id}")]
        public JsonResult Getpermiso(int id)
        {
            return Json(new DlPermiso().GetPermiso(id));
        }

        [HttpPost("postPermiso")]
        public IActionResult PostPermiso([FromBody]Permiso obj)
        {
            try
            {
                new DlPermiso().SavePermiso(obj);

                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletePermiso/{id}")]
        public IActionResult DeletePermiso(int id)
        {
            try
            {
                new DlPermiso().DeletePermiso(id);

                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
