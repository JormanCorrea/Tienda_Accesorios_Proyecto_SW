using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Tienda_Accesorios_Proyecto_SW.Models;

namespace Tienda_Accesorios_Proyecto_SW.Clases
{
    public class clsGarantia
    {
        private DBTiendaAccesoriosEntities db = new DBTiendaAccesoriosEntities();
        public Garantia garantia { get; set; }

        public string Insertar()
        {
            try
            {
                db.Garantias.Add(garantia);
                db.SaveChanges();
                return "Garantía registrada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al registrar la garantía: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                var existente = Consultar(garantia.IdGarantia);
                if (existente == null) return "La garantía no existe.";

                db.Garantias.AddOrUpdate(garantia);
                db.SaveChanges();
                return "Garantía actualizada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar la garantía: " + ex.Message;
            }
        }

        public Garantia Consultar(int id)
        {
            return db.Garantias.FirstOrDefault(g => g.IdGarantia == id);
        }

        public List<Garantia> ConsultarTodas()
        {
            return db.Garantias.OrderByDescending(g => g.FechaInicioGarantia).ToList();
        }

        public string Eliminar(int id)
        {
            try
            {
                var garantia = Consultar(id);
                if (garantia == null) return "La garantía no existe.";

                db.Garantias.Remove(garantia);
                db.SaveChanges();
                return "Garantía eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar la garantía: " + ex.Message;
            }
        }
    }
}