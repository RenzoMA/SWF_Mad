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
    public class ZonaAccess : ServicioGenerico<ZonaEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(ZonaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_zona(nombre,flg_estado)" +
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

        public bool Actualizar(ZonaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_zona set nombre = '{0}', flg_estado = '{1}'" +
                                        "where id_zona = {2}",
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

        public bool Eliminar(ZonaEntity t)
        {
            throw new NotImplementedException();
        }

        public List<ZonaEntity> ListarTodos()
        {
            List<ZonaEntity> listaZona = new List<ZonaEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_ZONA";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        ZonaEntity objZona = new ZonaEntity();
                        objZona.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_zona")).ToString());
                        objZona.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                        objZona.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                        listaZona.Add(objZona);
                    }
                    dtr.Close();
                }
                return listaZona;
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

        public ZonaEntity Consultar(object codigo)
        {
            ZonaEntity objZona = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_ZONA where id_zona = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objZona = new ZonaEntity();
                    objZona.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_zona")).ToString());
                    objZona.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                    objZona.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();

                    dtr.Close();
                }
                return objZona;
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


        public int Insertar(ZonaEntity t)
        {
            throw new NotImplementedException();
        }


        public List<ZonaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
