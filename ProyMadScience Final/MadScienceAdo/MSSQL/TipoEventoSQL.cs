using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceAdo.MSSQL
{
    public class TipoEventoSQL : ServicioGenerico<TipoEventoEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();

        public bool Agregar(TipoEventoEntity t)
        {
            try
            {
                tb_tipo_evento tbTipoPago = new tb_tipo_evento();
                tbTipoPago.flg_estado = t.Estado;
                tbTipoPago.nombre = t.Nombre;
                msEntities.tb_tipo_evento.Add(tbTipoPago);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(TipoEventoEntity t)
        {
            try
            {

                tb_tipo_evento TbTipoPago = (from var in msEntities.tb_tipo_evento
                                           where var.id_tipo_evento == t.Codigo
                                           select var).FirstOrDefault();

                TbTipoPago.flg_estado = t.Estado;
                TbTipoPago.id_tipo_evento = t.Codigo;
                TbTipoPago.nombre = t.Nombre;
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(TipoEventoEntity t)
        {
            try
            {
                tb_tipo_evento TbTipoPago = (from var in msEntities.tb_tipo_evento
                                           where var.id_tipo_evento == t.Codigo
                                           select var).FirstOrDefault();
                msEntities.tb_tipo_evento.Remove(TbTipoPago);
                msEntities.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TipoEventoEntity> ListarTodos()
        {
            List<TipoEventoEntity> objListaTipo = new List<TipoEventoEntity>();
            try
            {
                var query = msEntities.tb_tipo_evento.ToList();
                foreach (var resultado in query)
                {
                    TipoEventoEntity objTipo = new TipoEventoEntity();
                    objTipo.Codigo = resultado.id_tipo_evento;
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

        public TipoEventoEntity Consultar(object codigo)
        {
            try
            {
                int cod = Convert.ToInt32(codigo.ToString());
                tb_tipo_evento TbTipoPago = (from var in msEntities.tb_tipo_evento
                                           where var.id_tipo_evento == cod
                                           select var).FirstOrDefault();

                TipoEventoEntity obj = new TipoEventoEntity();
                obj.Codigo = TbTipoPago.id_tipo_evento;
                obj.Estado = TbTipoPago.flg_estado;
                obj.Nombre = TbTipoPago.nombre;
                return obj;
            }
            catch
            {
                return null;
            }
        }


        public int Insertar(TipoEventoEntity t)
        {
            throw new NotImplementedException();
        }


        public List<TipoEventoEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
