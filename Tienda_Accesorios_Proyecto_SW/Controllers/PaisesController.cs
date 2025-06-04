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
    [RoutePrefix("api/Paises")]
    [AllowAnonymous]
    public class PaisesController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Pai> ConsultarTodos()
        {
            clsPais Pais = new clsPais();
            return Pais.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Pai Consultar(int IdPais)
        {
            clsPais Pais = new clsPais();
            return Pais.Consultar(IdPais);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Pai pais)
        {
            clsPais Pais = new clsPais();
            Pais.pais = pais;
            return Pais.Insertar();

        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Pai pais)
        {
            clsPais Pais = new clsPais();
            Pais.pais = pais;
            return Pais.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int IdPais)
        {
            clsPais pais = new clsPais();
            return pais.EliminarXPais(IdPais);
        }
    }
}
