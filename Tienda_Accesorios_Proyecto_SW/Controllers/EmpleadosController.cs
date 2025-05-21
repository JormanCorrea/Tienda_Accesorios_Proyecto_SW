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
    [RoutePrefix("api/Empleados")]
    //[Authorize]
    public class EmpleadosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Empleado> ConsultarTodos()
        {
            clsEmpleado Empleado = new clsEmpleado();
            return Empleado.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Empleado Consultar(int IdEmpleado)
        {
            clsEmpleado Empleado = new clsEmpleado();
            return Empleado.Consultar(IdEmpleado);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Empleado empleado)
        {
            clsEmpleado Empleado = new clsEmpleado();
            Empleado.empleado = empleado;
            return Empleado.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Empleado empleado)
        {
            clsEmpleado Empleado = new clsEmpleado();
            Empleado.empleado = empleado;
            return Empleado.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int IdEmpleado)
        {
            clsEmpleado Empleado = new clsEmpleado();
            return Empleado.EliminarXDocumento(IdEmpleado);
        }
    }
}