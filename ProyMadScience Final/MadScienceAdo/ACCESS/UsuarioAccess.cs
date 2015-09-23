using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;
using System.Data.OleDb;
using System.Data;

namespace MadScienceAdo.ACCESS
{
    public class UsuarioAccess : ServicioGenerico<UsuarioEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(UsuarioEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_usuario (nombre,apePat,apeMat,flg_estado,constraseña,login) "+
                                        "values('{0}','{1}','{2}','{3}','{4}','{5}')",
                                        t.Nombre, t.ApePat, t.ApeMat, t.Estado, t.Contraseña, t.Login);
                           
            cmd.CommandText = sql;
            try
            {
                cnx.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (OleDbException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }

        public bool Actualizar(UsuarioEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_usuario set nombre = '{0}', apePat = '{1}', apeMat = '{2}', flg_estado = '{3}',"+
                                        "constraseña = '{4}',login ='{5}' where id_usuario = {6}",
                                        t.Nombre, t.ApePat, t.ApeMat, t.Estado, t.Contraseña, t.Login,t.Codigo);
            cmd.CommandText = sql;
            try
            {
                cnx.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (OleDbException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }

        public bool Eliminar(UsuarioEntity t)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioEntity> ListarTodos()
        {
           
            List<UsuarioEntity> listaUsuario = new List<UsuarioEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_USUARIO";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        UsuarioEntity objUsuario = new UsuarioEntity();
                        objUsuario.ApeMat = dtr.GetValue(dtr.GetOrdinal("apeMat")).ToString();
                        objUsuario.ApePat = dtr.GetValue(dtr.GetOrdinal("apePat")).ToString();
                        objUsuario.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_usuario")).ToString());
                        objUsuario.Contraseña = dtr.GetValue(dtr.GetOrdinal("constraseña")).ToString();
                        objUsuario.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                        objUsuario.Login = dtr.GetValue(dtr.GetOrdinal("login")).ToString();
                        objUsuario.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                        listaUsuario.Add(objUsuario);
                    }
                    dtr.Close();
                }
                return listaUsuario;
            }
            catch (OleDbException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }          
        }

        public UsuarioEntity Consultar(object codigo)
        {
            UsuarioEntity objUsuario = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_USUARIO where id_usuario = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();
                    
                        objUsuario = new UsuarioEntity();
                        objUsuario.ApeMat = dtr.GetValue(dtr.GetOrdinal("apeMat")).ToString();
                        objUsuario.ApePat = dtr.GetValue(dtr.GetOrdinal("apePat")).ToString();
                        objUsuario.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_usuario")).ToString());
                        objUsuario.Contraseña = dtr.GetValue(dtr.GetOrdinal("constraseña")).ToString();
                        objUsuario.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                        objUsuario.Login = dtr.GetValue(dtr.GetOrdinal("login")).ToString();
                        objUsuario.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
           
                    dtr.Close();
                }
                return objUsuario;
            }
            catch (OleDbException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
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
