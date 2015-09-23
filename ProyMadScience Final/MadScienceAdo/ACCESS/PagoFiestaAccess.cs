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
    public class PagoFiestaAccess : ServicioGenerico<PagoFiestaEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(PagoFiestaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_pago_fiesta(id_tipo_pago,id_fiesta,monto)" +
                                        "values('{0}','{1}','{2}')",
                                        t.CodigoTipoPago, t.CodigoFiesta, t.Monto);
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

        public bool Actualizar(PagoFiestaEntity t)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(PagoFiestaEntity t)
        {
            try
            {

                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("DELETE FROM TB_PAGO_FIESTA where id_tipo_pago = {0}"
                    +"AND id_fiesta = {1}", t.CodigoTipoPago.ToString(), t.CodigoFiesta.ToString());
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

        public List<PagoFiestaEntity> ListarTodos()
        {
            List<PagoFiestaEntity> listaPagoFiesta = new List<PagoFiestaEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_PAGO_FIESTA";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        PagoFiestaEntity objPagoFiesta = new PagoFiestaEntity();
                        objPagoFiesta.CodigoTipoPago = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_pago")).ToString());
                        objPagoFiesta.CodigoFiesta = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_fiesta")).ToString());
                        objPagoFiesta.Monto = Convert.ToDouble((dtr.GetValue(dtr.GetOrdinal("monto")).ToString()));
                        listaPagoFiesta.Add(objPagoFiesta);
                    }
                    dtr.Close();
                }
                return listaPagoFiesta;
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

        public PagoFiestaEntity Consultar(object codigo)
        {
            PagoFiestaEntity objPagoFiesta = null;
            try
            {
                PagoFiestaEntity t = (PagoFiestaEntity)codigo;

                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_PAGO_FIESTA where id_tipo_pago = {0}" 
                    +" AND id_fiesta = {1}", t.CodigoTipoPago.ToString(), t.CodigoFiesta.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objPagoFiesta = new PagoFiestaEntity();
                    objPagoFiesta.CodigoTipoPago = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_pago")).ToString());
                    objPagoFiesta.CodigoFiesta = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_fiesta")).ToString());
                    objPagoFiesta.Monto = Convert.ToDouble((dtr.GetValue(dtr.GetOrdinal("monto")).ToString()));

                    dtr.Close();
                }
                return objPagoFiesta;
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


        public int Insertar(PagoFiestaEntity t)
        {
            throw new NotImplementedException();
        }


        public List<PagoFiestaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
