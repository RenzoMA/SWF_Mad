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
    public class TrabajadorAccess : ServicioGenerico<TrabajadorEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(TrabajadorEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_trabajador (nombre,flg_estado,id_zona,cod_planilla) " +
                                        "values('{0}','{1}','{2}','{3}')",
                                        t.Nombre, t.Estado,t.CodigoZona,t.CodigoPlanilla);

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

        public bool Actualizar(TrabajadorEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_trabajador set nombre = '{0}', flg_estado = '{1}', id_zona = '{2}',cod_planilla='{3}'" +
                                        "where id_trabajador = {4}",
                                        t.Nombre, t.Estado, t.CodigoZona,t.CodigoPlanilla,t.Codigo);
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

        public bool Eliminar(TrabajadorEntity t)
        {
            throw new NotImplementedException();
        }

        public List<TrabajadorEntity> ListarTodos()
        {
            List<TrabajadorEntity> listaTrabajador = new List<TrabajadorEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_TRABAJADOR";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        TrabajadorEntity objTrabajador = new TrabajadorEntity();
                        objTrabajador.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_trabajador")).ToString());
                        objTrabajador.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                        objTrabajador.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                        objTrabajador.CodigoZona = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_zona")).ToString());
                        objTrabajador.CodigoPlanilla = dtr.GetValue(dtr.GetOrdinal("cod_planilla")).ToString();
                        listaTrabajador.Add(objTrabajador);
                    }
                    dtr.Close();
                }
                return listaTrabajador;
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

        public TrabajadorEntity Consultar(object codigo)
        {
            TrabajadorEntity objTrabajador = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_TRABAJADOR where id_trabajador = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objTrabajador = new TrabajadorEntity();
                    objTrabajador.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_trabajador")).ToString());
                    objTrabajador.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                    objTrabajador.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                    objTrabajador.CodigoZona = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_zona")).ToString());
                    objTrabajador.CodigoPlanilla = dtr.GetValue(dtr.GetOrdinal("cod_planilla")).ToString();
                    dtr.Close();
                }
                return objTrabajador;
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


        public int Insertar(TrabajadorEntity t)
        {
            throw new NotImplementedException();
        }


        public List<TrabajadorEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
