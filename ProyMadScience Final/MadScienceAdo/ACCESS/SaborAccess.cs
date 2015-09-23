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
    class SaborAccess:ServicioGenerico<SaborEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(SaborEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_sabor (nombre,flg_estado) " +
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

        public bool Actualizar(SaborEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_sabor set nombre = '{0}', flg_estado = '{1}'" +
                                        "where id_sabor = {2}",
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

        public bool Eliminar(SaborEntity t)
        {
            throw new NotImplementedException();
        }

        public List<SaborEntity> ListarTodos()
        {
            List<SaborEntity> listaSabor = new List<SaborEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_SABOR";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        SaborEntity objSabor = new SaborEntity();
                        objSabor.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_sabor")).ToString());
                        objSabor.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                        objSabor.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                        listaSabor.Add(objSabor);
                    }
                    dtr.Close();
                }
                return listaSabor;
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

        public SaborEntity Consultar(object codigo)
        {
            SaborEntity objSabor = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_SABOR where id_sabor = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objSabor = new SaborEntity();
                    objSabor.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_sabor")).ToString());
                    objSabor.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                    objSabor.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();

                    dtr.Close();
                }
                return objSabor;
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


        public int Insertar(SaborEntity t)
        {
            throw new NotImplementedException();
        }


        public List<SaborEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
