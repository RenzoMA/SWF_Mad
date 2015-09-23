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
    public class DetalleReservaBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<DetalleReservaEntity> servicioDetalle;
        ServicioGenerico<FiestaEntity> servicioFiesta;
        ServicioGenerico<AsignacionEntity> servicioAsignacion;
        ServicioGenerico<TiendaEntity> servicioTienda;
        ServicioGenerico<ReservaEntity> servicioReserva;

        public DetalleReservaBL()
        {
            servicioDetalle = servicio.getDetalleReserva(Constantes.COM);
            servicioFiesta = servicio.getFiesta(Constantes.COM);
            servicioAsignacion = servicio.getAsignacion(Constantes.COM);
            servicioTienda = servicio.getTienda(Constantes.COM);
            servicioReserva = servicio.getReserva(Constantes.COM);
        }

        public bool Agregar(DetalleReservaEntity obj)
        {
            return servicioDetalle.Agregar(obj);
        }
        public DetalleReservaEntity Consultar(int codigo)
        {
            return servicioDetalle.Consultar(codigo);
        }

        public bool Agregar(List<DetalleReservaEntity> lista)
        {
            foreach (DetalleReservaEntity detalle in lista)
            {
                if (!servicioDetalle.Agregar(detalle))
                {
                    return false;
                }
            }
            return true;
        }
        public bool Eliminar(DetalleReservaEntity codigo)
        {
            return servicioDetalle.Eliminar(codigo);
        }

        public List<DetalleReservaEntity> ListarPorReservaReporte(int codigo)
        {
            List<DetalleReservaEntity> listaDetalle = servicioDetalle.ListarTodos().Where(tx => tx.CodigoReserva == codigo).ToList();
            return listaDetalle;
        }
        public List<DetalleReservaEntity> ListarTodos()
        {
            return servicioDetalle.ListarTodos();
        }
        public List<DetalleReservaEntity> ListarPorReserva(int codigo)
        {
           // List<DetalleReservaEntity> listaDetalle = servicioDetalle.ListarTodos().Where(tx => tx.CodigoReserva == codigo).ToList();
            List<DetalleReservaEntity> listaDetalle = new DetalleReservaAccess().ListarPorReserva(codigo);
            List<FiestaEntity> listaFiesta = servicioFiesta.ListarTodos();
            ReservaEntity objReserva = servicioReserva.Consultar(codigo);

            var query = from detalle in listaDetalle
                        join fiesta in listaFiesta
                        on detalle.CodigoFiesta equals fiesta.Codigo
                        select new { Codigo = detalle.Codigo, Fiesta = fiesta.Nombre };

            List<DetalleReservaEntity> listaCompuesta = new List<DetalleReservaEntity>();
            foreach (var resultado in query)
            {
                DetalleReservaEntity objDetalle = new DetalleReservaEntity();
                objDetalle.Codigo = resultado.Codigo;
                objDetalle.NombreFiesta = resultado.Fiesta;
                listaCompuesta.Add(objDetalle);
            }


            List<AsignacionEntity> lista = servicioAsignacion.ListarFecha(objReserva.FechaCelebracion,objReserva.FechaCelebracion);

            var cantidad = lista.GroupBy(tx=>tx.CodigoDetalle)
                                          .Select(gp=>new {Detalle = gp.Key,Cuenta = gp.Count()})
                                          .OrderBy(x=>x.Detalle);

            var query2 = from det in listaCompuesta
                         from can in cantidad.Where(ca=>det.Codigo == ca.Detalle).DefaultIfEmpty()
                         select new { Detalle = det, Cantidad = can };

            List<DetalleReservaEntity> listaFinal = new List<DetalleReservaEntity>();
            foreach (var result in query2)
            {
                DetalleReservaEntity obj = new DetalleReservaEntity();
                obj.Codigo = result.Detalle.Codigo;
                obj.NombreFiesta = result.Detalle.NombreFiesta;
                if (result.Cantidad == null)
                {
                    obj.CantidadAsignados = 0;
                }
                else
                {
                    obj.CantidadAsignados = result.Cantidad.Cuenta;
                }
                listaFinal.Add(obj);
            }


            return listaFinal;
        }
        public string NombreTienda(int codigoDetalle)
        {
            int codigoReserva = servicioDetalle.ListarTodos().Where(tx => tx.Codigo == codigoDetalle).ToList().First().CodigoReserva;
            int? codigoTienda = servicioReserva.Consultar(codigoReserva).CodigoTienda;
            string nombre = codigoTienda == null ? "N/A" : servicioTienda.Consultar(codigoTienda).Nombre;
            return nombre;

        }
        public string Direccion(int codigoDetalle)
        {
            int codigoReserva = servicioDetalle.ListarTodos().Where(tx => tx.Codigo == codigoDetalle).ToList().First().CodigoReserva;
            string direccion = servicioReserva.Consultar(codigoReserva).Direccion;
            return direccion;

        }

    }
}
