using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Tienda_Accesorios_Proyecto_SW.Models;

namespace Tienda_Accesorios_Proyecto_SW.Clases
{
    public class clsProveedor
    {
        private DBTiendaAccesoriosEntities dbTienda = new DBTiendaAccesoriosEntities();
        public Proveedor proveedor { get; set; }

        public string Insertar()
        {
            try
            {
                dbTienda.Proveedors.Add(proveedor);
                dbTienda.SaveChanges();
                return $"{proveedor.NombreProveedor} insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el proveedor: " + ex.Message;
            }
        }

        public Proveedor Consultar(int IdProveedor)
        {
            Proveedor prov = dbTienda.Proveedors.FirstOrDefault(e => e.IdProveedor == IdProveedor);
            return prov;
        }

        public string Actualizar()
        {
            try
            {
                Proveedor prov = Consultar(proveedor.IdProveedor);
                if (prov == null)
                {
                    return "Proveedor no existe";
                }
                dbTienda.Proveedors.AddOrUpdate(proveedor);
                dbTienda.SaveChanges();
                return "Proveedor actualizado correctamente";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar el proveedor {proveedor.NombreProveedor} : " + ex.Message;
            }
        }

        public string Eliminar()
        {
            try
            {
                Proveedor prov = Consultar(proveedor.IdProveedor);
                if (prov == null)
                {
                    return "Proveedor no existe";
                }
                dbTienda.Proveedors.Remove(proveedor);
                dbTienda.SaveChanges();
                return $"{proveedor.NombreProveedor} eliminado correctamente";

            }
            catch (Exception ex)
            {
                return "Error al eliminar el proveedor: " + ex.Message;
            }
        }

        public List<Proveedor> ConsultarTodos()
        {
            return dbTienda.Proveedors
                .OrderBy(e => e.NombreProveedor)
                .ToList();
        }

        public string EliminarXId(int IdProveedor)
        {
            try
            {
                Proveedor prov = Consultar(IdProveedor);
                if (prov == null)
                {
                    return "Proveedor no existe";
                }

                dbTienda.Proveedors.Remove(prov);
                dbTienda.SaveChanges();
                return "Proveedor eliminado correctamente";

            }
            catch (Exception ex)
            {
                return "Error al eliminar el proveedor: " + ex.Message;
            }
        }
    }
}