using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceAdo.MSSQL
{
    public class PagoFiestaSQL : ServicioGenerico<PagoFiestaEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();


        public bool Agregar(PagoFiestaEntity t)
        {
            try
            {
                tb_pago_fiesta tbPagoFiesta = new tb_pago_fiesta();
                tbPagoFiesta.id_fiesta = t.CodigoFiesta;
                tbPagoFiesta.id_tipo_pago = t.CodigoTipoPago;
                tbPagoFiesta.monto = t.Monto;
                msEntities.tb_pago_fiesta.Add(tbPagoFiesta);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(PagoFiestaEntity t)
        {
            try
            {
                tb_pago_fiesta tbPago = (from pago in msEntities.tb_pago_fiesta
                                         where pago.id_fiesta == t.CodigoFiesta &&
                                         pago.id_tipo_pago == t.CodigoTipoPago
                                         select pago).FirstOrDefault();
                tbPago.id_fiesta = t.CodigoFiesta;
                tbPago.id_tipo_pago = t.CodigoTipoPago;
                tbPago.monto = t.Monto;
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(PagoFiestaEntity t)
        {
            try
            {
                tb_pago_fiesta tbPago = (from pago in msEntities.tb_pago_fiesta
                                         where pago.id_fiesta == t.CodigoFiesta &&
                                         pago.id_tipo_pago == t.CodigoTipoPago
                                         select pago).FirstOrDefault();
                msEntities.tb_pago_fiesta.Remove(tbPago);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<PagoFiestaEntity> ListarTodos()
        {
            List<PagoFiestaEntity> objListaPago = new List<PagoFiestaEntity>();
            try
            {
                var query = msEntities.tb_pago_fiesta.ToList();
                foreach (var resultado in query)
                {
                    PagoFiestaEntity objPagoFiesta = new PagoFiestaEntity();
                    objPagoFiesta.CodigoTipoPago = resultado.id_tipo_pago;
                    objPagoFiesta.CodigoFiesta = resultado.id_fiesta;
                    objPagoFiesta.Monto = resultado.monto;
                    objListaPago.Add(objPagoFiesta);
                }
                return objListaPago;
            }
            catch
            {
                return null;
            }
        }

        public PagoFiestaEntity Consultar(object codigo)
        {
            try
            {
                PagoFiestaEntity t = (PagoFiestaEntity)codigo;
                tb_pago_fiesta tbPago = (from pago in msEntities.tb_pago_fiesta
                                         where pago.id_fiesta == t.CodigoFiesta &&
                                         pago.id_tipo_pago == t.CodigoTipoPago
                                         select pago).FirstOrDefault();
                PagoFiestaEntity objPago = new PagoFiestaEntity();
                objPago.CodigoTipoPago = tbPago.id_tipo_pago;
                objPago.CodigoFiesta = tbPago.id_fiesta;
                objPago.Monto = tbPago.monto;
                return objPago;
            }
            catch
            {
                return null;
            }
        }


        public int Insertar(PagoFiestaEntity t)
        {
            throw new NotImplementedException();
        }


        public List<PagoFiestaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
