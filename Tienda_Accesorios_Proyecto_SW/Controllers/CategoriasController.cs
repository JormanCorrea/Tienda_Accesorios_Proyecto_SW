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
    [Authorize]
    [RoutePrefix("api/Categorias")]
    public class CategoriasController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodas")]
        public List<Categoria> ConsultarTodas()
        {
            clsCategoria cls = new clsCategoria();
            return cls.ConsultarTodas();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Categoria Consultar(int id)
        {
            clsCategoria cls = new clsCategoria();
            return cls.Consultar(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Categoria categoria)
        {
            clsCategoria cls = new clsCategoria();
            cls.categoria = categoria;
            return cls.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Categoria categoria)
        {
            clsCategoria cls = new clsCategoria();
            cls.categoria = categoria;
            return cls.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            clsCategoria cls = new clsCategoria();
            return cls.Eliminar(id);
        }
    }
}
