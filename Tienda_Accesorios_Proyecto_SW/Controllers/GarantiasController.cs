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
    [RoutePrefix("api/Garantias")]
    [AllowAnonymous]
    public class GarantiasController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodas")]
        public List<Garantia> ConsultarTodas()
        {
            clsGarantia cls = new clsGarantia();
            return cls.ConsultarTodas();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Garantia Consultar(int id)
        {
            clsGarantia cls = new clsGarantia();
            return cls.Consultar(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Garantia garantia)
        {
            clsGarantia cls = new clsGarantia();
            cls.garantia = garantia;
            return cls.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Garantia garantia)
        {
            clsGarantia cls = new clsGarantia();
            cls.garantia = garantia;
            return cls.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            clsGarantia cls = new clsGarantia();
            return cls.Eliminar(id);
        }
    }
}