using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceAdo.MSSQL
{
    public class TortaSQL : ServicioGenerico<TortaEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();

        public bool Agregar(TortaEntity t)
        {
            try
            {
                tb_torta objTbTorta = new tb_torta();
                objTbTorta.flg_estado = t.Estado;
                objTbTorta.nombre = t.Nombre;
                msEntities.tb_torta.Add(objTbTorta);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(TortaEntity t)
        {
            try
            {
                tb_torta objTorta = (from Torta in msEntities.tb_torta
                                   where Torta.id_torta == t.Codigo
                                   select Torta).FirstOrDefault();
                objTorta.flg_estado = t.Estado;
                objTorta.id_torta = t.Codigo;
                objTorta.nombre = t.Nombre;
                msEntities.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(TortaEntity t)
        {
            try
            {
                tb_torta objTorta = (from Torta in msEntities.tb_torta
                                   where Torta.id_torta == t.Codigo
                                   select Torta).FirstOrDefault();
                msEntities.tb_torta.Remove(objTorta);
                msEntities.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public List<TortaEntity> ListarTodos()
        {
            List<TortaEntity> objListaTorta = new List<TortaEntity>();
            try
            {
                var query = msEntities.tb_torta.ToList();
                foreach (var resultado in query)
                {
                    TortaEntity objTorta = new TortaEntity();
                    objTorta.Codigo = resultado.id_torta;
                    objTorta.Estado = resultado.flg_estado;
                    objTorta.Nombre = resultado.nombre;
                    objListaTorta.Add(objTorta);
                }
                return objListaTorta;
            }
            catch
            {
                return null;
            }
        }

        public TortaEntity Consultar(object codigo)
        {
            try
            {
                int codigoTorta = int.Parse(codigo.ToString());
                tb_torta objTorta = (from Torta in msEntities.tb_torta
                                   where Torta.id_torta == codigoTorta
                                   select Torta).FirstOrDefault();
                TortaEntity objTortaEntity = new TortaEntity();
                objTortaEntity.Codigo = objTorta.id_torta;
                objTortaEntity.Estado = objTorta.flg_estado;
                objTortaEntity.Nombre = objTorta.nombre;

                return objTortaEntity;

            }
            catch
            {
                return null;
            }
        }


        public int Insertar(TortaEntity t)
        {
            throw new NotImplementedException();
        }


        public List<TortaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
