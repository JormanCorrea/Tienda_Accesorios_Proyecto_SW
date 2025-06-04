using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tienda_Accesorios_Proyecto_SW.Clases;
using Tienda_Accesorios_Proyecto_SW.Models;

namespace Tienda_Accesorios_Proyecto_SW.Controllers
{
    [RoutePrefix("api/Sedes")]
    [AllowAnonymous]
    public class SedesController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Sede> ConsultarTodos()
        {
            clsSede objSede = new clsSede();
            return objSede.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Sede Consultar(int id)
        {
            clsSede objSede = new clsSede();
            return objSede.Consultar(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Sede sede)
        {
            clsSede objSede = new clsSede();
            objSede.sede = sede;
            return objSede.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Sede sede)
        {
            clsSede objSede = new clsSede();
            objSede.sede = sede;
            return objSede.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            clsSede objSede = new clsSede();
            return objSede.Eliminar(id);
        }
    }
}