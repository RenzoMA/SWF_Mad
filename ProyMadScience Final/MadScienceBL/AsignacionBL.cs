using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceAdo.ACCESS;
using MadScienceBE;
using MadScienceAdo.Servicios;


namespace MadScienceBL
{
    public class AsignacionBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<AsignacionEntity> servicioAsignacion;
        ServicioGenerico<DetalleReservaEntity> servicioDetalleReserva;
        ServicioGenerico<TipoPagoEntity> servicioTipoPago;
        ServicioGenerico<TrabajadorEntity> servicioTrabajador;
        ServicioGenerico<FiestaEntity> servicioFiesta;
        ServicioGenerico<ReservaEntity> servicioReserva;
        TiendaBL tiendaBL;
        FiestaBL fiestaBL;
        TipoFiestaBL tipoFiestaBL;
        DetalleReservaBL detalleReservaBL;
        TipoEventoBL servicioTipoEvento;

        public AsignacionBL()
        {
            servicioAsignacion = servicio.getAsignacion(Constantes.COM);
            servicioDetalleReserva = servicio.getDetalleReserva(Constantes.COM);
            servicioTipoPago = servicio.getTipoPago(Constantes.COM);
            servicioTrabajador = servicio.getTrabajador(Constantes.COM);
            servicioFiesta = servicio.getFiesta(Constantes.COM);
            servicioReserva = servicio.getReserva(Constantes.COM);
            fiestaBL = new FiestaBL();
            tiendaBL = new TiendaBL();
            detalleReservaBL = new DetalleReservaBL();
            tipoFiestaBL = new TipoFiestaBL();
            servicioTipoEvento = new TipoEventoBL();
        }

        public List<AsignacionEntity> ListarAsignado(int codigoDetalle)
        {
            List<AsignacionEntity> listaAsignacion = new AsignacionAccess().ListarPorDetalle(codigoDetalle).Where(tx => tx.CodigoDetalle == codigoDetalle).ToList();
            foreach (AsignacionEntity asig in listaAsignacion)
            {
                asig.NombreTrabajador = servicioTrabajador.Consultar(asig.CodigoTrabajador).Nombre;
                asig.NombreTipoPago = servicioTipoPago.Consultar(asig.CodigoTipoPago).Nombre;
            }
            return listaAsignacion;
        }
    
        public bool Agregar(AsignacionEntity obj)
        {
            if (servicioAsignacion.Agregar(obj))
            {
                ActualizarReserva(obj.CodigoReserva);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int codigo)
        {
            AsignacionEntity objAs = new AsignacionEntity();
            objAs.Codigo = codigo;
            return servicioAsignacion.Eliminar(objAs);
        }

        public void ActualizarReserva(int codigoReserva)
        {
            ReservaEntity objReserva = servicioReserva.Consultar(codigoReserva);
            if (objReserva.Estado != "O")
            {
                List<AsignacionEntity> listaAsignacion = servicioAsignacion.ListarFecha(objReserva.FechaCelebracion,objReserva.FechaCelebracion).Where(tx => tx.CodigoReserva == objReserva.Codigo).ToList();
                List<DetalleReservaEntity> listaDetalle = new DetalleReservaAccess().ListarPorReserva(codigoReserva).ToList();

                var result = from lista in listaAsignacion
                             group lista.CodigoDetalle by lista.CodigoDetalle into g
                             select new { Codigo = g.Key };

                int valida = 0;
                foreach (DetalleReservaEntity deta in listaDetalle)
                {
                    foreach (var asig in result)
                    {
                        if (deta.Codigo == asig.Codigo)
                        {
                            valida = valida + 1;
                        }
                    }
                }
                if (valida == 0)
                {
                    objReserva.Estado = "P";
                }
                if (valida < listaDetalle.Count && valida > 0)
                {
                    objReserva.Estado = "E";
                }
                if (valida == listaDetalle.Count)
                {
                    objReserva.Estado = "A";
                }
                servicioReserva.Actualizar(objReserva);
            }

        }


        public bool EliminarPorReserva(int codigoReserva)
        {
            List<DetalleReservaEntity> listaDetalle = servicioDetalleReserva.ListarTodos().Where(tx => tx.CodigoReserva == codigoReserva).ToList();
            List<AsignacionEntity> listaAsignacion = servicioAsignacion.ListarTodos();

            var query = from detalle in listaDetalle
                        join asignacion in listaAsignacion
                        on detalle.Codigo equals asignacion.CodigoDetalle
                        select new { Codigo = asignacion.Codigo };

            foreach (var resultado in query)
            {
                AsignacionEntity objAsignacion = new AsignacionEntity();
                objAsignacion.Codigo = resultado.Codigo;
                if (!servicioAsignacion.Eliminar(objAsignacion))
                {
                    return false;
                }
            }
            return true;
        }

        public bool EliminarPorDetalle(int codigoDetalle)
        {
            List<AsignacionEntity> listaAsignacion = servicioAsignacion.ListarTodos().Where(tx => tx.CodigoDetalle == codigoDetalle).ToList();
            foreach (AsignacionEntity obj in listaAsignacion)
            {
                if (!servicioAsignacion.Eliminar(obj))
                {
                    return false;
                }
            }
            return true;
        }
        public List<AsignacionEntity> ListarPorUsuario(int codigoTrabajador,DateTime fechaCelebra)
        {
            List<AsignacionEntity> ListaAsignacion = servicioAsignacion.ListarTodos().Where(tx => tx.CodigoTrabajador == codigoTrabajador && tx.FechaReserva == fechaCelebra).ToList();
            List<DetalleReservaEntity> ListaDetalle = servicioDetalleReserva.ListarTodos();

            var query = from asignacion in ListaAsignacion
                        join detalle in ListaDetalle
                        on asignacion.CodigoDetalle equals detalle.Codigo
                        select new { Asig = asignacion,Deta = detalle };

            List<AsignacionEntity> listaCompuesta = new List<AsignacionEntity>();
            foreach (var resultado in query)
            {
                AsignacionEntity objAsi = new AsignacionEntity();
                objAsi.NombreTrabajador = servicioTrabajador.Consultar(resultado.Asig.CodigoTrabajador).Nombre;
                objAsi.NombreFiesta = servicioFiesta.Consultar(resultado.Deta.CodigoFiesta).Nombre;
                objAsi.NombreTienda =new DetalleReservaBL().NombreTienda(resultado.Deta.Codigo);
                objAsi.HoraInicio = resultado.Asig.HoraInicio;
                objAsi.HoraFin = resultado.Asig.HoraFin;
                listaCompuesta.Add(objAsi);
            }

            return listaCompuesta;
        }

        public List<AsignacionEntity> ReporteAsignacion(DateTime fechaInicio, DateTime fechaFin, int codigoTrabajador)
        {
            List<AsignacionEntity> listaAsignaciones;
            if (codigoTrabajador == 0)
            {
                listaAsignaciones = servicioAsignacion.ListarFecha(fechaInicio.Date,fechaFin.Date)
                                                                      .Where(tx => tx.FechaReserva >= fechaInicio && tx.FechaReserva <= fechaFin)
                                                                      .ToList();
            }
            else
            {
                listaAsignaciones = servicioAsignacion.ListarFecha(fechaInicio.Date, fechaFin.Date)
                                                       .Where(tx => tx.FechaReserva >= fechaInicio && tx.FechaReserva <= fechaFin && tx.CodigoTrabajador == codigoTrabajador)
                                                       .ToList();
            }

            List<TrabajadorEntity> listaTrabajador = servicioTrabajador.ListarTodos();
            var query = from asig in listaAsignaciones
                        join tra in listaTrabajador
                        on asig.CodigoTrabajador equals tra.Codigo
                        select new { Asig = asig, Tra = tra };

            foreach (AsignacionEntity asig in listaAsignaciones)
            {
                foreach (var result in query)
                {
                    if (asig.CodigoTrabajador == result.Asig.CodigoTrabajador)
                    {
                        asig.NombreTrabajador = result.Tra.Nombre;
                        break;
                    }
                }
            }

            List<ReservaEntity> listaReserva = servicioReserva.ListarFecha(fechaInicio.Date,fechaFin.Date).Where(tx => tx.FechaCelebracion >= fechaInicio && tx.FechaCelebracion <= fechaFin).ToList();
            List<DetalleReservaEntity> listaDetalles = servicioDetalleReserva.ListarFecha(fechaInicio.Date, fechaFin.Date);

            var query2 = from asig in listaAsignaciones
                         join deta in listaDetalles
                         on asig.CodigoDetalle equals deta.Codigo
                         select new { Asig = asig, Deta = deta };

            foreach (AsignacionEntity asig in listaAsignaciones)
            {
                foreach (var resultado in query2)
                {
                    if (asig.CodigoDetalle == resultado.Deta.Codigo)
                    {
                        FiestaEntity fiesta = fiestaBL.Consultar(resultado.Deta.CodigoFiesta);
                        asig.NombreFiesta = fiesta.Nombre;
                        asig.NombreTipoFiesta = tipoFiestaBL.Consultar(fiesta.CodigoTipoFiesta).Nombre;
                        asig.NombreTienda = detalleReservaBL.NombreTienda(resultado.Deta.Codigo);
                        asig.Direccion = detalleReservaBL.Direccion(resultado.Deta.Codigo);
                        break;
                    }
                }
            }


            return listaAsignaciones;

        }

        public List<AsignacionEntity> ReportePago(DateTime fechaInicio, DateTime fechaFin,int codigoTrabajador)
        {
            List<AsignacionEntity> listaAsignacion;
            if (codigoTrabajador == 0)
            {
                listaAsignacion = servicioAsignacion.ListarFecha(fechaInicio.Date,fechaFin.Date).Where(tx => tx.FechaReserva >= fechaInicio && tx.FechaReserva <= fechaFin).ToList();
            }
            else
            {
                listaAsignacion = servicioAsignacion.ListarFecha(fechaInicio.Date, fechaFin.Date).Where(tx => tx.FechaReserva >= fechaInicio && tx.FechaReserva <= fechaFin && tx.CodigoTrabajador == codigoTrabajador).ToList();
            }

            var cantidad = listaAsignacion.GroupBy(tx => tx.CodigoTrabajador)
                            .Select(gp => new { Detalle = gp.Key, Cuenta = gp.Sum(tx=>tx.Monto) })
                            .OrderBy(x => x.Detalle);

            List<AsignacionEntity> listaCompuesta = new List<AsignacionEntity>();
            foreach (var query in cantidad)
            {
                AsignacionEntity objAsignacion = new AsignacionEntity();
                objAsignacion.NombreTrabajador = servicioTrabajador.Consultar(query.Detalle).Nombre;
                objAsignacion.Monto = query.Cuenta;
                listaCompuesta.Add(objAsignacion);
            }

            return listaCompuesta;

        }
        public List<AsignacionEntity> ListarTodos()
        {
            return servicioAsignacion.ListarTodos();
        }
        public List<ReportePagoDetalle> ReportePagoDetalle(DateTime fechaInicio, DateTime fechaFin, int codigoTrabajador)
        {
            List<AsignacionEntity> listaAsignacion;
            if (codigoTrabajador == 0)
            {
                listaAsignacion = servicioAsignacion.ListarFecha(fechaInicio.Date,fechaFin.Date).Where(tx => tx.FechaReserva >= fechaInicio && tx.FechaReserva <= fechaFin).ToList();
            }
            else
            {
                listaAsignacion = servicioAsignacion.ListarFecha(fechaInicio.Date, fechaFin.Date).Where(tx => tx.FechaReserva >= fechaInicio && tx.FechaReserva <= fechaFin && tx.CodigoTrabajador == codigoTrabajador).ToList();
            }


            List<DetalleReservaEntity> listaDetalle = servicioDetalleReserva.ListarFecha(fechaInicio, fechaFin);
            List<FiestaEntity> listaFiesta = servicioFiesta.ListarTodos();
            List<TipoFiestaEntity> listaTipoFiesta = tipoFiestaBL.ListarTodos();
            List<TrabajadorEntity> listaTrabajador = servicioTrabajador.ListarTodos();
            List<TiendaEntity> listaTienda = tiendaBL.ListarTodos();
            List<ReservaEntity> listaReserva = servicioReserva.ListarFecha(fechaInicio.Date, fechaFin.Date);
            List<TipoEventoEntity> listaTipoEvento = servicioTipoEvento.ListarTodo();


            List<ReportePagoDetalle> listaCompuesta = new List<ReportePagoDetalle>();
            foreach (AsignacionEntity asig in listaAsignacion)
            {
                ReportePagoDetalle report = new ReportePagoDetalle();

                DetalleReservaEntity objDetalle = new DetalleReservaEntity();
                objDetalle =listaDetalle.Where(tx => tx.Codigo == asig.CodigoDetalle).ToList().FirstOrDefault();

                FiestaEntity objFiesta  = new FiestaEntity();
                objFiesta = listaFiesta.Where(tx=>tx.Codigo==objDetalle.CodigoFiesta).FirstOrDefault();

                TipoFiestaEntity objTipo = new TipoFiestaEntity();
                objTipo = listaTipoFiesta.Where(tx=>tx.Codigo==objFiesta.CodigoTipoFiesta).FirstOrDefault();

                TrabajadorEntity objTrabajador = new TrabajadorEntity();
                objTrabajador = listaTrabajador.Where(tx=>tx.Codigo==asig.CodigoTrabajador).FirstOrDefault();

                ReservaEntity reserva = new ReservaEntity();
                reserva = listaReserva.Where(tx=>tx.Codigo==objDetalle.CodigoReserva).FirstOrDefault();

                TiendaEntity objTienda = new TiendaEntity();
                objTienda = listaTienda.Where(tx=>tx.Codigo == reserva.CodigoTienda).FirstOrDefault();

                if (objTienda != null)
                {
                    report.NombreTienda = objTienda.Nombre;
                }
                else
                {
                    TipoEventoEntity objTipoEvento = listaTipoEvento.Where(tx => tx.Codigo == reserva.CodigoTipoEvento).FirstOrDefault();
                    report.NombreTienda = objTipoEvento.Nombre;
                }
                report.NombreFiesta = objFiesta.Nombre;
                report.NombreTrabajador = objTrabajador.Nombre;
                report.TipoFiesta = objTipo.Nombre;
                report.FechaReserva = asig.FechaReserva;
                report.Horario = asig.HoraInicio + " - " + asig.HoraFin;
                report.Pago = asig.Monto;
                listaCompuesta.Add(report);

            }


            return listaCompuesta.OrderBy(tx => tx.NombreTrabajador).ThenBy(tx=>tx.FechaReserva).ToList();

        }
        public List<ReportePagoMovilidad> ReportePagoMovilidad(DateTime fechaInicio, DateTime fechaFin)
        {
            AsignacionAccess objAsignacion = new AsignacionAccess();
            return objAsignacion.ListarPagoMovilidad(fechaInicio.Date, fechaFin.Date);
        }

    }
}
