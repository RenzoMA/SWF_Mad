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
    class TortaAccess:ServicioGenerico<TortaEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(TortaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_torta (nombre,flg_estado) " +
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

        public bool Actualizar(TortaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_torta set nombre = '{0}', flg_estado = '{1}'"+
                                        " where id_torta = {2}",
                                        t.Nombre, t.Estado,t.Codigo);
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
        

        public bool Eliminar(TortaEntity t)
        {
            throw new NotImplementedException();
        }

        public List<TortaEntity> ListarTodos()
        {
            List<TortaEntity> listaTorta = new List<TortaEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_TORTA";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        TortaEntity objTorta = new TortaEntity();
                        objTorta.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_torta")).ToString());
                        objTorta.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                        objTorta.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                        listaTorta.Add(objTorta);
                    }
                    dtr.Close();
                }
                return listaTorta;
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

        public TortaEntity Consultar(object codigo)
        {
            TortaEntity objTorta = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_TORTA where id_torta = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objTorta = new TortaEntity();
                    objTorta.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_torta")).ToString());
                    objTorta.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                    objTorta.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();

                    dtr.Close();
                }
                return objTorta;
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


        public int Insertar(TortaEntity t)
        {
            throw new NotImplementedException();
        }


        public List<TortaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
