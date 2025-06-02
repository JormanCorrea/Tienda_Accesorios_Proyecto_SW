using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Tienda_Accesorios_Proyecto_SW.Models;

namespace Tienda_Accesorios_Proyecto_SW.Clases
{
    public class clsPais
    {
        private DBTiendaAccesoriosEntities dbTienda = new DBTiendaAccesoriosEntities();
        public Pai pais { get; set; }

        public string Insertar()
        {
            try
            {
                dbTienda.Pais.Add(pais);
                dbTienda.SaveChanges();
                return "Se ingresó el país " + pais.NombrePais + " a la base de datos";
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
                Pai p = Consultar(pais.IdPais);
                if (p == null)
                {
                    return "El país no existe";
                }
                dbTienda.Pais.AddOrUpdate(pais);
                dbTienda.SaveChanges();
                return "Se actualizó el país " + pais.NombrePais + " correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar: " + ex.Message;
            }
        }

        public Pai Consultar(int IdPais)
        {
            Pai p = dbTienda.Pais.FirstOrDefault(pa => pa.IdPais == IdPais);
            return p;
        }

        public List<Pai> ConsultarTodos()
        {
            return dbTienda.Pais
                .OrderBy(pa => pa.NombrePais)
                .ToList();
        }

        public string EliminarXPais(int IdPais)
        {
            try
            {
                Pai p = Consultar(IdPais);
                if (p == null)
                {
                    return "El país no existe";
                }

                dbTienda.Pais.Remove(p);
                dbTienda.SaveChanges();
                return "País eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el país: " + ex.Message;
            }
        }
    }
}
