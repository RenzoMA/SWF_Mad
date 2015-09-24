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
    class CebeEmpresaAccess : ServicioGenerico<CebeEmpresaEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(CebeEmpresaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_cebe_empresa (des_nombre) " +
                                        "values('{0}')",
                                        t.Nombre);

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

        public bool Actualizar(CebeEmpresaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_cebe_empresa set des_nombre = '{0}'" +
                                        "where id_cebe_empresa = {1}",
                                        t.Nombre, t.Codigo);
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

        public bool Eliminar(CebeEmpresaEntity t)
        {
            throw new NotImplementedException();
        }

        public List<CebeEmpresaEntity> ListarTodos()
        {
            List<CebeEmpresaEntity> listaSabor = new List<CebeEmpresaEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM tb_cebe_empresa";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        CebeEmpresaEntity objSabor = new CebeEmpresaEntity();
                        objSabor.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_cebe_empresa")).ToString());
                        objSabor.Nombre = dtr.GetValue(dtr.GetOrdinal("des_nombre")).ToString();
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

        public CebeEmpresaEntity Consultar(object codigo)
        {
            CebeEmpresaEntity objSabor = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM tb_cebe_empresa where id_cebe_empresa = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objSabor = new CebeEmpresaEntity();
                    objSabor.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_cebe_empresa")).ToString());
                    objSabor.Nombre = dtr.GetValue(dtr.GetOrdinal("des_nombre")).ToString();

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


        public int Insertar(CebeEmpresaEntity t)
        {
            throw new NotImplementedException();
        }


        public List<CebeEmpresaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
