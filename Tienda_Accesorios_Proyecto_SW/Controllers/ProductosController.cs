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
    [RoutePrefix("api/Productos")]
    //[Authorize]
    public class ProductosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Producto> ConsultarTodos()
        {
            clsProducto Producto = new clsProducto();
            return Producto.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Producto Consultar(int codigo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.Consultar(codigo);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Producto producto)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = producto;
            return Producto.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Producto producto)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = producto;
            return Producto.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int codigo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.Eliminar(codigo);
        }

    }
}