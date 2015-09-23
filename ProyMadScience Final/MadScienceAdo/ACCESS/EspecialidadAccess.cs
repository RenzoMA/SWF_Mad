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
    public class EspecialidadAccess : ServicioGenerico<EspecialidadEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(EspecialidadEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_especialidad (id_fiesta,id_trabajador,fch_creacion,usr_creacion) " +
                                        "values('{0}','{1}','{2}','{3}')",
                                        t.CodigoFiesta, t.CodigoTrabajador, DateTime.Now,t.UsuarioCreacion);

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

        public bool Actualizar(EspecialidadEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_especialidad set id_fiesta = '{0}', id_trabajador = '{1}'," +
                                        " usr_creacion='{2}' where id_fiesta = {3} AND id_trabajador = {4}",
                                        t.CodigoFiesta, t.CodigoTrabajador, t.UsuarioCreacion, t.CodigoFiesta, t.CodigoTrabajador);
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

        public bool Eliminar(EspecialidadEntity t)
        {
            try
            {

                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("DELETE FROM TB_ESPECIALIDAD where id_fiesta = {0}"
                    + "AND id_trabajador = {1}", t.CodigoFiesta.ToString(), t.CodigoTrabajador.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (OleDbException ex)
            {

                return false;
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

        public List<EspecialidadEntity> ListarTodos()
        {
            List<EspecialidadEntity> listaEspecialidad = new List<EspecialidadEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_ESPECIALIDAD";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        EspecialidadEntity objEspecialidad = new EspecialidadEntity();
                        objEspecialidad.CodigoFiesta = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_fiesta")).ToString());
                        objEspecialidad.CodigoTrabajador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_trabajador")).ToString());
                        objEspecialidad.FechaCreacion = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString()));
                        objEspecialidad.UsuarioCreacion = dtr.GetValue(dtr.GetOrdinal("usr_creacion")).ToString();
                        listaEspecialidad.Add(objEspecialidad);
                    }
                    dtr.Close();
                }
                return listaEspecialidad;
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

        public EspecialidadEntity Consultar(object codigo)
        {
            EspecialidadEntity objEspecialidad = null;
            try
            {
                EspecialidadEntity t = (EspecialidadEntity)codigo;

                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB:*_ESPECIALIDAD where id_fiesta = {0}"
                    + " AND id_trabajador = {1}", t.CodigoFiesta.ToString(), t.CodigoTrabajador.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objEspecialidad = new EspecialidadEntity();
                    objEspecialidad.CodigoFiesta = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_fiesta")).ToString());
                    objEspecialidad.CodigoTrabajador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_trabajador")).ToString());
                    objEspecialidad.FechaCreacion = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString()));
                    objEspecialidad.UsuarioCreacion = dtr.GetValue(dtr.GetOrdinal("usr_creacion")).ToString();
                    dtr.Close();
                }
                return objEspecialidad;
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


        public int Insertar(EspecialidadEntity t)
        {
            throw new NotImplementedException();
        }


        public List<EspecialidadEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
