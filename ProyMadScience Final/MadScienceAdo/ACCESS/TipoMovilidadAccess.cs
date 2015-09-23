using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo.Servicios;
using MadScienceBE;
using System.Data.OleDb;
using System.Data;

namespace MadScienceAdo.ACCESS
{
    class TipoMovilidadAccess: ServicioGenerico<TipoMovilidadEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(TipoMovilidadEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_tipo_movilidad (des_nombre,monto,flg_estado) " +
                                        "values('{0}','{1}','{2}')",
                                        t.Des_nombre, t.Monto, t.Estado);

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

        public bool Actualizar(TipoMovilidadEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_tipo_movilidad set des_nombre = '{0}', monto = '{1}', flg_estado= '{2}'" +
                                        " where id_tipo_movilidad = {3}",
                                        t.Des_nombre, t.Monto,t.Estado,t.CodigoMovilidad);
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

        public bool Eliminar(TipoMovilidadEntity t)
        {
            throw new NotImplementedException();
        }

        public List<TipoMovilidadEntity> ListarTodos()
        {
            List<TipoMovilidadEntity> listaTipomovilidad = new List<TipoMovilidadEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM tb_tipo_movilidad";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        TipoMovilidadEntity objTipomovilidad = new TipoMovilidadEntity();
                        objTipomovilidad.CodigoMovilidad = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_movilidad")).ToString());
                        objTipomovilidad.Des_nombre = dtr.GetValue(dtr.GetOrdinal("des_nombre")).ToString();
                        objTipomovilidad.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                        objTipomovilidad.Monto = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("monto")).ToString());
                        listaTipomovilidad.Add(objTipomovilidad);
                    }
                    dtr.Close();
                }
                return listaTipomovilidad;
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

        public TipoMovilidadEntity Consultar(object codigo)
        {
            TipoMovilidadEntity objTipomovilidad = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM tb_tipo_movilidad where id_tipo_movilidad = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objTipomovilidad = new TipoMovilidadEntity();
                    objTipomovilidad.CodigoMovilidad = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_movilidad")).ToString());
                    objTipomovilidad.Des_nombre = dtr.GetValue(dtr.GetOrdinal("des_nombre")).ToString();
                    objTipomovilidad.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                    objTipomovilidad.Monto = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("monto")).ToString());

                    dtr.Close();
                }
                return objTipomovilidad;
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


        public int Insertar(TipoMovilidadEntity t)
        {
            throw new NotImplementedException();
        }


        public List<TipoMovilidadEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
