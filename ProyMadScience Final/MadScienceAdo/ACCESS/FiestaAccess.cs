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
    public class FiestaAccess : ServicioGenerico<FiestaEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(FiestaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_fiesta (nombre,flg_estado,id_tipo_fiesta) " +
                                        "values('{0}','{1}','{2}')",
                                        t.Nombre, t.Estado, t.CodigoTipoFiesta);

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

        public bool Actualizar(FiestaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_fiesta set nombre = '{0}', flg_estado = '{1}', id_tipo_fiesta ='{2}'" +
                                        "where id_fiesta = {3}",
                                        t.Nombre, t.Estado,t.CodigoTipoFiesta, t.Codigo);
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

        public bool Eliminar(FiestaEntity t)
        {
            throw new NotImplementedException();
        }

        public List<FiestaEntity> ListarTodos()
        {
            List<FiestaEntity> listaFiesta = new List<FiestaEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_FIESTA";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        FiestaEntity objFiesta = new FiestaEntity();
                        objFiesta.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_fiesta")).ToString());
                        objFiesta.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                        objFiesta.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                        objFiesta.CodigoTipoFiesta = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_fiesta")).ToString());
                        listaFiesta.Add(objFiesta);
                    }
                    dtr.Close();
                }
                return listaFiesta;
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

        public FiestaEntity Consultar(object codigo)
        {
            FiestaEntity objFiesta = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_FIESTA where id_fiesta = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objFiesta = new FiestaEntity();
                    objFiesta.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_fiesta")).ToString());
                    objFiesta.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                    objFiesta.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                    objFiesta.CodigoTipoFiesta = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_fiesta")).ToString());

                    dtr.Close();
                }
                return objFiesta;
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


        public int Insertar(FiestaEntity t)
        {
            throw new NotImplementedException();
        }


        public List<FiestaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
