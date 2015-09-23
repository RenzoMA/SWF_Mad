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
    public class FiestaEventoAccess : ServicioGenerico<FiestaEventoEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(FiestaEventoEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_fiesta_evento (id_tipo_evento,id_fiesta,fch_creacion) " +
                                        "values('{0}','{1}','{2}')",
                                        t.CodigoTipoEvento, t.CodigoFiesta, DateTime.Now);

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

        public bool Actualizar(FiestaEventoEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_fiesta_evento set id_tipo_evento = '{0}', id_fiesta = '{1}'" +
                                        " where id_tipo_evento = {2} AND id_fiesta = {3}",
                                        t.CodigoTipoEvento, t.CodigoFiesta, t.CodigoTipoEvento,t.CodigoFiesta);
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

        public bool Eliminar(FiestaEventoEntity t)
        {
            try
            {

                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("DELETE FROM TB_FIESTA_EVENTO where id_tipo_evento = {0}"
                    + "AND id_fiesta = {1}", t.CodigoTipoEvento.ToString(), t.CodigoFiesta.ToString());
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

        public List<FiestaEventoEntity> ListarTodos()
        {
            List<FiestaEventoEntity> listaFiestaEvento = new List<FiestaEventoEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_FIESTA_EVENTO";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        FiestaEventoEntity objFiestaEvento = new FiestaEventoEntity();
                        objFiestaEvento.CodigoTipoEvento = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_evento")).ToString());
                        objFiestaEvento.CodigoFiesta = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_fiesta")).ToString());
                        objFiestaEvento.FechaCreacion = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString()));
                        listaFiestaEvento.Add(objFiestaEvento);
                    }
                    dtr.Close();
                }
                return listaFiestaEvento;
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

        public FiestaEventoEntity Consultar(object codigo)
        {
            FiestaEventoEntity objFiestaEvento = null;
            try
            {
                FiestaEventoEntity t = (FiestaEventoEntity)codigo;

                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_TIPO_EVENTO where id_tipo_evento = {0}"
                    + " AND id_fiesta = {1}", t.CodigoTipoEvento.ToString(), t.CodigoFiesta.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objFiestaEvento = new FiestaEventoEntity();
                    objFiestaEvento.CodigoTipoEvento = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_evento")).ToString());
                    objFiestaEvento.CodigoFiesta = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_fiesta")).ToString());
                    objFiestaEvento.FechaCreacion = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString()));
                    dtr.Close();
                }
                return objFiestaEvento;
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


        public int Insertar(FiestaEventoEntity t)
        {
            throw new NotImplementedException();
        }


        public List<FiestaEventoEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
