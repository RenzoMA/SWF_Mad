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
    public class TiendaAccess : ServicioGenerico<TiendaEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(TiendaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql ;
            if (t.CodigoZona == null)
            {
                sql = String.Format("insert into tb_tienda(nombre,flg_estado,direccion) " +
                                            "values('{0}','{1}','{2}')",
                                             t.Nombre, t.Estado, t.Direccion);
            }
            else
            {
                sql = String.Format("insert into tb_tienda(id_zona,nombre,flg_estado,direccion) " +
                                                           "values('{0}','{1}','{2}','{3}')",
                                                           t.CodigoZona, t.Nombre, t.Estado, t.Direccion);
            }
            
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

        public bool Actualizar(TiendaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = "";
            if (t.CodigoZona == null)
            {
                sql = String.Format("update tb_tienda set id_zona = null, nombre = '{0}', flg_estado = '{1}', direccion = '{2}' where id_tienda = {3}",
                                             t.Nombre, t.Estado, t.Direccion, t.Codigo);
            }
            else
            {
                
                sql = String.Format("update tb_tienda set id_zona = '{0}', nombre = '{1}', flg_estado = '{2}', direccion = '{3}' where id_tienda = {4}",
                                                           t.CodigoZona, t.Nombre, t.Estado, t.Direccion, t.Codigo);
            }

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

        public bool Eliminar(TiendaEntity t)
        {
            throw new NotImplementedException();
        }

        public List<TiendaEntity> ListarTodos()
        {
            List<TiendaEntity> listaTienda = new List<TiendaEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_TIENDA";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        TiendaEntity objTienda = new TiendaEntity();
                        objTienda.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tienda")).ToString());
                        String zona = dtr.GetValue(dtr.GetOrdinal("id_zona")).ToString();
                        if (zona.Equals(""))
                        {
                            objTienda.CodigoZona = null;
                        }
                        else
                        {
                            objTienda.CodigoZona = Convert.ToInt16(zona);
                        }         
                        objTienda.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                        objTienda.Direccion = dtr.GetValue(dtr.GetOrdinal("direccion")).ToString();
                        objTienda.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                        listaTienda.Add(objTienda);
                    }
                    dtr.Close();
                }
                return listaTienda;
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

        public TiendaEntity Consultar(object codigo)
        {
            TiendaEntity objTienda = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_TIENDA where id_tienda = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objTienda = new TiendaEntity();
                    objTienda.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tienda")).ToString());
                    String zona = dtr.GetValue(dtr.GetOrdinal("id_zona")).ToString();
                    if (zona.Equals(""))
                    {
                        objTienda.CodigoZona = null;
                    }
                    else
                    {
                        objTienda.CodigoZona = Convert.ToInt16(zona);
                    } 
                    objTienda.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                    objTienda.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                    objTienda.Direccion = dtr.GetValue(dtr.GetOrdinal("direccion")).ToString();
                    dtr.Close();
                }
                return objTienda;
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


        public int Insertar(TiendaEntity t)
        {
            throw new NotImplementedException();
        }


        public List<TiendaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
