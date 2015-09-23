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

    public class TipoEventoAccess : ServicioGenerico<TipoEventoEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(TipoEventoEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_tipo_evento (nombre,flg_estado) " +
                                        "values('{0}','{1}')",
                                        t.Nombre, t.Estado);

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

        public bool Actualizar(TipoEventoEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_tipo_evento set nombre = '{0}', flg_estado = '{1}'" +
                                        "where id_tipo_evento = {2}",
                                        t.Nombre, t.Estado, t.Codigo);
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

        public bool Eliminar(TipoEventoEntity t)
        {
            throw new NotImplementedException();
        }

        public List<TipoEventoEntity> ListarTodos()
        {
            List<TipoEventoEntity> listaTipoEvento = new List<TipoEventoEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_TIPO_EVENTO";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        TipoEventoEntity objTipoEvento = new TipoEventoEntity();
                        objTipoEvento.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_evento")).ToString());
                        objTipoEvento.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                        objTipoEvento.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                        listaTipoEvento.Add(objTipoEvento);
                    }
                    dtr.Close();
                }
                return listaTipoEvento;
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

        public TipoEventoEntity Consultar(object codigo)
        {
            TipoEventoEntity objTipoEvento = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_TIPO_EVENTO where id_tipo_evento = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objTipoEvento = new TipoEventoEntity();
                    objTipoEvento.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_evento")).ToString());
                    objTipoEvento.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                    objTipoEvento.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();

                    dtr.Close();
                }
                return objTipoEvento;
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
            } throw new NotImplementedException();
        }


        public int Insertar(TipoEventoEntity t)
        {
            throw new NotImplementedException();
        }


        public List<TipoEventoEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
