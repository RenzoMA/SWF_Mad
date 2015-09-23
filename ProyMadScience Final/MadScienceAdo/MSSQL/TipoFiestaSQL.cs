using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceAdo.MSSQL
{
    public class TipoFiestaSQL : ServicioGenerico<TipoFiestaEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();

        public bool Agregar(TipoFiestaEntity t)
        {
            tb_tipo_fiesta tbTipoFiesta = null;
            try
            {
                tbTipoFiesta = new tb_tipo_fiesta();
                tbTipoFiesta.flg_estado = t.Estado;
                tbTipoFiesta.nombre = t.Nombre;
                tbTipoFiesta.fch_creacion = DateTime.Now;
                msEntities.tb_tipo_fiesta.Add(tbTipoFiesta);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                msEntities.tb_tipo_fiesta.Remove(tbTipoFiesta);
                return false;
            }
        }

        public bool Actualizar(TipoFiestaEntity t)
        {
            try
            {

                tb_tipo_fiesta tbTipoFiesta = (from var in msEntities.tb_tipo_fiesta
                                             where var.id_tipo_fiesta == t.Codigo
                                             select var).FirstOrDefault();

                tbTipoFiesta.flg_estado = t.Estado;
                tbTipoFiesta.id_tipo_fiesta = t.Codigo;
                tbTipoFiesta.nombre = t.Nombre;
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(TipoFiestaEntity t)
        {
            try
            {
                tb_tipo_fiesta tbTipoFiesta = (from var in msEntities.tb_tipo_fiesta
                                             where var.id_tipo_fiesta == t.Codigo
                                             select var).FirstOrDefault();
                msEntities.tb_tipo_fiesta.Remove(tbTipoFiesta);
                msEntities.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TipoFiestaEntity> ListarTodos()
        {
            List<TipoFiestaEntity> objListaTipo = new List<TipoFiestaEntity>();
            try
            {
                var query = msEntities.tb_tipo_fiesta.ToList();
                foreach (var resultado in query)
                {
                    TipoFiestaEntity objTipo = new TipoFiestaEntity();
                    objTipo.Codigo = resultado.id_tipo_fiesta;
                    objTipo.Estado = resultado.flg_estado;
                    objTipo.Nombre = resultado.nombre;
                    objTipo.FechaCreacion = resultado.fch_creacion;
                    objListaTipo.Add(objTipo);
                }
                return objListaTipo;
            }
            catch
            {
                return null;
            }
        }

        public TipoFiestaEntity Consultar(object codigo)
        {
            try
            {
                int cod = Convert.ToInt32(codigo.ToString());
                tb_tipo_fiesta tbTipoFiesta = (from var in msEntities.tb_tipo_fiesta
                                             where var.id_tipo_fiesta == cod
                                             select var).FirstOrDefault();

                TipoFiestaEntity obj = new TipoFiestaEntity();
                obj.Codigo = tbTipoFiesta.id_tipo_fiesta;
                obj.Estado = tbTipoFiesta.flg_estado;
                obj.Nombre = tbTipoFiesta.nombre;
                obj.FechaCreacion = tbTipoFiesta.fch_creacion;
                return obj;
            }
            catch
            {
                return null;
            }
        }


        public int Insertar(TipoFiestaEntity t)
        {
            throw new NotImplementedException();
        }


        public List<TipoFiestaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
