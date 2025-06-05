using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Tienda_Accesorios_Proyecto_SW.Models;

namespace Tienda_Accesorios_Proyecto_SW.Clases
{
    public class clsCiudad
    {
        private DBTiendaAccesoriosEntities dbTienda = new DBTiendaAccesoriosEntities();
        public Ciudad ciudad { get; set; }

        public string Insertar()
        {
            try
            {
                dbTienda.Ciudads.Add(ciudad);
                dbTienda.SaveChanges();
                return "Se ingresó la ciudad " + ciudad.NombreCiudad + " a la base de datos";
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
                Ciudad ciu = Consultar(ciudad.IdCiudad);
                if (ciu == null)
                {
                    return "La ciudad no existe";
                }
                dbTienda.Ciudads.AddOrUpdate(ciudad);
                dbTienda.SaveChanges();
                return "Se actualizó la ciudad " + ciudad.NombreCiudad + " correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar: " + ex.Message;
            }
        }

        public Ciudad Consultar(int IdCiudad)
        {
            Ciudad ciu = dbTienda.Ciudads.FirstOrDefault(c => c.IdCiudad == IdCiudad);
            return ciu;
        }

        public List<Ciudad> ConsultarTodos()
        {
            return dbTienda.Ciudads
                .OrderBy(c => c.NombreCiudad)
                .ToList();
        }

        public string EliminarXDocumento(int IdCiudad)
        {
            try
            {
                Ciudad ciu = Consultar(IdCiudad);
                if (ciu == null)
                {
                    return "La ciudad no existe";
                }
                dbTienda.Ciudads.Remove(ciu);
                dbTienda.SaveChanges();
                return "Ciudad eliminada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar la ciudad: " + ex.Message;
            }
        }
    }
}
