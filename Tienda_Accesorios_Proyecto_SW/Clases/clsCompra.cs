using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Tienda_Accesorios_Proyecto_SW.Models;

namespace Tienda_Accesorios_Proyecto_SW.Clases
{
    public class clsCompra
    {
        private DBTiendaAccesoriosEntities db = new DBTiendaAccesoriosEntities();
        public Compra compra { get; set; }

        public string Insertar()
        {
            try
            {
                db.Compras.Add(compra);
                db.SaveChanges();
                return $"Compra registrada con ID {compra.IdCompra}";
            }
            catch (Exception ex)
            {
                return "Error al registrar la compra: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                var existente = Consultar(compra.IdCompra);
                if (existente == null)
                    return "La compra no existe.";

                db.Compras.AddOrUpdate(compra);
                db.SaveChanges();
                return "Compra actualizada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar: " + ex.Message;
            }
        }

        public Compra Consultar(int id)
        {
            return db.Compras.FirstOrDefault(c => c.IdCompra == id);
        }

        public List<Compra> ConsultarTodas()
        {
            return db.Compras.OrderByDescending(c => c.FechaCompra).ToList();
        }

        public string Eliminar(int id)
        {
            try
            {
                var compra = Consultar(id);
                if (compra == null) return "La compra no existe.";
                db.Compras.Remove(compra);
                db.SaveChanges();
                return "Compra eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar: " + ex.Message;
            }
        }
    }
}