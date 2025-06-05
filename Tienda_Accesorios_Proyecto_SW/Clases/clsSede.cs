using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Tienda_Accesorios_Proyecto_SW.Models;

namespace Tienda_Accesorios_Proyecto_SW.Clases
{
    public class clsSede
    {
        private DBTiendaAccesoriosEntities dbTienda = new DBTiendaAccesoriosEntities();
        public Sede sede { get; set; }

        public string Insertar()
        {
            try
            {
                dbTienda.Sedes.Add(sede);
                dbTienda.SaveChanges();
                return "Se ingresó la sede " + sede.NombreSede + " a la base de datos";
            }
            catch (Exception ex)
            {
                return "Error al insertar: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Sede sedeExistente = Consultar(sede.IdSede);
                if (sedeExistente == null)
                {
                    return "La sede no existe";
                }

                dbTienda.Sedes.AddOrUpdate(sede);
                dbTienda.SaveChanges();
                return "Se actualizó la sede " + sede.NombreSede + " correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar: " + ex.Message;
            }
        }

        public Sede Consultar(int id)
        {
            return dbTienda.Sedes.FirstOrDefault(s => s.IdSede == id);
        }

        public List<Sede> ConsultarTodos()
        {
            return dbTienda.Sedes
                .OrderBy(s => s.NombreSede)
                .ToList();
        }

        public string Eliminar(int id)
        {
            try
            {
                Sede sedeExistente = Consultar(id);
                if (sedeExistente == null)
                {
                    return "La sede no existe";
                }

                dbTienda.Sedes.Remove(sedeExistente);
                dbTienda.SaveChanges();
                return "Se eliminó la sede " + sedeExistente.NombreSede + " correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar: " + ex.Message;
            }
        }
    }
}