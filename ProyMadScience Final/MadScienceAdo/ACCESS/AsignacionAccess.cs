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
    public class AsignacionAccess : ServicioGenerico<AsignacionEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(AsignacionEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql="";
            if (t.TipoMovilidad != null)
            {
                sql = String.Format("insert into tb_asignacion (id_detalle,id_trabajador,id_tipo_pago,monto,fch_reserva,fch_creacion,user_crea,horaInicio,horaFin,id_reserva,id_tipo_movilidad,pago_movilidad) " +
                                            "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                                            t.CodigoDetalle, t.CodigoTrabajador, t.CodigoTipoPago, t.Monto, t.FechaReserva, t.FechaCreacion, t.UserCrea, t.HoraInicio, t.HoraFin, t.CodigoReserva, t.TipoMovilidad, t.MontoMovilidad);
            }
            else
            {
                sql = String.Format("insert into tb_asignacion (id_detalle,id_trabajador,id_tipo_pago,monto,fch_reserva,fch_creacion,user_crea,horaInicio,horaFin,id_reserva,pago_movilidad) " +
                                            "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                                            t.CodigoDetalle, t.CodigoTrabajador, t.CodigoTipoPago, t.Monto, t.FechaReserva, t.FechaCreacion, t.UserCrea, t.HoraInicio, t.HoraFin, t.CodigoReserva, t.MontoMovilidad);
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

        public bool Actualizar(AsignacionEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = String.Format("update tb_asignacion set id_detalle = '{0}', id_trabajador = '{1}', id_tipo_pago ='{2}',monto ='{3}',fch_reserva='{4}',user_crea='{5}',horaInicio='{6}',horaFin='{7}',id_reserva='{8}',id_tipo_movilidad='{9}',pago_movilidad='{10}' " +
                                        "where id_asignacion = {11}",
                                        t.CodigoDetalle, t.CodigoTrabajador, t.CodigoTipoPago, t.Monto, t.FechaReserva, t.UserCrea, t.HoraInicio, t.HoraFin, t.CodigoReserva,t.TipoMovilidad,t.MontoMovilidad,t.Codigo);
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

        public bool Eliminar(AsignacionEntity t)
        {
            try
            {

                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("DELETE FROM TB_ASIGNACION where id_asignacion = {0}"
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

        public List<AsignacionEntity> ListarTodos()
        {
            List<AsignacionEntity> listaAsignacion = new List<AsignacionEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_ASIGNACION";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        AsignacionEntity objAsignacion = new AsignacionEntity();
                        objAsignacion.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_asignacion")).ToString());
                        objAsignacion.CodigoDetalle = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_detalle")).ToString());
                        objAsignacion.CodigoTrabajador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_trabajador")).ToString());
                        objAsignacion.CodigoTipoPago = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_pago")).ToString());
                        objAsignacion.Monto = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("monto")).ToString());
                        objAsignacion.FechaReserva = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fch_reserva")).ToString());
                        objAsignacion.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString());
                        objAsignacion.UserCrea = dtr.GetValue(dtr.GetOrdinal("user_crea")).ToString();
                        objAsignacion.HoraInicio = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("horaInicio")).ToString());
                        objAsignacion.HoraFin = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("horaFin")).ToString());
                        objAsignacion.CodigoReserva = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_reserva")).ToString());

                        String monto = dtr.GetValue(dtr.GetOrdinal("pago_movilidad")).ToString();
                        if (monto != "")
                        {
                            objAsignacion.MontoMovilidad = Convert.ToDouble(monto);
                        }
                        else
                        {
                            objAsignacion.MontoMovilidad = 0;
                        }
                        String tipo = dtr.GetValue(dtr.GetOrdinal("id_tipo_movilidad")).ToString();
                        if (tipo != "")
                        {
                            objAsignacion.TipoMovilidad = Convert.ToInt16(tipo);
                        }
                        else
                        {
                            objAsignacion.TipoMovilidad = null;
                        }
                        


                        listaAsignacion.Add(objAsignacion);
                    }
                    dtr.Close();
                }
                return listaAsignacion;
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

        public AsignacionEntity Consultar(object codigo)
        {
            AsignacionEntity objAsignacion = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_ASIGNACION where id_asignacion = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                        objAsignacion = new AsignacionEntity();
                        objAsignacion.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_asignacion")).ToString());
                        objAsignacion.CodigoDetalle = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_detalle")).ToString());
                        objAsignacion.CodigoTrabajador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_trabajador")).ToString());
                        objAsignacion.CodigoTipoPago = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_pago")).ToString());
                        objAsignacion.Monto = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("monto")).ToString());
                        objAsignacion.FechaReserva = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fch_reserva")).ToString());
                        objAsignacion.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString());
                        objAsignacion.UserCrea = dtr.GetValue(dtr.GetOrdinal("user_crea")).ToString();
                        objAsignacion.HoraInicio = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("horaInicio")).ToString());
                        objAsignacion.HoraFin = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("horaFin")).ToString());
                        objAsignacion.CodigoReserva = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_reserva")).ToString());
                        objAsignacion.MontoMovilidad = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("pago_movilidad")).ToString());
                        objAsignacion.TipoMovilidad = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_movilidad")).ToString());

                    dtr.Close();
                }
                return objAsignacion;
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

        public int Insertar(AsignacionEntity t)
        {
            throw new NotImplementedException();
        }


        public List<AsignacionEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            List<AsignacionEntity> listaAsignacion = new List<AsignacionEntity>();
            try
            {
                cmd = new OleDbCommand();
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = "Select * from tb_asignacion where fch_reserva between @inicio and @fin";
                cmd.CommandText = sql;

                OleDbParameter paramInicio = new OleDbParameter("@inicio", OleDbType.Date);
                OleDbParameter paramFin = new OleDbParameter("@fin", OleDbType.Date);
                paramInicio.Value = fechaInicio;
                paramFin.Value = fechaFin;
                cmd.Parameters.Add(paramInicio);
                cmd.Parameters.Add(paramFin);
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        AsignacionEntity objAsignacion = new AsignacionEntity();
                        objAsignacion.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_asignacion")).ToString());
                        objAsignacion.CodigoDetalle = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_detalle")).ToString());
                        objAsignacion.CodigoTrabajador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_trabajador")).ToString());
                        objAsignacion.CodigoTipoPago = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_pago")).ToString());
                        objAsignacion.Monto = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("monto")).ToString());
                        objAsignacion.FechaReserva = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fch_reserva")).ToString());
                        objAsignacion.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString());
                        objAsignacion.UserCrea = dtr.GetValue(dtr.GetOrdinal("user_crea")).ToString();
                        objAsignacion.HoraInicio = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("horaInicio")).ToString());
                        objAsignacion.HoraFin = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("horaFin")).ToString());
                        objAsignacion.CodigoReserva = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_reserva")).ToString());

                        String monto = dtr.GetValue(dtr.GetOrdinal("pago_movilidad")).ToString();
                        if (monto != "")
                        {
                            objAsignacion.MontoMovilidad = Convert.ToDouble(monto);
                        }
                        else
                        {
                            objAsignacion.MontoMovilidad = 0;
                        }
                        String tipo = dtr.GetValue(dtr.GetOrdinal("id_tipo_movilidad")).ToString();
                        if (tipo != "")
                        {
                            objAsignacion.TipoMovilidad = Convert.ToInt16(tipo);
                        }
                        else
                        {
                            objAsignacion.TipoMovilidad = null;
                        }



                        listaAsignacion.Add(objAsignacion);
                    }
                    dtr.Close();
                }
                cmd.Parameters.Clear();
                return listaAsignacion;
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
        public List<AsignacionEntity> ListarPorDetalle(int codigoDetalle)
        {
            List<AsignacionEntity> listaAsignacion = new List<AsignacionEntity>();
            try
            {
                cmd = new OleDbCommand();
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = "Select * from tb_asignacion where id_detalle = @codigo";
                cmd.CommandText = sql;

                OleDbParameter paramInicio = new OleDbParameter("@codigo", OleDbType.Integer);
                paramInicio.Value = codigoDetalle;
                cmd.Parameters.Add(paramInicio);

                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        AsignacionEntity objAsignacion = new AsignacionEntity();
                        objAsignacion.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_asignacion")).ToString());
                        objAsignacion.CodigoDetalle = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_detalle")).ToString());
                        objAsignacion.CodigoTrabajador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_trabajador")).ToString());
                        objAsignacion.CodigoTipoPago = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_pago")).ToString());
                        objAsignacion.Monto = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("monto")).ToString());
                        objAsignacion.FechaReserva = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fch_reserva")).ToString());
                        objAsignacion.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString());
                        objAsignacion.UserCrea = dtr.GetValue(dtr.GetOrdinal("user_crea")).ToString();
                        objAsignacion.HoraInicio = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("horaInicio")).ToString());
                        objAsignacion.HoraFin = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("horaFin")).ToString());
                        objAsignacion.CodigoReserva = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_reserva")).ToString());

                        String monto = dtr.GetValue(dtr.GetOrdinal("pago_movilidad")).ToString();
                        if (monto != "")
                        {
                            objAsignacion.MontoMovilidad = Convert.ToDouble(monto);
                        }
                        else
                        {
                            objAsignacion.MontoMovilidad = 0;
                        }
                        String tipo = dtr.GetValue(dtr.GetOrdinal("id_tipo_movilidad")).ToString();
                        if (tipo != "")
                        {
                            objAsignacion.TipoMovilidad = Convert.ToInt16(tipo);
                        }
                        else
                        {
                            objAsignacion.TipoMovilidad = null;
                        }



                        listaAsignacion.Add(objAsignacion);
                    }
                    dtr.Close();
                }
                cmd.Parameters.Clear();
                return listaAsignacion;
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

        public List<ReportePagoMovilidad> ListarPagoMovilidad(DateTime fechaInicio, DateTime fechaFin)
        {
            List<ReportePagoMovilidad> listaPagoMovilidad = new List<ReportePagoMovilidad>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;

                string sql = "select " +
                            " tra.nombre,tra.cod_planilla," +
                            " tfi.nombre as [TipoFiesta]," +
                            " count(tfi.nombre) as [CantidadTipoFiesta]," +
                            " tpago.nombre as [TipoPago]," +
                            " count(tpago.nombre) as [CantidadTipoPago]," +
                            " sum(asi.monto) as [MontoPago]," +
                            " tmovi.des_nombre as [Movilidad]," +
                            " sum(asi.pago_movilidad) as [PagoMovilidad]," +
                            " sum(asi.pago_movilidad)+sum(asi.monto) as [Total]" +
                            " from " +
                            " ((((((tb_reserva re " +
                            " inner join tb_detalle_reserva dr on" +
                            " re.id_reserva = dr.id_reserva)" +
                            " inner join tb_fiesta fi on" +
                            " fi.id_fiesta = dr.id_fiesta)" +
                            " inner join tb_asignacion asi" +
                            " on asi.id_detalle = dr.id_detalle)" +
                            " inner join tb_tipo_fiesta tfi" +
                            " on tfi.id_tipo_fiesta = fi.id_tipo_fiesta)" +
                            " inner join tb_trabajador tra" +
                            " on tra.id_trabajador = asi.id_trabajador)" +
                            " inner join tb_tipo_pago tpago on" +
                            " tpago.id_tipo_pago = asi.id_tipo_pago)" +
                            " left join tb_tipo_movilidad tmovi" +
                            " on tmovi.id_tipo_movilidad = asi.id_tipo_movilidad" +
                            " where re.fechaCelebracion between @inicio and @fin" +
                            " group by tfi.nombre,tra.nombre,tpago.nombre,tmovi.des_nombre,tra.cod_planilla" +
                            " order by 1,2";

                cmd.CommandText = sql;
                OleDbParameter paramInicio = new OleDbParameter("@inicio", OleDbType.Date);
                OleDbParameter paramFin = new OleDbParameter("@fin", OleDbType.Date);
                paramInicio.Value = fechaInicio;
                paramFin.Value = fechaFin;
                cmd.Parameters.Add(paramInicio);
                cmd.Parameters.Add(paramFin);


                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        ReportePagoMovilidad objReporte = new ReportePagoMovilidad();
                        objReporte.Nombre = dtr.GetValue(dtr.GetOrdinal("nombre")).ToString();
                        objReporte.TipoFiesta = dtr.GetValue(dtr.GetOrdinal("TipoFiesta")).ToString();
                        objReporte.CantidadTipoFiesta = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("CantidadTipoFiesta")).ToString());
                        objReporte.TipoPago = dtr.GetValue(dtr.GetOrdinal("TipoPago")).ToString();
                        objReporte.CantidadTipoPago = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("CantidadTipoPago")).ToString());
                        objReporte.MontoTipoPago = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("MontoPago")).ToString());
                        objReporte.TipoMovilidad = dtr.GetValue(dtr.GetOrdinal("Movilidad")).ToString();
                        objReporte.MontoMovilidad = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("PagoMovilidad")).ToString());
                        objReporte.MontoTotal = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("Total")).ToString());
                        objReporte.CodigoFacturacion = dtr.GetValue(dtr.GetOrdinal("cod_planilla")).ToString();

                        listaPagoMovilidad.Add(objReporte);
                    }
                    dtr.Close();
                }
                cmd.Parameters.Clear();

                return listaPagoMovilidad;
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
