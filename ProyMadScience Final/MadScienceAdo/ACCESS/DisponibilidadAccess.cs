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
    public class DisponibilidadAccess : ServicioGenerico<DisponibilidadEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(DisponibilidadEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_disponibilidad (id_horario,id_trabajador,fch_creacion,usr_creacion) " +
                                        "values('{0}','{1}','{2}','{3}')",
                                        t.CodigoHorario, t.CodigoTrabajador, DateTime.Now,t.UsuarioCreacion);

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

        public bool Actualizar(DisponibilidadEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_disponibilidad set id_horario = '{0}', id_trabajador = '{1}', usr_creacion='{2}'" +
                                        " where id_horario = {3} AND id_trabajador = {4}",
                                        t.CodigoHorario, t.CodigoTrabajador, t.UsuarioCreacion, t.CodigoHorario, t.CodigoTrabajador);
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

        public bool Eliminar(DisponibilidadEntity t)
        {
            try
            {

                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("DELETE FROM TB_DISPONIBILIDAD where id_horario = {0}"
                    + "AND id_trabajador = {1}", t.CodigoHorario.ToString(), t.CodigoTrabajador.ToString());
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

        public List<DisponibilidadEntity> ListarTodos()
        {
            List<DisponibilidadEntity> listaDisponibilidad = new List<DisponibilidadEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_DISPONIBILIDAD";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        DisponibilidadEntity objDisponiblidad = new DisponibilidadEntity();
                        objDisponiblidad.CodigoHorario = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_horario")).ToString());
                        objDisponiblidad.CodigoTrabajador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_trabajador")).ToString());
                        objDisponiblidad.FechaCreacion = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString()));
                        objDisponiblidad.UsuarioCreacion = dtr.GetValue(dtr.GetOrdinal("usr_creacion")).ToString();
                        listaDisponibilidad.Add(objDisponiblidad);
                    }
                    dtr.Close();
                }
                return listaDisponibilidad;
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

        public DisponibilidadEntity Consultar(object codigo)
        {
            DisponibilidadEntity objDisponibilidad = null;
            try
            {
                DisponibilidadEntity t = (DisponibilidadEntity)codigo;

                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_DISPONIBILIDAD where id_horario = {0}"
                    + " AND id_trabajador = {1}", t.CodigoHorario.ToString(), t.CodigoTrabajador.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    DisponibilidadEntity objDisponiblidad = new DisponibilidadEntity();
                    objDisponibilidad.CodigoHorario = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_horario")).ToString());
                    objDisponibilidad.CodigoTrabajador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_trabajador")).ToString());
                    objDisponibilidad.FechaCreacion = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString()));
                    objDisponibilidad.UsuarioCreacion = dtr.GetValue(dtr.GetOrdinal("usr_creacion")).ToString();
                    dtr.Close();
                }
                return objDisponibilidad;
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


        public int Insertar(DisponibilidadEntity t)
        {
            throw new NotImplementedException();
        }


        public List<DisponibilidadEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
