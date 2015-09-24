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
    public class DetalleReservaAccess : ServicioGenerico<DetalleReservaEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);


        public bool Agregar(DetalleReservaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("insert into tb_detalle_reserva (id_reserva,id_fiesta,fch_creacion,usr_crea,fact_cuenta,fact_cliente,fact_precio,fact_nomcli) " +
                                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                                        t.CodigoReserva, t.CodigoFiesta, t.FechaCreacion,t.Usuario,t.FactCuenta,t.FactCliente,t.FactPrecio,t.FactNomCli);

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

        public bool Actualizar(DetalleReservaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_detalle_reserva set id_reserva = '{0}', id_fiesta = '{1}', usr_crea ='{2}',fact_cuenta='{3}',fact_cliente='{4}',fact_precio='{5}',fact_nomcli='{6}'" +
                                        "where id_detalle = {7}",
                                        t.CodigoReserva, t.CodigoFiesta, t.Usuario,t.FactCuenta,t.FactCliente,t.FactPrecio,t.FactNomCli, t.Codigo);
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

        public bool Eliminar(DetalleReservaEntity t)
        {
            try
            {

                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("DELETE FROM TB_DETALLE_RESERVA where id_detalle = {0}"
                    , t.Codigo.ToString());
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

        public List<DetalleReservaEntity> ListarTodos()
        {
            List<DetalleReservaEntity> listaDetalleReserva = new List<DetalleReservaEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_DETALLE_RESERVA";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        DetalleReservaEntity objDetalleReserva = new DetalleReservaEntity();
                        objDetalleReserva.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_detalle")).ToString());
                        objDetalleReserva.CodigoReserva = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_reserva")).ToString());
                        objDetalleReserva.CodigoFiesta = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_fiesta")).ToString());
                        objDetalleReserva.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString());
                        objDetalleReserva.Usuario = dtr.GetValue(dtr.GetOrdinal("usr_crea")).ToString();
                        objDetalleReserva.FactCliente = dtr.GetValue(dtr.GetOrdinal("fact_cliente")).ToString();
                        objDetalleReserva.FactCuenta = dtr.GetValue(dtr.GetOrdinal("fact_cuenta")).ToString();
                        objDetalleReserva.FactPrecio = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("fact_precio")).ToString());
                        objDetalleReserva.FactNomCli = dtr.GetValue(dtr.GetOrdinal("fact_nomcli")).ToString();
                        listaDetalleReserva.Add(objDetalleReserva);
                    }
                    dtr.Close();
                }
                return listaDetalleReserva;
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

        public DetalleReservaEntity Consultar(object codigo)
        {
            DetalleReservaEntity objDetalle = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_DETALLE_RESERVA where id_detalle = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objDetalle = new DetalleReservaEntity();
                    objDetalle.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_detalle")).ToString());
                    objDetalle.CodigoReserva = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_reserva")).ToString());
                    objDetalle.CodigoFiesta = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_fiesta")).ToString());
                    objDetalle.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString());
                    objDetalle.Usuario = dtr.GetValue(dtr.GetOrdinal("usr_crea")).ToString();
                    objDetalle.FactCliente = dtr.GetValue(dtr.GetOrdinal("fact_cliente")).ToString();
                    objDetalle.FactCuenta = dtr.GetValue(dtr.GetOrdinal("fact_cuenta")).ToString();
                    objDetalle.FactPrecio = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("fact_precio")).ToString());
                    objDetalle.FactNomCli = dtr.GetValue(dtr.GetOrdinal("fact_nomcli")).ToString();

                    dtr.Close();
                }
                return objDetalle;
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


        public int Insertar(DetalleReservaEntity t)
        {
            throw new NotImplementedException();
        }

        public List<DetalleReservaEntity> ListarPorReserva(int codigoReserva)
        {
            List<DetalleReservaEntity> listaDetalleReserva = new List<DetalleReservaEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = "select * from tb_detalle_reserva " +
                                           " where id_reserva = @codigo ";

                OleDbParameter paramInicio = new OleDbParameter("@codigo", OleDbType.Integer);
                paramInicio.Value = codigoReserva;
                cmd.Parameters.Add(paramInicio);



                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        DetalleReservaEntity objDetalleReserva = new DetalleReservaEntity();
                        objDetalleReserva.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_detalle")).ToString());
                        objDetalleReserva.CodigoReserva = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_reserva")).ToString());
                        objDetalleReserva.CodigoFiesta = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_fiesta")).ToString());
                        objDetalleReserva.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString());
                        objDetalleReserva.Usuario = dtr.GetValue(dtr.GetOrdinal("usr_crea")).ToString();
                        objDetalleReserva.FactCliente = dtr.GetValue(dtr.GetOrdinal("fact_cliente")).ToString();
                        objDetalleReserva.FactCuenta = dtr.GetValue(dtr.GetOrdinal("fact_cuenta")).ToString();
                        objDetalleReserva.FactPrecio = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("fact_precio")).ToString());
                        objDetalleReserva.FactNomCli = dtr.GetValue(dtr.GetOrdinal("fact_nomcli")).ToString();
                        listaDetalleReserva.Add(objDetalleReserva);
                    }
                    dtr.Close();
                }
                cmd.Parameters.Clear();
                return listaDetalleReserva;
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


        public List<DetalleReservaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            List<DetalleReservaEntity> listaDetalleReserva = new List<DetalleReservaEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = "select * from tb_detalle_reserva " +
                                           " where id_reserva in " +
                                           " (select id_reserva from " +
                                           " tb_reserva where fechaCelebracion " +
                                           " between @inicio and @fin) ";

                OleDbParameter paramInicio = new OleDbParameter("@inicio", OleDbType.Date);
                OleDbParameter paramFin = new OleDbParameter("@fin", OleDbType.Date);
                paramInicio.Value = fechaInicio;
                paramFin.Value = fechaFin;
                cmd.Parameters.Add(paramInicio);
                cmd.Parameters.Add(paramFin);


                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        DetalleReservaEntity objDetalleReserva = new DetalleReservaEntity();
                        objDetalleReserva.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_detalle")).ToString());
                        objDetalleReserva.CodigoReserva = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_reserva")).ToString());
                        objDetalleReserva.CodigoFiesta = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_fiesta")).ToString());
                        objDetalleReserva.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString());
                        objDetalleReserva.Usuario = dtr.GetValue(dtr.GetOrdinal("usr_crea")).ToString();
                        objDetalleReserva.FactCliente = dtr.GetValue(dtr.GetOrdinal("fact_cliente")).ToString();
                        objDetalleReserva.FactCuenta = dtr.GetValue(dtr.GetOrdinal("fact_cuenta")).ToString();
                        objDetalleReserva.FactPrecio = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("fact_precio")).ToString());
                        objDetalleReserva.FactNomCli = dtr.GetValue(dtr.GetOrdinal("fact_nomcli")).ToString();
                        listaDetalleReserva.Add(objDetalleReserva);
                    }
                    dtr.Close();
                }
                cmd.Parameters.Clear();
                return listaDetalleReserva;
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
        public List<ReporteFacturacion> ListarFacturacion(DateTime fechaInicio, DateTime fechaFin)
        {
            List<ReporteFacturacion> listaDetalleReserva = new List<ReporteFacturacion>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql ="SELECT "+
                            "ce.des_nombre as [Cebe_Empresa], "+
                            "dr.fact_cliente as [Cliente], "+
                            "dr.fact_nomcli as [Detalle_Cliente], "+
                            "tf.nombre as [Tipo], "+
                            "dr.fact_cuenta as [Cuenta], "+
                            "count(dr.fact_cuenta) as [Cantidad], "+
                            "sum(dr.fact_precio) as [Monto] "+
                            "FROM "+
                            "(((tb_cebe_empresa ce "+
                            "inner join tb_fiesta fi "+
                            "on ce.id_cebe_empresa = fi.cebe_empresa) "+
                            "inner join tb_detalle_reserva dr "+
                            "on dr.id_fiesta = fi.id_fiesta) "+
                            "inner join tb_tipo_fiesta tf "+
                            "on tf.id_tipo_fiesta = fi.id_tipo_fiesta) "+
                            "inner join tb_reserva re "+
                            "on re.id_reserva = dr.id_reserva "+
                            "where "+
                            "re.flg_estado = 'A' and "+
                            "(re.fechaCelebracion between @fi and @ff) "+
                            "group by ce.des_nombre,dr.fact_cliente,dr.fact_nomcli,tf.nombre,dr.fact_cuenta "+
                            "order by 1,2,3 ";

                OleDbParameter paramInicio = new OleDbParameter("@inicio", OleDbType.Date);
                OleDbParameter paramFin = new OleDbParameter("@fin", OleDbType.Date);
                paramInicio.Value = fechaInicio;
                paramFin.Value = fechaFin;
                cmd.Parameters.Add(paramInicio);
                cmd.Parameters.Add(paramFin);


                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        ReporteFacturacion objDetalleReserva = new ReporteFacturacion();
                        objDetalleReserva.CebeEmpresa = dtr.GetValue(dtr.GetOrdinal("Cebe_Empresa")).ToString();
                        objDetalleReserva.Cliente = dtr.GetValue(dtr.GetOrdinal("Cliente")).ToString();
                        objDetalleReserva.DetalleCliente = dtr.GetValue(dtr.GetOrdinal("Detalle_Cliente")).ToString();
                        objDetalleReserva.Tipo = dtr.GetValue(dtr.GetOrdinal("Tipo")).ToString();
                        objDetalleReserva.Cuenta = dtr.GetValue(dtr.GetOrdinal("Cuenta")).ToString();
                        objDetalleReserva.Cantidad = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Cantidad")).ToString());
                        objDetalleReserva.Monto = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("Monto")).ToString());
                        listaDetalleReserva.Add(objDetalleReserva);
                    }
                    dtr.Close();
                }
                cmd.Parameters.Clear();
                return listaDetalleReserva;
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
    }
}
