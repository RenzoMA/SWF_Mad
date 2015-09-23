using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceAdo.MSSQL
{
    public class UsuarioSQL : ServicioGenerico<UsuarioEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();

        public bool Agregar(UsuarioEntity t)
        {
            try
            {
                tb_usuario objUsuario = new tb_usuario();
                objUsuario.apeMat = t.ApeMat;
                objUsuario.apePat = t.ApePat;
                objUsuario.constraseña = t.Contraseña;
                objUsuario.flg_estado = t.Estado;
                objUsuario.login = t.Login;
                objUsuario.nombre = t.Nombre;
                msEntities.tb_usuario.Add(objUsuario);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(UsuarioEntity t)
        {
            try
            {
                tb_usuario objUsuario = (from us in msEntities.tb_usuario
                                         where us.id_usuario == t.Codigo
                                         select us).FirstOrDefault();
                objUsuario.constraseña = t.Contraseña;
                objUsuario.apeMat = t.ApeMat;
                objUsuario.apePat = t.ApePat;
                objUsuario.flg_estado = t.Estado;
                objUsuario.id_usuario = t.Codigo;
                objUsuario.login = t.Login;
                objUsuario.nombre = t.Nombre;
                msEntities.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool Eliminar(UsuarioEntity t)
        {
            try
            {
                tb_usuario objUsuario = (from us in msEntities.tb_usuario
                                         where us.id_usuario == t.Codigo
                                         select us).FirstOrDefault();
                msEntities.tb_usuario.Remove(objUsuario);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<UsuarioEntity> ListarTodos()
        {
            List<UsuarioEntity> objListaUsuario = new List<UsuarioEntity>();
            try
            {
                var query = msEntities.tb_usuario.ToList();
                foreach (var resultado in query)
                {
                    UsuarioEntity objUsuario = new UsuarioEntity();
                    objUsuario.Codigo = resultado.id_usuario;
                    objUsuario.Estado = resultado.flg_estado;
                    objUsuario.Nombre = resultado.nombre;
                    objUsuario.ApeMat = resultado.apeMat;
                    objUsuario.ApePat = resultado.apePat;
                    objUsuario.Contraseña = resultado.constraseña;
                    objUsuario.Login = resultado.login;
                    objListaUsuario.Add(objUsuario);
                }
                return objListaUsuario;
            }
            catch
            {
                return null;
            }
        }

        public UsuarioEntity Consultar(object codigo)
        {
            try
            {
                int codi = Convert.ToInt32(codigo.ToString());
                tb_usuario objUsuario = (from us in msEntities.tb_usuario
                                         where us.id_usuario == codi
                                         select us).FirstOrDefault();
                UsuarioEntity objUs = new UsuarioEntity();
                objUs.ApeMat = objUsuario.apeMat;
                objUs.ApePat = objUsuario.apePat;
                objUs.Codigo = objUsuario.id_usuario;
                objUs.Contraseña = objUsuario.constraseña;
                objUs.Estado = objUsuario.flg_estado;
                objUs.Login = objUsuario.login;
                objUs.Nombre = objUsuario.nombre;
                return objUs;
               
            }
            catch
            {
                return null;
            }
        }


        public int Insertar(UsuarioEntity t)
        {
            throw new NotImplementedException();
        }


        public List<UsuarioEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
