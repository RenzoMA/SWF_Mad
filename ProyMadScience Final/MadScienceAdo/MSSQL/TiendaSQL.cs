using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceAdo.MSSQL
{
    public class TiendaSQL : ServicioGenerico<TiendaEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();

        public bool Agregar(TiendaEntity t)
        {
            try
            {
                tb_tienda objTbTienda = new tb_tienda();
                objTbTienda.id_tienda = t.Codigo;
                objTbTienda.id_zona = t.CodigoZona;
                objTbTienda.flg_estado = t.Estado;
                objTbTienda.nombre = t.Nombre;
                objTbTienda.direccion = t.Direccion;
                msEntities.tb_tienda.Add(objTbTienda);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(TiendaEntity t)
        {
            try
            {
                tb_tienda objTbTienda = (from ti in msEntities.tb_tienda
                                         where ti.id_tienda == t.Codigo
                                         select ti).FirstOrDefault();

                objTbTienda.flg_estado = t.Estado;
                objTbTienda.id_zona = t.CodigoZona;
                objTbTienda.nombre = t.Nombre;
                objTbTienda.direccion = t.Direccion;
                msEntities.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(TiendaEntity t)
        {
            try
            {
                tb_tienda objTbTienda = (from ti in msEntities.tb_tienda
                                         where ti.id_tienda == t.Codigo
                                         select ti).FirstOrDefault();


                msEntities.tb_tienda.Remove(objTbTienda);
                msEntities.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TiendaEntity> ListarTodos()
        {
            List<TiendaEntity> objListaTienda = new List<TiendaEntity>();
            try
            {
                var query = msEntities.tb_tienda.ToList();
                foreach (var resultado in query)
                {
                    TiendaEntity objTienda = new TiendaEntity();
                    objTienda.Codigo = resultado.id_tienda;
                    objTienda.CodigoZona = resultado.id_zona;
                    objTienda.Estado = resultado.flg_estado;
                    objTienda.Nombre = resultado.nombre;
                    objTienda.Direccion = resultado.direccion;

                    objListaTienda.Add(objTienda);
                }
                return objListaTienda;
            }
            catch
            {
                return null;
            }
        }

        public TiendaEntity Consultar(object codigo)
        {
            TiendaEntity objTienda = null;
            int codigoTienda = Convert.ToInt32(codigo.ToString());
            try
            {
                tb_tienda objTbTienda = (from ti in msEntities.tb_tienda
                                         where ti.id_tienda == codigoTienda
                                         select ti).FirstOrDefault();

                objTienda = new TiendaEntity();
                objTienda.CodigoZona = objTbTienda.id_zona;
                objTienda.Codigo = objTbTienda.id_tienda;
                objTienda.Estado = objTbTienda.flg_estado;
                objTienda.Nombre = objTbTienda.nombre;
                objTienda.Direccion = objTbTienda.direccion;
                return objTienda;
            }
            catch
            {
                return objTienda;
            }
        }


        public int Insertar(TiendaEntity t)
        {
            throw new NotImplementedException();
        }


        public List<TiendaEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
