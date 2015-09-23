using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceAdo.MSSQL
{
    public class AsignacionSQL : ServicioGenerico<AsignacionEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();

        public bool Agregar(AsignacionEntity t)
        {
            try
            {
                tb_asignacion objTbAsignacion = new tb_asignacion();
                objTbAsignacion.id_asignacion = t.Codigo;
                objTbAsignacion.id_detalle = t.CodigoDetalle;
                objTbAsignacion.id_tipo_pago = t.CodigoTipoPago;
                objTbAsignacion.id_trabajador = t.CodigoTrabajador;
                objTbAsignacion.monto = t.Monto;
                objTbAsignacion.fch_creacion = DateTime.Now;
                objTbAsignacion.fch_reserva = t.FechaReserva;
                objTbAsignacion.user_crea = t.UserCrea;
                objTbAsignacion.horaInicio = t.HoraInicio;
                objTbAsignacion.horaFin = t.HoraFin;
                objTbAsignacion.id_reserva = t.CodigoReserva;
                msEntities.tb_asignacion.Add(objTbAsignacion);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(AsignacionEntity t)
        {
            try
            {
                tb_asignacion objTbAsignacion = (from asig in msEntities.tb_asignacion
                                                where asig.id_asignacion == t.Codigo
                                                select asig).FirstOrDefault();
                objTbAsignacion.fch_reserva = t.FechaReserva;
                objTbAsignacion.id_asignacion = t.Codigo;
                objTbAsignacion.id_detalle = t.CodigoDetalle;
                objTbAsignacion.id_tipo_pago = t.CodigoTipoPago;
                objTbAsignacion.id_trabajador = t.CodigoTrabajador;
                objTbAsignacion.monto = t.Monto;
                objTbAsignacion.horaInicio = t.HoraInicio;
                objTbAsignacion.horaFin = t.HoraFin;
                objTbAsignacion.user_crea = t.UserCrea;
                objTbAsignacion.id_reserva = t.CodigoReserva;
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(AsignacionEntity t)
        {
            try
            {
                tb_asignacion objTbAsignacion = (from asig in msEntities.tb_asignacion
                                                 where asig.id_asignacion == t.Codigo
                                                 select asig).FirstOrDefault();
                msEntities.tb_asignacion.Remove(objTbAsignacion);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<AsignacionEntity> ListarTodos()
        {
            List<AsignacionEntity> objListaAsignacion = new List<AsignacionEntity>();
            try
            {
                var query = msEntities.tb_asignacion.ToList();
                foreach (var resultado in query)
                {
                    AsignacionEntity objAsignacion = new AsignacionEntity();
                    objAsignacion.Codigo = resultado.id_asignacion;
                    objAsignacion.CodigoDetalle = resultado.id_detalle;
                    objAsignacion.CodigoTipoPago = resultado.id_tipo_pago;
                    objAsignacion.CodigoTrabajador = resultado.id_trabajador;
                    objAsignacion.FechaCreacion = resultado.fch_creacion;
                    objAsignacion.FechaReserva = resultado.fch_reserva;
                    objAsignacion.Monto = resultado.monto;
                    objAsignacion.HoraInicio = resultado.horaInicio;
                    objAsignacion.HoraFin = resultado.horaFin;
                    objAsignacion.UserCrea = resultado.user_crea;
                    objAsignacion.CodigoReserva = resultado.id_reserva;
                    objListaAsignacion.Add(objAsignacion);
                }
                return objListaAsignacion;
            }
            catch
            {
                return null;
            }
        }

        public AsignacionEntity Consultar(object codigo)
        {
            AsignacionEntity objAsignacion = null;
            try
            {
                int codi = Convert.ToInt16(codigo);
                var query = msEntities.tb_asignacion.ToList().Where(tx => tx.id_asignacion == codi);
                foreach (var resultado in query)
                {
                    objAsignacion.Codigo = resultado.id_asignacion;
                    objAsignacion.CodigoDetalle = resultado.id_detalle;
                    objAsignacion.CodigoTipoPago = resultado.id_tipo_pago;
                    objAsignacion.CodigoTrabajador = resultado.id_trabajador;
                    objAsignacion.FechaCreacion = resultado.fch_creacion;
                    objAsignacion.FechaReserva = resultado.fch_reserva;
                    objAsignacion.Monto = resultado.monto;
                    objAsignacion.HoraInicio = resultado.horaInicio;
                    objAsignacion.HoraFin = resultado.horaFin;
                    objAsignacion.CodigoReserva = resultado.id_reserva;
                    objAsignacion.UserCrea = resultado.user_crea;
                }
                return objAsignacion;
            }
            catch
            {
                return null;
            }
        }

        public int Insertar(AsignacionEntity t)
        {
            throw new NotImplementedException();
        }


        public List<AsignacionEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
