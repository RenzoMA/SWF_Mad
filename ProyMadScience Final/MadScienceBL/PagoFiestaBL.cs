using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceAdo.Servicios;
using MadScienceBE;

namespace MadScienceBL
{
    public class PagoFiestaBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<PagoFiestaEntity> servicioPagoFiesta;
        ServicioGenerico<TipoPagoEntity> servicioTipoPago;

        public PagoFiestaBL()
        {
            servicioPagoFiesta = servicio.getPagoFiesta(Constantes.COM);
            servicioTipoPago = servicio.getTipoPago(Constantes.COM);
        }

        public bool Agregar(PagoFiestaEntity obj)
        {
            return servicioPagoFiesta.Agregar(obj);
        }

        public bool Eliminar(PagoFiestaEntity obj)
        {
            return servicioPagoFiesta.Eliminar(obj);
        }

        public PagoFiestaEntity Consultar(PagoFiestaEntity obj)
        {
            return servicioPagoFiesta.Consultar(obj);
        }

        public List<PagoFiestaEntity> ListaPorFiesta(int codigoFiesta)
        {
            List<PagoFiestaEntity> lFiesta = servicioPagoFiesta.ListarTodos().Where(tx => tx.CodigoFiesta == codigoFiesta).ToList();
            List<TipoPagoEntity> lTipoPago = servicioTipoPago.ListarTodos();

            List<PagoFiestaEntity> lista = new List<PagoFiestaEntity>();
            var query = from pagoFiesta in lFiesta
                        join tipo in lTipoPago
                        on pagoFiesta.CodigoTipoPago equals tipo.Codigo
                        select new { CodigoPago = pagoFiesta.CodigoTipoPago, Monto = pagoFiesta.Monto, Tipo = tipo.Nombre };

            foreach (var resultado in query)
            {
                PagoFiestaEntity obj = new PagoFiestaEntity();
                obj.CodigoTipoPago = resultado.CodigoPago;
                obj.NombreTipoPago = resultado.Tipo;
                obj.Monto = resultado.Monto;
                lista.Add(obj);
            }
            return lista;

        }

        public bool ValidarDuplicidad(PagoFiestaEntity obj)
        {
            PagoFiestaEntity objPago = servicioPagoFiesta.ListarTodos()
                                       .Where(tx => tx.CodigoTipoPago == obj.CodigoTipoPago && tx.CodigoFiesta == obj.CodigoFiesta)
                                       .ToList().FirstOrDefault();
            if (objPago != null)
            {
                return false;
            }
            return true;
        }

        public List<PagoFiestaEntity> ListarTodos()
        {
            return servicioPagoFiesta.ListarTodos();
        }

       
    }
}
