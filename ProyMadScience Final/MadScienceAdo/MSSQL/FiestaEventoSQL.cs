using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceAdo.MSSQL
{
    public class FiestaEventoSQL : ServicioGenerico<FiestaEventoEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();

        public bool Agregar(FiestaEventoEntity t)
        {
            try
            {
                tb_fiesta_evento objFiestaEvento = new tb_fiesta_evento();
                objFiestaEvento.fch_creacion = t.FechaCreacion;
                objFiestaEvento.id_fiesta = t.CodigoFiesta;
                objFiestaEvento.id_tipo_evento = t.CodigoTipoEvento;
                msEntities.tb_fiesta_evento.Add(objFiestaEvento);
                msEntities.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }

        }

        public bool Actualizar(FiestaEventoEntity t)
        {
            try
            {
                tb_fiesta_evento objFiestaEvento = (from fEvento in msEntities.tb_fiesta_evento
                                                    where fEvento.id_fiesta == t.CodigoFiesta &&
                                                    fEvento.id_tipo_evento == t.CodigoTipoEvento
                                                    select fEvento).FirstOrDefault();
                objFiestaEvento.fch_creacion = t.FechaCreacion;
                objFiestaEvento.id_fiesta = t.CodigoFiesta;
                objFiestaEvento.id_tipo_evento = t.CodigoTipoEvento;
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(FiestaEventoEntity t)
        {
            try
            {
                tb_fiesta_evento objFiestaEvento = (from fEvento in msEntities.tb_fiesta_evento
                                                    where fEvento.id_fiesta == t.CodigoFiesta &&
                                                    fEvento.id_tipo_evento == t.CodigoTipoEvento
                                                    select fEvento).FirstOrDefault();
                msEntities.tb_fiesta_evento.Remove(objFiestaEvento);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<FiestaEventoEntity> ListarTodos()
        {
            List<FiestaEventoEntity> objListaFiestaEvento = new List<FiestaEventoEntity>();
            try
            {
                var query = msEntities.tb_fiesta_evento.ToList();
                foreach (var resultado in query)
                {
                    FiestaEventoEntity objFiestaEvento = new FiestaEventoEntity();
                    objFiestaEvento.CodigoFiesta = resultado.id_fiesta;
                    objFiestaEvento.CodigoTipoEvento = resultado.id_tipo_evento;
                    objFiestaEvento.FechaCreacion = resultado.fch_creacion;
                    objListaFiestaEvento.Add(objFiestaEvento);
                }
                return objListaFiestaEvento;
            }
            catch
            {
                return null;
            }
        }

        public FiestaEventoEntity Consultar(object codigo)
        {
            FiestaEventoEntity objFiesta = null;
            FiestaEventoEntity t = (FiestaEventoEntity)codigo;
            try
            {
                tb_fiesta_evento objFiestaEvento = (from fEvento in msEntities.tb_fiesta_evento
                                                    where fEvento.id_fiesta == t.CodigoFiesta &&
                                                    fEvento.id_tipo_evento == t.CodigoTipoEvento
                                                    select fEvento).FirstOrDefault();

                objFiesta = new FiestaEventoEntity();
                objFiesta.CodigoFiesta = objFiestaEvento.id_fiesta;
                objFiesta.CodigoTipoEvento = objFiestaEvento.id_tipo_evento;
                objFiesta.FechaCreacion = objFiestaEvento.fch_creacion;
                return objFiesta;

            }
            catch
            {
                return objFiesta;
            }
        }


        public int Insertar(FiestaEventoEntity t)
        {
            throw new NotImplementedException();
        }


        public List<FiestaEventoEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
