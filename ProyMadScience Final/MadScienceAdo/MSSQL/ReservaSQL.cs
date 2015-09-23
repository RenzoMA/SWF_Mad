using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;


namespace MadScienceAdo.MSSQL
{
    public class ReservaSQL : ServicioGenerico<ReservaEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();

        public bool Agregar(ReservaEntity t)
        {
            try
            {
                tb_reserva objReserva = new tb_reserva();
                objReserva.celular = t.Celular;
                objReserva.fechaCelebracion = t.FechaCelebracion;
                objReserva.fechaNacimiento = t.FechaNacimiento;
                objReserva.flg_estado = t.Estado;
                objReserva.horaFin = t.HoraFin;
                objReserva.horaInicio = t.HoraInicio;
                objReserva.id_tienda = t.CodigoTienda;
                objReserva.id_tipo_evento = t.CodigoTipoEvento;
                objReserva.id_usuario = t.CodigoUsuario;
                objReserva.invitados = t.Invitados;
                objReserva.modeloTorta = t.ModeloTorta;
                objReserva.nombreCliente = t.NombreCliente;
                objReserva.nombreNiño = t.NombreNiño;
                objReserva.obsGeneral = t.ObsGeneral;
                objReserva.obsTorta2 = t.ObsTorta;
                objReserva.saborTorta = t.SaborTorta;
                objReserva.telefono = t.Telefono;
                objReserva.direccion = t.Direccion;
                objReserva.usr_crea = t.UsuarioCrea;
                objReserva.fch_creacion = t.FechaCrea;
                objReserva.flg_doble = t.FiestaDoble;
                
                msEntities.tb_reserva.Add(objReserva);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }



        public bool Actualizar(ReservaEntity t)
        {
            try
            {
                tb_reserva objReserva = (from reserv in msEntities.tb_reserva
                                         where reserv.id_reserva == t.Codigo
                                         select reserv).FirstOrDefault();
                objReserva.celular = t.Celular;
                objReserva.fechaCelebracion = t.FechaCelebracion;
                objReserva.fechaNacimiento = t.FechaNacimiento;
                objReserva.flg_estado = t.Estado;
                objReserva.horaFin = t.HoraFin;
                objReserva.horaInicio = t.HoraInicio;
                objReserva.id_tienda = t.CodigoTienda;
                objReserva.id_tipo_evento = t.CodigoTipoEvento;
                objReserva.id_usuario = t.CodigoUsuario;
                objReserva.invitados = t.Invitados;
                objReserva.modeloTorta = t.ModeloTorta;
                objReserva.nombreCliente = t.NombreCliente;
                objReserva.nombreNiño = t.NombreNiño;
                objReserva.obsGeneral = t.ObsGeneral;
                objReserva.obsTorta2 = t.ObsTorta;
                objReserva.saborTorta = t.SaborTorta;
                objReserva.telefono = t.Telefono;
                objReserva.direccion = t.Direccion;
                objReserva.flg_doble = t.FiestaDoble;
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Eliminar(ReservaEntity t)
        {
            tb_reserva objReserva = (from reserv in msEntities.tb_reserva
                                     where reserv.id_reserva == t.Codigo
                                     select reserv).FirstOrDefault();

            msEntities.tb_reserva.Remove(objReserva);
            msEntities.SaveChanges();
            return true;
        }

        public List<ReservaEntity> ListarTodos()
        {
            List<ReservaEntity> objListaReserva = new List<ReservaEntity>();
            try
            {
                var query = msEntities.tb_reserva.ToList();
                foreach (var resultado in query)
                {
                    ReservaEntity objReserva = new ReservaEntity();
                    objReserva.Celular = resultado.celular;
                    objReserva.Codigo = resultado.id_reserva;
                    objReserva.CodigoTienda = resultado.id_tienda;
                    objReserva.CodigoTipoEvento = resultado.id_tipo_evento;
                    objReserva.CodigoUsuario = resultado.id_usuario;
                    objReserva.Estado = resultado.flg_estado;
                    objReserva.Direccion = resultado.direccion;
                    objReserva.FechaCelebracion = resultado.fechaCelebracion;
                    objReserva.FechaNacimiento = resultado.fechaNacimiento;
                    objReserva.HoraFin = resultado.horaFin;
                    objReserva.HoraInicio = resultado.horaInicio;
                    objReserva.Invitados = Convert.ToInt32(resultado.invitados);
                    objReserva.ModeloTorta = resultado.modeloTorta;
                    objReserva.NombreCliente = resultado.nombreCliente;
                    objReserva.NombreNiño = resultado.nombreNiño;
                    objReserva.ObsGeneral = resultado.obsGeneral;
                    objReserva.ObsTorta = resultado.obsTorta2;
                    objReserva.SaborTorta = resultado.saborTorta;
                    objReserva.Telefono = resultado.telefono;
                    objReserva.FechaCrea = resultado.fch_creacion;
                    objReserva.UsuarioCrea = resultado.usr_crea;
                    objReserva.FiestaDoble = resultado.flg_doble;
                    objListaReserva.Add(objReserva);
                }
            }
            catch
            {
                return null;
            }
            return objListaReserva;
        }

        public ReservaEntity Consultar(object codigo)
        {
            ReservaEntity objReserva = null;
            try
            {
                int codi = Convert.ToInt32(codigo.ToString());
                var resultado = msEntities.tb_reserva.Where(tx => tx.id_reserva ==codi ).ToList().FirstOrDefault();
                objReserva = new ReservaEntity();
                objReserva.Celular = resultado.celular;
                objReserva.Codigo = resultado.id_reserva;
                objReserva.CodigoTienda = resultado.id_tienda;
                objReserva.CodigoTipoEvento = resultado.id_tipo_evento;
                objReserva.CodigoUsuario = resultado.id_usuario;
                objReserva.Estado = resultado.flg_estado;
                objReserva.FechaCelebracion = resultado.fechaCelebracion;
                objReserva.FechaNacimiento = resultado.fechaNacimiento;
                objReserva.HoraFin = resultado.horaFin;
                objReserva.HoraInicio = resultado.horaInicio;
                objReserva.Direccion = resultado.direccion;
                objReserva.Invitados = Convert.ToInt32(resultado.invitados);
                objReserva.ModeloTorta = resultado.modeloTorta;
                objReserva.NombreCliente = resultado.nombreCliente;
                objReserva.NombreNiño = resultado.nombreNiño;
                objReserva.ObsGeneral = resultado.obsGeneral;
                objReserva.ObsTorta = resultado.obsTorta2;
                objReserva.SaborTorta = resultado.saborTorta;
                objReserva.Telefono = resultado.telefono;
                objReserva.UsuarioCrea = resultado.usr_crea;
                objReserva.FechaCrea = resultado.fch_creacion;
                objReserva.FiestaDoble = resultado.flg_doble;
                return objReserva;
            }
            catch
            {
                return objReserva;
            }

        }


        public int Insertar(ReservaEntity t)
        {
            try
            {
                tb_reserva objReserva = new tb_reserva();
                objReserva.celular = t.Celular;
                objReserva.fechaCelebracion = t.FechaCelebracion;
                objReserva.fechaNacimiento = t.FechaNacimiento;
                objReserva.flg_estado = t.Estado;
                objReserva.horaFin = t.HoraFin;
                objReserva.horaInicio = t.HoraInicio;
                objReserva.id_tienda = t.CodigoTienda;
                objReserva.id_tipo_evento = t.CodigoTipoEvento;
                objReserva.id_usuario = t.CodigoUsuario;
                objReserva.invitados = t.Invitados;
                objReserva.modeloTorta = t.ModeloTorta;
                objReserva.nombreCliente = t.NombreCliente;
                objReserva.nombreNiño = t.NombreNiño;
                objReserva.obsGeneral = t.ObsGeneral;
                objReserva.obsTorta2 = t.ObsTorta;
                objReserva.saborTorta = t.SaborTorta;
                objReserva.telefono = t.Telefono;
                objReserva.direccion = t.Direccion;
                objReserva.flg_doble = t.FiestaDoble;
                objReserva.usr_crea = t.UsuarioCrea;
                objReserva.fch_creacion = DateTime.Now;


                msEntities.tb_reserva.Add(objReserva);
                msEntities.SaveChanges();
                return objReserva.id_reserva;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }


        public List<ReservaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
