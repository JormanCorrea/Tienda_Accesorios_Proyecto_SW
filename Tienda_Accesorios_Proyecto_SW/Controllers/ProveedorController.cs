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
    [RoutePrefix("api/cliente")]
    //[Authorize]
    public class ProveedorController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Proveedor> ConsultarTodos()
        {
            clsProveedor Proveedor = new clsProveedor();
            return Proveedor.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXDocumento")]
        public Proveedor ConsultarXDocumento(int Documento)
        {
            clsProveedor Proveedor = new clsProveedor();
            return Proveedor.Consultar(Documento);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Proveedor proveedor)
        {
            clsProveedor Proveedor = new clsProveedor();
            Proveedor.proveedor = proveedor;
            return Proveedor.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Proveedor proveedor)
        {
            clsProveedor Proveedor = new clsProveedor();
            Proveedor.proveedor = proveedor;
            return Proveedor.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Proveedor proveedor)
        {
            clsProveedor Proveedor = new clsProveedor();
            Proveedor.proveedor = proveedor;
            return Proveedor.Eliminar();
        }

        [HttpDelete]
        [Route("EliminarXDocumento")]
        public string EliminarXDocumento(int Documento)
        {
            clsProveedor Proveedor = new clsProveedor();
            return Proveedor.EliminarXDocumento(Documento);
        }
    }
}