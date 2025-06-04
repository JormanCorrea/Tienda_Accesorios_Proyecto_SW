using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tienda_Accesorios_Proyecto_SW.Models;

namespace Tienda_Accesorios_Proyecto_SW.Clases
{
    public class clsUsuario
    {
        private DBTiendaAccesoriosEntities DBTienda = new DBTiendaAccesoriosEntities();
        public Usuario usuario { get; set; }
        public string CrearUsuario(int idPerfil)
        {
            try
            {
                clsCypher cypher = new clsCypher();
                cypher.Password = usuario.Clave;
                if (cypher.CifrarClave())
                {
                    //Graba el usuario
                    usuario.Clave = cypher.PasswordCifrado;
                    usuario.Salt = cypher.Salt;
                    DBTienda.Usuarios.Add(usuario);
                    DBTienda.SaveChanges();
                    //Grabar el perfil del usuario
                    Usuario_Perfil usuarioPerfil = new Usuario_Perfil();
                    usuarioPerfil.idPerfil = idPerfil;
                    usuarioPerfil.Activo = true;
                    usuarioPerfil.idUsuario = usuario.id;
                    DBTienda.Usuario_Perfil.Add(usuarioPerfil);
                    DBTienda.SaveChanges();
                    return "Se creó el usuario exitosamente";
                }
                else
                {
                    return "No se pudo cifrar la clave";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}