using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceAdo.MSSQL
{
    public class FiestaSQL : ServicioGenerico<FiestaEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();

        public bool Agregar(FiestaEntity t)
        {
            try
            {
                tb_fiesta objFiesta = new tb_fiesta();
                objFiesta.flg_estado = t.Estado;
                objFiesta.nombre = t.Nombre;
                objFiesta.id_tipo_fiesta = t.CodigoTipoFiesta;
                msEntities.tb_fiesta.Add(objFiesta);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(FiestaEntity t)
        {
            try
            {
                tb_fiesta objFiesta = (from fi in msEntities.tb_fiesta
                                       where fi.id_fiesta == t.Codigo
                                       select fi).FirstOrDefault();
                objFiesta.flg_estado = t.Estado;
                objFiesta.id_fiesta = t.Codigo;
                objFiesta.id_tipo_fiesta = t.CodigoTipoFiesta;
                objFiesta.nombre = t.Nombre;
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(FiestaEntity t)
        {
            try
            {
                tb_fiesta objFiesta = (from fi in msEntities.tb_fiesta
                                       where fi.id_fiesta == t.Codigo
                                       select fi).FirstOrDefault();
                msEntities.tb_fiesta.Remove(objFiesta);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<FiestaEntity> ListarTodos()
        {
            List<FiestaEntity> objListaFiesta = new List<FiestaEntity>();
            try
            {
                var query = msEntities.tb_fiesta.ToList();
                foreach (var resultado in query)
                {
                    FiestaEntity objFiesta = new FiestaEntity();

                    objFiesta.Codigo = resultado.id_fiesta;
                    objFiesta.Estado = resultado.flg_estado;
                    objFiesta.Nombre = resultado.nombre;
                    objFiesta.CodigoTipoFiesta = resultado.id_tipo_fiesta;
                    objListaFiesta.Add(objFiesta);
                }
                return objListaFiesta;
            }
            catch
            {
                return null;
            }
        }

        public FiestaEntity Consultar(object codigo)
        {
            FiestaEntity objFiesta = null;
            try
            {
                int codi= Convert.ToInt32(codigo.ToString());
                var query = msEntities.tb_fiesta.ToList().Where(tx => tx.id_fiesta == codi);
                foreach (var resultado in query)
                {
                    objFiesta = new FiestaEntity();

                    objFiesta.Codigo = resultado.id_fiesta;
                    objFiesta.Estado = resultado.flg_estado;
                    objFiesta.Nombre = resultado.nombre;
                    objFiesta.CodigoTipoFiesta = resultado.id_tipo_fiesta;
                }
                return objFiesta;
            }
            catch
            {
                return objFiesta;
            }
        }


        public int Insertar(FiestaEntity t)
        {
            throw new NotImplementedException();
        }


        public List<FiestaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
