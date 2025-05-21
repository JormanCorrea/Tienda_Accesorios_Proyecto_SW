using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Tienda_Accesorios_Proyecto_SW.Models;

namespace Tienda_Accesorios_Proyecto_SW.Clases
{
    public class clsProducto
    {
        private DBTiendaAccesoriosEntities dbTienda = new DBTiendaAccesoriosEntities();
        public Producto producto { get; set; }

        public string Insertar()
        {
            try
            {
                dbTienda.Productoes.Add(producto);
                dbTienda.SaveChanges();
                return "Se ingresó el producto " + producto.NombreProducto + " a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Producto prod = Consultar(producto.CodigoSKU);
                if (prod == null)
                {
                    return "El producto no existe";
                }

                dbTienda.Productoes.AddOrUpdate(producto);
                dbTienda.SaveChanges();
                return "Se actualizó el producto " + producto.NombreProducto+ " correctamente";
            }
            catch (Exception ex)
            {
                return  "Error al  Actualizar" + ex.Message;
            }
        }

        public Producto Consultar(int codigo)
        {
            Producto prod = dbTienda.Productoes.FirstOrDefault(p => p.CodigoSKU == codigo);
            return prod;
        }

        public List<Producto> ConsultarTodos()
        {
            return dbTienda.Productoes
                .OrderBy(p => p.NombreProducto)
                .ToList();
        }

        

        public string Eliminar(int codigo)
        {
            try
            {
                Producto prod = Consultar(codigo);
                if (prod == null)
                {
                    return "El producto no existe";
                }

                dbTienda.Productoes.Remove(prod);
                dbTienda.SaveChanges();
                return "Se eliminó el producto " + prod.NombreProducto + " correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}