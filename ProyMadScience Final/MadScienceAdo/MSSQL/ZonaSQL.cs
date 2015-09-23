using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceAdo.MSSQL
{
    public class ZonaSQL : ServicioGenerico<ZonaEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();

        public bool Agregar(ZonaEntity t)
        {
            try
            {
                tb_zona objTbZona = new tb_zona();
                objTbZona.flg_estado = t.Estado;
                objTbZona.nombre = t.Nombre;
                msEntities.tb_zona.Add(objTbZona);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(ZonaEntity t)
        {
            try
            {
                tb_zona objZona = (from zona in msEntities.tb_zona
                                   where zona.id_zona == t.Codigo
                                   select zona).FirstOrDefault();
                objZona.flg_estado = t.Estado;
                objZona.id_zona = t.Codigo;
                objZona.nombre = t.Nombre;
                msEntities.SaveChanges();
                return true;
                
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(ZonaEntity t)
        {
            try
            {
                tb_zona objZona = (from zona in msEntities.tb_zona
                                   where zona.id_zona == t.Codigo
                                   select zona).FirstOrDefault();
                msEntities.tb_zona.Remove(objZona);
                msEntities.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public List<ZonaEntity> ListarTodos()
        {
            List<ZonaEntity> objListaZona = new List<ZonaEntity>();
            try
            {
                var query = msEntities.tb_zona.ToList();
                foreach (var resultado in query)
                {
                    ZonaEntity objZona = new ZonaEntity();
                    objZona.Codigo = resultado.id_zona;
                    objZona.Estado = resultado.flg_estado;
                    objZona.Nombre = resultado.nombre;
                    objListaZona.Add(objZona);
                }
                return objListaZona;
            }
            catch
            {
                return null;
            }
        }

        public ZonaEntity Consultar(object codigo)
        {
            try
            {
                int codigoZona = int.Parse(codigo.ToString());
                tb_zona objZona = (from zona in msEntities.tb_zona
                                   where zona.id_zona == codigoZona
                                   select zona).FirstOrDefault();
                ZonaEntity objZonaEntity = new ZonaEntity();
                objZonaEntity.Codigo = objZona.id_zona;
                objZonaEntity.Estado = objZona.flg_estado;
                objZonaEntity.Nombre = objZona.nombre;

                return objZonaEntity;

            }
            catch
            {
                return null;
            }
        }


        public int Insertar(ZonaEntity t)
        {
            throw new NotImplementedException();
        }


        public List<ZonaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
