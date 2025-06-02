using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Tienda_Accesorios_Proyecto_SW.Models;

namespace Tienda_Accesorios_Proyecto_SW.Clases
{
    public class clsCliente
    {
        private DBTiendaAccesoriosEntities dbTienda = new DBTiendaAccesoriosEntities();
        public Cliente cliente { get; set; }

        public string Insertar()
        {
            try
            {
                dbTienda.Clientes.Add(cliente);
                dbTienda.SaveChanges(); 
                return $"{cliente.NombreCliente} insertado correctamente"; 
            }
            catch (Exception ex)
            {
                return "Error al insertar el cliente: " + ex.Message;
            }
        }

        public Cliente Consultar(int Documento)
        {
            Cliente cli = dbTienda.Clientes.FirstOrDefault(e => e.IdCliente == Documento);
            return cli;
        }

        public string Actualizar()
        {
            try
            {
                Cliente cli = Consultar(cliente.IdCliente);
                if (cli == null)
                {
                    return "Cliente no existe";
                }
                dbTienda.Clientes.AddOrUpdate(cliente);
                dbTienda.SaveChanges();
                return "Cliente actualizado correctamente";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar el cliente {cliente.NombreCliente} : " + ex.Message;
            }
        }

        public string Eliminar()
        {
            try
            {
                Cliente cli = Consultar(cliente.IdCliente);
                if (cli == null)
                {
                    return "Cliente no existe";
                }
                dbTienda.Clientes.Remove(cliente);
                dbTienda.SaveChanges();
                return $"{cliente.NombreCliente} eliminado correctamente";

            }
            catch (Exception ex)
            {
                return "Error al eliminar el cliente: " + ex.Message;
            }
        }

        public List<Cliente> ConsultarTodos()
        {
            return dbTienda.Clientes
                .OrderBy(e => e.NombreCliente)                               
                .ToList();
        }

        public string EliminarXDocumento(int Documento)
        {
            try
            {
                Cliente cli = Consultar(Documento);
                if (cli == null)
                {
                    return "Cliente no existe";
                }

                dbTienda.Clientes.Remove(cli);
                dbTienda.SaveChanges();
                return "Cliente eliminado correctamente";

            }
            catch (Exception ex)
            {
                return "Error al eliminar el cliente: " + ex.Message;
            }
        }

    }
}