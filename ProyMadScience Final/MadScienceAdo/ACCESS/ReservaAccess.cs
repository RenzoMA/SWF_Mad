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
    public class ReservaAccess : ServicioGenerico<ReservaEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(ReservaEntity t)
        {
            throw new NotImplementedException();
        }

        public bool Actualizar(ReservaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql = "";
            if (t.CodigoTienda == null)
            {
                sql = String.Format("update tb_reserva set id_tipo_evento='{0}',id_tienda=null, id_usuario='{1}', direccion = '{2}', nombreNiño = '{3}', fechaNacimiento='{4}',telefono='{5}',celular='{6}',nombreCliente='{7}',fechaCelebracion='{8}',horaInicio='{9}',horaFin='{10}',modeloTorta='{11}',saborTorta='{12}',obsTorta2='{13}',invitados='{14}',obsGeneral='{15}',flg_estado='{16}',usr_crea='{17}',flg_doble='{18}' where id_reserva ={19}", t.CodigoTipoEvento, t.CodigoUsuario, t.Direccion, t.NombreNiño, t.FechaNacimiento, t.Telefono, t.Celular, t.NombreCliente, t.FechaCelebracion, t.HoraInicio, t.HoraFin, t.ModeloTorta, t.SaborTorta, t.ObsTorta, t.Invitados, t.ObsGeneral, t.Estado, t.UsuarioCrea,t.FiestaDoble, t.Codigo);
            }
            else
            {
                sql = String.Format("update tb_reserva set id_tipo_evento='{0}',id_tienda='{1}', id_usuario='{2}', direccion = '{3}', nombreNiño = '{4}', fechaNacimiento='{5}',telefono='{6}',celular='{7}',nombreCliente='{8}',fechaCelebracion='{9}',horaInicio='{10}',horaFin='{11}',modeloTorta='{12}',saborTorta='{13}',obsTorta2='{14}',invitados='{15}',obsGeneral='{16}',flg_estado='{17}',usr_crea='{18}',flg_doble='{19}' where id_reserva ={20}", t.CodigoTipoEvento, t.CodigoTienda, t.CodigoUsuario, t.Direccion, t.NombreNiño, t.FechaNacimiento, t.Telefono, t.Celular, t.NombreCliente, t.FechaCelebracion, t.HoraInicio, t.HoraFin, t.ModeloTorta, t.SaborTorta, t.ObsTorta, t.Invitados, t.ObsGeneral, t.Estado, t.UsuarioCrea,t.FiestaDoble, t.Codigo);
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

        public bool Eliminar(ReservaEntity t)
        {
            int codigo = t.Codigo;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("DELETE FROM TB_RESERVA where id_reserva = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

        public List<ReservaEntity> ListarTodos()
        {
            List<ReservaEntity> listaReservas = new List<ReservaEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_RESERVA";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        ReservaEntity objReserva = new ReservaEntity();
                        objReserva.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_reserva")).ToString());
                        objReserva.CodigoTipoEvento = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_evento")).ToString());
                        String tienda = dtr.GetValue(dtr.GetOrdinal("id_tienda")).ToString();
                        if (tienda == "")
                        {
                            objReserva.CodigoTienda = null;
                        }
                        else
                        {
                            objReserva.CodigoTienda = Convert.ToInt16(tienda);
                        }
                        objReserva.CodigoUsuario = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_usuario")).ToString());
                        objReserva.Direccion = (dtr.GetValue(dtr.GetOrdinal("direccion")).ToString());
                        objReserva.NombreNiño = (dtr.GetValue(dtr.GetOrdinal("nombreNiño")).ToString());
                        objReserva.FechaNacimiento = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fechaNacimiento")).ToString()));
                        objReserva.Telefono = (dtr.GetValue(dtr.GetOrdinal("telefono")).ToString());
                        objReserva.Celular = (dtr.GetValue(dtr.GetOrdinal("celular")).ToString());
                        objReserva.NombreCliente = (dtr.GetValue(dtr.GetOrdinal("nombreCliente")).ToString());
                        objReserva.FechaCelebracion = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fechaCelebracion")).ToString()));
                        objReserva.HoraInicio = Convert.ToDouble((dtr.GetValue(dtr.GetOrdinal("horaInicio")).ToString()));
                        objReserva.HoraFin = Convert.ToDouble((dtr.GetValue(dtr.GetOrdinal("horaFin")).ToString()));
                        objReserva.ModeloTorta = (dtr.GetValue(dtr.GetOrdinal("modeloTorta")).ToString());
                        objReserva.SaborTorta = dtr.GetValue(dtr.GetOrdinal("saborTorta")).ToString();
                        objReserva.ObsTorta = dtr.GetValue(dtr.GetOrdinal("obsTorta2")).ToString();
                        objReserva.Invitados = Convert.ToInt16((dtr.GetValue(dtr.GetOrdinal("invitados")).ToString()));
                        objReserva.ObsGeneral = dtr.GetValue(dtr.GetOrdinal("obsGeneral")).ToString();
                        objReserva.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                        objReserva.UsuarioCrea = dtr.GetValue(dtr.GetOrdinal("usr_crea")).ToString();
                        objReserva.FechaCrea = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString()));
                        objReserva.FiestaDoble = dtr.GetValue(dtr.GetOrdinal("flg_doble")).ToString();
                        objReserva.UltimaHora = dtr.GetValue(dtr.GetOrdinal("ultima_hora")).ToString();
                        listaReservas.Add(objReserva);
                    }
                    dtr.Close();
                }
                return listaReservas;
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

        public ReservaEntity Consultar(object codigo)
        {
            ReservaEntity objReserva = null;
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = String.Format("SELECT * FROM TB_RESERVA where id_reserva = {0}", codigo.ToString());
                cmd.CommandText = sql;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    dtr.Read();

                    objReserva = new ReservaEntity();
                    objReserva.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_reserva")).ToString());
                    objReserva.CodigoTipoEvento = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_evento")).ToString());
                    String tienda = dtr.GetValue(dtr.GetOrdinal("id_tienda")).ToString();
                    if (tienda == "")
                    {
                        objReserva.CodigoTienda = null;
                    }
                    else
                    {
                        objReserva.CodigoTienda = Convert.ToInt16(tienda);
                    }
                    objReserva.CodigoUsuario = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_usuario")).ToString());
                    objReserva.Direccion = (dtr.GetValue(dtr.GetOrdinal("direccion")).ToString());
                    objReserva.NombreNiño = (dtr.GetValue(dtr.GetOrdinal("nombreNiño")).ToString());
                    objReserva.FechaNacimiento = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fechaNacimiento")).ToString()));
                    objReserva.Telefono = (dtr.GetValue(dtr.GetOrdinal("telefono")).ToString());
                    objReserva.Celular = (dtr.GetValue(dtr.GetOrdinal("celular")).ToString());
                    objReserva.NombreCliente = (dtr.GetValue(dtr.GetOrdinal("nombreCliente")).ToString());
                    objReserva.FechaCelebracion = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fechaCelebracion")).ToString()));
                    objReserva.HoraInicio = Convert.ToDouble((dtr.GetValue(dtr.GetOrdinal("horaInicio")).ToString()));
                    objReserva.HoraFin = Convert.ToDouble((dtr.GetValue(dtr.GetOrdinal("horaFin")).ToString()));
                    objReserva.ModeloTorta = (dtr.GetValue(dtr.GetOrdinal("modeloTorta")).ToString());
                    objReserva.SaborTorta = dtr.GetValue(dtr.GetOrdinal("saborTorta")).ToString();
                    objReserva.ObsTorta = dtr.GetValue(dtr.GetOrdinal("obsTorta2")).ToString();
                    objReserva.Invitados = Convert.ToInt16((dtr.GetValue(dtr.GetOrdinal("invitados")).ToString()));
                    objReserva.ObsGeneral = dtr.GetValue(dtr.GetOrdinal("obsGeneral")).ToString();
                    objReserva.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                    objReserva.UsuarioCrea = dtr.GetValue(dtr.GetOrdinal("usr_crea")).ToString();
                    objReserva.FechaCrea = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString()));
                    objReserva.FiestaDoble = dtr.GetValue(dtr.GetOrdinal("flg_doble")).ToString();
                    objReserva.UltimaHora = dtr.GetValue(dtr.GetOrdinal("ultima_hora")).ToString();
                    dtr.Close();
                }
                return objReserva;
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


        public int Insertar(ReservaEntity t)
        {
            cnx.ConnectionString = MiConex.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            String sql;
            if (t.CodigoTienda == null)
            {
                sql = String.Format("insert into tb_reserva (id_tipo_evento,id_usuario,direccion,nombreNiño,fechaNacimiento,telefono,celular,nombreCliente,fechaCelebracion,horaInicio,horaFin,modeloTorta,saborTorta,obsTorta2,invitados,obsGeneral,flg_estado,usr_crea,fch_creacion,flg_doble,ultima_hora) " +
                                            "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')",
                                            t.CodigoTipoEvento, t.CodigoUsuario, t.Direccion, t.NombreNiño, t.FechaNacimiento, t.Telefono, t.Celular, t.NombreCliente, t.FechaCelebracion, t.HoraInicio, t.HoraFin, t.ModeloTorta, t.SaborTorta, t.ObsTorta, t.Invitados, t.ObsGeneral, t.Estado, t.UsuarioCrea, DateTime.Now,t.FiestaDoble,t.UltimaHora);
            }
            else
            {
                sql = String.Format("insert into tb_reserva (id_tipo_evento,id_tienda,id_usuario,direccion,nombreNiño,fechaNacimiento,telefono,celular,nombreCliente,fechaCelebracion,horaInicio,horaFin,modeloTorta,saborTorta,obsTorta2,invitados,obsGeneral,flg_estado,usr_crea,fch_creacion,flg_doble,ultima_hora) " +
                                            "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}')",
                                            t.CodigoTipoEvento, t.CodigoTienda,t.CodigoUsuario, t.Direccion, t.NombreNiño, t.FechaNacimiento, t.Telefono, t.Celular, t.NombreCliente, t.FechaCelebracion, t.HoraInicio, t.HoraFin, t.ModeloTorta, t.SaborTorta, t.ObsTorta, t.Invitados, t.ObsGeneral, t.Estado, t.UsuarioCrea, DateTime.Now,t.FiestaDoble,t.UltimaHora);
            }
            String sql2 = "SELECT @@Identity";

            cmd.CommandText = sql;
            try
            {
                cnx.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = sql2;
                t.Codigo = Convert.ToInt16(cmd.ExecuteScalar());
                return t.Codigo;

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


        public List<ReservaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            List<ReservaEntity> listaReservas = new List<ReservaEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                string sql = "select * from tb_Reserva where fechaCelebracion between @inicio and @fin";
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
                        ReservaEntity objReserva = new ReservaEntity();
                        objReserva.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_reserva")).ToString());
                        objReserva.CodigoTipoEvento = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_tipo_evento")).ToString());
                        String tienda = dtr.GetValue(dtr.GetOrdinal("id_tienda")).ToString();
                        if (tienda == "")
                        {
                            objReserva.CodigoTienda = null;
                        }
                        else
                        {
                            objReserva.CodigoTienda = Convert.ToInt16(tienda);
                        }
                        objReserva.CodigoUsuario = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_usuario")).ToString());
                        objReserva.Direccion = (dtr.GetValue(dtr.GetOrdinal("direccion")).ToString());
                        objReserva.NombreNiño = (dtr.GetValue(dtr.GetOrdinal("nombreNiño")).ToString());
                        objReserva.FechaNacimiento = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fechaNacimiento")).ToString()));
                        objReserva.Telefono = (dtr.GetValue(dtr.GetOrdinal("telefono")).ToString());
                        objReserva.Celular = (dtr.GetValue(dtr.GetOrdinal("celular")).ToString());
                        objReserva.NombreCliente = (dtr.GetValue(dtr.GetOrdinal("nombreCliente")).ToString());
                        objReserva.FechaCelebracion = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fechaCelebracion")).ToString()));
                        objReserva.HoraInicio = Convert.ToDouble((dtr.GetValue(dtr.GetOrdinal("horaInicio")).ToString()));
                        objReserva.HoraFin = Convert.ToDouble((dtr.GetValue(dtr.GetOrdinal("horaFin")).ToString()));
                        objReserva.ModeloTorta = (dtr.GetValue(dtr.GetOrdinal("modeloTorta")).ToString());
                        objReserva.SaborTorta = dtr.GetValue(dtr.GetOrdinal("saborTorta")).ToString();
                        objReserva.ObsTorta = dtr.GetValue(dtr.GetOrdinal("obsTorta2")).ToString();
                        objReserva.Invitados = Convert.ToInt16((dtr.GetValue(dtr.GetOrdinal("invitados")).ToString()));
                        objReserva.ObsGeneral = dtr.GetValue(dtr.GetOrdinal("obsGeneral")).ToString();
                        objReserva.Estado = dtr.GetValue(dtr.GetOrdinal("flg_estado")).ToString();
                        objReserva.UsuarioCrea = dtr.GetValue(dtr.GetOrdinal("usr_crea")).ToString();
                        objReserva.FechaCrea = Convert.ToDateTime((dtr.GetValue(dtr.GetOrdinal("fch_creacion")).ToString()));
                        objReserva.FiestaDoble = dtr.GetValue(dtr.GetOrdinal("flg_doble")).ToString();
                        objReserva.UltimaHora = dtr.GetValue(dtr.GetOrdinal("ultima_hora")).ToString();
                        listaReservas.Add(objReserva);
                    }
                    dtr.Close();
                }
                cmd.Parameters.Clear();
                return listaReservas;
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
