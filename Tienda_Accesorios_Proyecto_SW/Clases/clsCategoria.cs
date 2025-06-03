using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Tienda_Accesorios_Proyecto_SW.Models;

namespace Tienda_Accesorios_Proyecto_SW.Clases
{
    public class clsCategoria
    {
        private DBTiendaAccesoriosEntities db = new DBTiendaAccesoriosEntities();
        public Categoria categoria { get; set; }

        public string Insertar()
        {
            try
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();
                return "Categoría registrada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al registrar la categoría: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                var existente = Consultar(categoria.IdCategoria);
                if (existente == null) return "La categoría no existe.";

                db.Categorias.AddOrUpdate(categoria);
                db.SaveChanges();
                return "Categoría actualizada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar la categoría: " + ex.Message;
            }
        }

        public Categoria Consultar(int id)
        {
            return db.Categorias.FirstOrDefault(c => c.IdCategoria == id);
        }

        public List<Categoria> ConsultarTodas()
        {
            return db.Categorias.OrderBy(c => c.NombreCategoria).ToList();
        }

        public string Eliminar(int id)
        {
            try
            {
                var categoria = Consultar(id);
                if (categoria == null) return "La categoría no existe.";

                db.Categorias.Remove(categoria);
                db.SaveChanges();
                return "Categoría eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar la categoría: " + ex.Message;
            }
        }
    }
}