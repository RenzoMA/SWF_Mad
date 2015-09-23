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
    public class TipoFiestaAccess : ServicioGenerico<TipoFiestaEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(TipoFiestaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_tipo_fiesta (nombre,flg_estado,fch_creacion) " +
                                        "values('{0}','{1}','{2}')",
                                        t.Nombre, t.Estado, DateTime.Now);

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

        public bool Actualizar(TipoFiestaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_tipo_fiesta set nombre = '{0}', flg_estado = '{1}'" +
                                        " where id_tipo_fiesta = {2}",
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

        public bool Eliminar(TipoFiestaEntity t)
        {
            throw new NotImplementedException();
        }

        public List<TipoFiestaEntity> ListarTodos()
        {
            List<TipoFiestaEntity> listaTipoFiesta = new List<TipoFiestaEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_TIPO_FIESTA";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        TipoFiestaEntity objTipoFiesta = new TipoFiestaEntity();
                        objTipoFiesta.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_fiesta")).ToString());
                        objTipoFiesta.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                        objTipoFiesta.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                        objTipoFiesta.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString());
                        listaTipoFiesta.Add(objTipoFiesta);
                    }
                    dtr.Close();
                }
                return listaTipoFiesta;
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

        public TipoFiestaEntity Consultar(object codigo)
        {
            TipoFiestaEntity objTipoFiesta = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_TIPO_FIESTA where id_tipo_fiesta = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objTipoFiesta = new TipoFiestaEntity();
                    objTipoFiesta.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_fiesta")).ToString());
                    objTipoFiesta.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                    objTipoFiesta.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();

                    dtr.Close();
                }
                return objTipoFiesta;
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


        public int Insertar(TipoFiestaEntity t)
        {
            throw new NotImplementedException();
        }


        public List<TipoFiestaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
