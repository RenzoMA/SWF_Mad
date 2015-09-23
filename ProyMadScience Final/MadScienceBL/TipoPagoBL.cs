using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceAdo.Servicios;
using MadScienceBE;

namespace MadScienceBL
{
    public class TipoPagoBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<TipoPagoEntity> servicioTipoPago;
        ServicioGenerico<PagoFiestaEntity> servicioPagoFiesta;

        public TipoPagoBL()
        {
            servicioTipoPago = servicio.getTipoPago(Constantes.COM);
            servicioPagoFiesta = servicio.getPagoFiesta(Constantes.COM);
        }

        public TipoPagoEntity Consultar(int codigo)
        {
            return servicioTipoPago.Consultar(codigo);
        }

        public List<TipoPagoEntity> ListarTodos()
        {
            List<TipoPagoEntity> lTipoPago = servicioTipoPago.ListarTodos();
            foreach (TipoPagoEntity tipo in lTipoPago)
            {
                tipo.Estado = tipo.Estado == "A" ? "Activo" : "Inactivo";
            }
            return lTipoPago;
        }
        public bool Agregar(TipoPagoEntity obj)
        {
            return servicioTipoPago.Agregar(obj);
        }

        public bool Actualizar(TipoPagoEntity obj)
        {
            return servicioTipoPago.Actualizar(obj);
        }
        public bool ValidarNombre(string nombre,int codigo)
        {
            TipoPagoEntity tipoPago = servicioTipoPago.ListarTodos().Where(tx => tx.Nombre == nombre && tx.Codigo != codigo).ToList().FirstOrDefault();
            if (tipoPago != null)
            {
                return false;
            }
            return true;
        }

        public List<TipoPagoEntity> ListarParaAsignacion(int codigoFiesta)
        {
            List<PagoFiestaEntity> lPagoFiesta = servicioPagoFiesta.ListarTodos().Where(tx => tx.CodigoFiesta == codigoFiesta).ToList();
            List<TipoPagoEntity> lTipoPago = servicioTipoPago.ListarTodos();

            var query = from pago in lPagoFiesta
                        join tipo in lTipoPago
                        on pago.CodigoTipoPago equals tipo.Codigo
                        select tipo;

            List<TipoPagoEntity> listaCompuesta = new List<TipoPagoEntity>();
            foreach (var result in query)
            {
                TipoPagoEntity obj = new TipoPagoEntity();
                obj.Codigo = result.Codigo;
                obj.Nombre = result.Nombre;
                listaCompuesta.Add(obj);
            }
            return listaCompuesta;
        }


     

    }
}
