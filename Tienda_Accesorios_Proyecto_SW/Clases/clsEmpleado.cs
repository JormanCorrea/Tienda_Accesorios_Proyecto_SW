using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Tienda_Accesorios_Proyecto_SW.Models;

namespace Tienda_Accesorios_Proyecto_SW.Clases
{
    public class clsEmpleado
    {
        private DBTiendaAccesoriosEntities dbTienda = new DBTiendaAccesoriosEntities();
        public Empleado empleado { get; set; }
        public string Insertar()
        {
            try
            {
                dbTienda.Empleadoes.Add(empleado);
                dbTienda.SaveChanges();
                return "Se ingresó el empleado " + empleado.NombreEmpleado + " a la base de datos";
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
                Empleado emp = Consultar(empleado.IdEmpleado);
                if (emp == null)
                {
                    return "El empleado no existe";
                }
                dbTienda.Empleadoes.AddOrUpdate(empleado);
                dbTienda.SaveChanges();
                return "Se actualizó el empleado " + empleado.NombreEmpleado + " correctamente";
            }
            catch (Exception ex)
            {
                return "Error al  Actualizar" + ex.Message;
            }
        }

        public Empleado Consultar(int IdEmpleado)
        {
            Empleado emp = dbTienda.Empleadoes.FirstOrDefault(e => e.IdEmpleado == IdEmpleado);
            return emp;
        }

        public List<Empleado> ConsultarTodos()
        {
            return dbTienda.Empleadoes
                .OrderBy(e => e.NombreEmpleado)
                .ToList();
        }
    

        public string EliminarXDocumento(int IdEmpleado)
        {
            //Primero se debe consultar
            try
            {
                Empleado empl = Consultar(IdEmpleado);
                if (empl == null)
                {
                    return "Empleado no existe"; //Retorna un mensaje de error
                }
                //Si el empleado existe se elimina
                dbTienda.Empleadoes.Remove(empl); //Elimina el empleado de la lista
                dbTienda.SaveChanges(); //Guarda los cambios en la base de datos
                return "Empleado eliminado correctamente"; //Retorna un mensaje de confirmación

            }
            catch (Exception ex)
            {
                return "Error al eliminar el empleado: " + ex.Message; //Retorna un mensaje de error
            }
        }

    }
}