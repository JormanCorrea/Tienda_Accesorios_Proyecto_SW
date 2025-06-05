using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Tienda_Accesorios_Proyecto_SW.Models;

namespace Tienda_Accesorios_Proyecto_SW.Clases
{
    public class clsVenta
    {
        private DBTiendaAccesoriosEntities dbTienda = new DBTiendaAccesoriosEntities();
        public Venta venta { get; set; }

        public string Insertar()
        {
            try
            {
                dbTienda.Ventas.Add(venta);
                dbTienda.SaveChanges();
                return $"Se registró la venta con ID {venta.IdVenta}";
            }
            catch (Exception ex)
            {
                return "Error al registrar la venta: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Venta ventaExistente = Consultar(venta.IdVenta);
                if (ventaExistente == null)
                    return "La venta no existe.";

                dbTienda.Ventas.AddOrUpdate(venta);
                dbTienda.SaveChanges();
                return "Venta actualizada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar la venta: " + ex.Message;
            }
        }

        public Venta Consultar(int id)
        {
            return dbTienda.Ventas.FirstOrDefault(v => v.IdVenta == id);
        }

        public List<Venta> ConsultarTodas()
        {
            return dbTienda.Ventas
                .OrderByDescending(v => v.FechaVenta)
                .ToList();
        }

        public string Eliminar(int id)
        {
            try
            {
                Venta venta = Consultar(id);
                if (venta == null)
                    return "La venta no existe.";

                dbTienda.Ventas.Remove(venta);
                dbTienda.SaveChanges();
                return "Venta eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar la venta: " + ex.Message;
            }
        }
    }
}