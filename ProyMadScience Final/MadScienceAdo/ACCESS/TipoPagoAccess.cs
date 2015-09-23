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
    public class TipoPagoAccess : ServicioGenerico<TipoPagoEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(TipoPagoEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_tipo_pago (nombre,flg_estado) " +
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

        public bool Actualizar(TipoPagoEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_tipo_pago set nombre = '{0}', flg_estado = '{1}' " +
                                        "where id_tipo_pago = {2}",
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

        public bool Eliminar(TipoPagoEntity t)
        {
            throw new NotImplementedException();
        }

        public List<TipoPagoEntity> ListarTodos()
        {
            List<TipoPagoEntity> listaTipoPago = new List<TipoPagoEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_TIPO_PAGO";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        TipoPagoEntity objTipoPago = new TipoPagoEntity();
                        objTipoPago.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_pago")).ToString());
                        objTipoPago.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                        objTipoPago.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                        listaTipoPago.Add(objTipoPago);
                    }
                    dtr.Close();
                }
                return listaTipoPago;
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

        public TipoPagoEntity Consultar(object codigo)
        {
            TipoPagoEntity objTipoPago = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_TIPO_PAGO where id_tipo_pago = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objTipoPago = new TipoPagoEntity(); ;
                    objTipoPago.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_pago")).ToString());
                    objTipoPago.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                    objTipoPago.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();

                    dtr.Close();
                }
                return objTipoPago;
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


        public int Insertar(TipoPagoEntity t)
        {
            throw new NotImplementedException();
        }


        public List<TipoPagoEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
