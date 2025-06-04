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
    [RoutePrefix("api/Proveedores")]
    //[Authorize]
    public class ProveedoresController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Proveedor> ConsultarTodos()
        {
            clsProveedor Proveedor = new clsProveedor();
            return Proveedor.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Proveedor ConsultarXDocumento(int IdProveedor)
        {
            clsProveedor Proveedor = new clsProveedor();
            return Proveedor.Consultar(IdProveedor);
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
        [Route("EliminarXId")]
        public string EliminarXId(int idProveedor)
        {
            clsProveedor Proveedor = new clsProveedor();
            return Proveedor.EliminarXId(idProveedor);
        }
    }
}