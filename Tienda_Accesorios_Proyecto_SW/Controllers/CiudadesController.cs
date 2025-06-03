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
    [RoutePrefix("api/Ciudades")]
    //[Authorize]
    public class CiudadesController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Ciudad> ConsultarTodos()
        {
            clsCiudad Ciudad = new clsCiudad();
            return Ciudad.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Ciudad Consultar(int IdCiudad)
        {
            clsCiudad Ciudad = new clsCiudad();
            return Ciudad.Consultar(IdCiudad);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Ciudad ciudad)
        {
            clsCiudad Ciudad = new clsCiudad();
            Ciudad.ciudad = ciudad;
            return Ciudad.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Ciudad ciudad)
        {
            clsCiudad Ciudad = new clsCiudad();
            Ciudad.ciudad = ciudad;
            return Ciudad.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int IdCiudad)
        {
            clsCiudad Ciudad = new clsCiudad();
            return Ciudad.EliminarXDocumento(IdCiudad);
        }
    }
}
