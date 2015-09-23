using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;


namespace MadScienceAdo.MSSQL
{
    public class TipoPagoSQL : ServicioGenerico<TipoPagoEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();

        public bool Agregar(TipoPagoEntity t)
        {
            try
            {
                tb_tipo_pago tbTipoPago = new tb_tipo_pago();
                tbTipoPago.flg_estado = t.Estado;
                tbTipoPago.nombre = t.Nombre;
                msEntities.tb_tipo_pago.Add(tbTipoPago);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(TipoPagoEntity t)
        {
            try
            {

                tb_tipo_pago TbTipoPago = (from var in msEntities.tb_tipo_pago
                                           where var.id_tipo_pago == t.Codigo
                                           select var).FirstOrDefault();

                TbTipoPago.flg_estado = t.Estado;
                TbTipoPago.id_tipo_pago = t.Codigo;
                TbTipoPago.nombre = t.Nombre;
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(TipoPagoEntity t)
        {
            try
            {
                tb_tipo_pago TbTipoPago = (from var in msEntities.tb_tipo_pago
                                           where var.id_tipo_pago == t.Codigo
                                           select var).FirstOrDefault();
                msEntities.tb_tipo_pago.Remove(TbTipoPago);
                msEntities.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TipoPagoEntity> ListarTodos()
        {
            List<TipoPagoEntity> objListaTipo = new List<TipoPagoEntity>();
            try
            {
                var query = msEntities.tb_tipo_pago.ToList();
                foreach (var resultado in query)
                {
                    TipoPagoEntity objTipo = new TipoPagoEntity();
                    objTipo.Codigo = resultado.id_tipo_pago;
                    objTipo.Estado = resultado.flg_estado;
                    objTipo.Nombre = resultado.nombre;
                    objListaTipo.Add(objTipo);
                }
                return objListaTipo;
            }
            catch
            {
                return null;
            }
        }

        public TipoPagoEntity Consultar(object codigo)
        {
            try
            {
                int codi = Convert.ToInt32(codigo.ToString());
                tb_tipo_pago TbTipoPago = (from var in msEntities.tb_tipo_pago
                                           where var.id_tipo_pago == codi
                                           select var).FirstOrDefault();

                TipoPagoEntity obj = new TipoPagoEntity();
                obj.Codigo = TbTipoPago.id_tipo_pago;
                obj.Estado = TbTipoPago.flg_estado;
                obj.Nombre = TbTipoPago.nombre;
                return obj;
            }
            catch
            {
                return null;
            }
        }


        public int Insertar(TipoPagoEntity t)
        {
            throw new NotImplementedException();
        }


        public List<TipoPagoEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
