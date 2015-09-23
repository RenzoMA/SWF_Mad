using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceAdo.MSSQL
{
    public class DetalleReservaSQL : ServicioGenerico<DetalleReservaEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();


        public bool Agregar(DetalleReservaEntity t)
        {
            try
            {
                tb_detalle_reserva objDetalle = new tb_detalle_reserva();
                objDetalle.id_fiesta = t.CodigoFiesta;
                objDetalle.id_reserva = t.CodigoReserva;
                objDetalle.fch_creacion = DateTime.Now;
                objDetalle.usr_crea = t.Usuario;
                msEntities.tb_detalle_reserva.Add(objDetalle);
                msEntities.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(DetalleReservaEntity t)
        {
            try
            {
                tb_detalle_reserva objDetalle = (from det in msEntities.tb_detalle_reserva
                                                 where det.id_detalle == t.Codigo
                                                 select det).FirstOrDefault();

                objDetalle.id_fiesta = t.CodigoFiesta;
                objDetalle.id_reserva = t.CodigoReserva;
                objDetalle.usr_crea = t.Usuario;
                msEntities.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }

        }

        public bool Eliminar(DetalleReservaEntity t)
        {
            try
            {
                tb_detalle_reserva objDetalle = (from det in msEntities.tb_detalle_reserva
                                                 where det.id_detalle==t.Codigo
                                                 select det).FirstOrDefault();
                msEntities.tb_detalle_reserva.Remove(objDetalle);
                msEntities.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public List<DetalleReservaEntity> ListarTodos()
        {
            List<DetalleReservaEntity> objListaDetalle = new List<DetalleReservaEntity>();
            try
            {
                var resultado = msEntities.tb_detalle_reserva.ToList();
                foreach (var result in resultado)
                {
                    DetalleReservaEntity objDetalle = new DetalleReservaEntity();
                    objDetalle.Codigo = result.id_detalle;
                    objDetalle.CodigoFiesta = result.id_fiesta;
                    objDetalle.CodigoReserva = result.id_reserva;
                    objDetalle.Usuario = result.usr_crea;
                    objListaDetalle.Add(objDetalle); 
                }
                return objListaDetalle;
            }
            catch
            {
                return objListaDetalle;
            }
        }

        public DetalleReservaEntity Consultar(object codigo)
        {
            DetalleReservaEntity objDetalle = null;
            int codigoDetalle = Convert.ToInt32(codigo.ToString());
            try
            {
                tb_detalle_reserva objTbDetalle = (from ti in msEntities.tb_detalle_reserva
                                          where ti.id_detalle == codigoDetalle
                                         select ti).FirstOrDefault();

                objDetalle = new DetalleReservaEntity();
                objDetalle.Codigo = objTbDetalle.id_detalle;
                objDetalle.CodigoReserva = objTbDetalle.id_reserva;
                objDetalle.CodigoFiesta = objTbDetalle.id_fiesta;
                objDetalle.FechaCreacion = objTbDetalle.fch_creacion;
                objDetalle.Usuario = objTbDetalle.usr_crea;
                return objDetalle;
            }
            catch
            {
                return null;
            }
        }


        public int Insertar(DetalleReservaEntity t)
        {
            throw new NotImplementedException();
        }


        public List<DetalleReservaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
