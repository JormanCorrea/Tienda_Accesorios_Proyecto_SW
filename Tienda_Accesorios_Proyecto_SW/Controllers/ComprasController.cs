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
    [RoutePrefix("api/Compras")]
    [AllowAnonymous]
    public class ComprasController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodas")]
        public List<Compra> ConsultarTodas()
        {
            clsCompra cls = new clsCompra();
            return cls.ConsultarTodas();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Compra Consultar(int id)
        {
            clsCompra cls = new clsCompra();
            return cls.Consultar(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Compra compra)
        {
            clsCompra cls = new clsCompra();
            cls.compra = compra;
            return cls.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Compra compra)
        {
            clsCompra cls = new clsCompra();
            cls.compra = compra;
            return cls.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            clsCompra cls = new clsCompra();
            return cls.Eliminar(id);
        }
    }
}