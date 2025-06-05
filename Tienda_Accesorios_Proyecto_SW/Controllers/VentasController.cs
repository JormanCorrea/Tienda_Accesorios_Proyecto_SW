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
    [RoutePrefix("api/Ventas")]
    public class VentasController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodas")]
        public List<Venta> ConsultarTodas()
        {
            clsVenta venta = new clsVenta();
            return venta.ConsultarTodas();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Venta Consultar(int id)
        {
            clsVenta venta = new clsVenta();
            return venta.Consultar(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Venta ventaObj)
        {
            clsVenta venta = new clsVenta();
            venta.venta = ventaObj;
            return venta.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Venta ventaObj)
        {
            clsVenta venta = new clsVenta();
            venta.venta = ventaObj;
            return venta.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            clsVenta venta = new clsVenta();
            return venta.Eliminar(id);
        }
    }
}