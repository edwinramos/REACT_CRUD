using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEPSYS_TEST.DataAccess.DataEntities;
using WEPSYS_TEST.DataAccess.BusinessLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEPSYS_TEST.Controllers
{
    [Route("[controller]")]
    public class CrudController : Controller
    {
        [HttpGet("getPermisos")]
        public JsonResult GetPermisos()
        {
            return Json(BlPermiso.GetPermisos().Select(x=>new 
            {
                x.Id,
                x.NombreEmpleado,
                x.ApellidosEmpleado,
                x.FechaPermiso,
                x.TipoPermisoId,
                TipoPermiso = BlTipoPermiso.GetTipoPermiso(x.TipoPermisoId).Descripcion
            }));
        }
        [HttpGet("getTiposPermiso")]
        public JsonResult GetTiposPermiso()
        {
            if (!BlTipoPermiso.GetTiposPermiso().Any())
            {
                BlTipoPermiso.SaveTipoPermiso(new DeTipoPermiso { Descripcion = "Diligencias" });
                BlTipoPermiso.SaveTipoPermiso(new DeTipoPermiso { Descripcion = "Enfermedad" });
            }
            return Json(BlTipoPermiso.GetTiposPermiso().Select(x=>new 
            {
                x.Id,
                x.Descripcion
            }));
        }

        [HttpGet("getPermiso/{id}")]
        public JsonResult Getpermiso(int id)
        {
            return Json(BlPermiso.GetPermiso(id));
        }

        [HttpPost("postPermiso")]
        public IActionResult PostPermiso([FromBody]DePermiso obj)
        {
            try
            {
                BlPermiso.SavePermiso(obj);

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
                BlPermiso.DeletePermiso(id);

                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
