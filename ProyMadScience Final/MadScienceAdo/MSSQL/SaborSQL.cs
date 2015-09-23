using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceAdo.MSSQL
{
    public class SaborSQL : ServicioGenerico<SaborEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();

        public bool Agregar(SaborEntity t)
        {
            try
            {
                tb_sabor objTbSabor = new tb_sabor();
                objTbSabor.flg_estado = t.Estado;
                objTbSabor.nombre = t.Nombre;
                msEntities.tb_sabor.Add(objTbSabor);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(SaborEntity t)
        {
            try
            {
                tb_sabor objSabor = (from Sabor in msEntities.tb_sabor
                                   where Sabor.id_sabor == t.Codigo
                                   select Sabor).FirstOrDefault();
                objSabor.flg_estado = t.Estado;
                objSabor.id_sabor = t.Codigo;
                objSabor.nombre = t.Nombre;
                msEntities.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(SaborEntity t)
        {
            try
            {
                tb_sabor objSabor = (from Sabor in msEntities.tb_sabor
                                   where Sabor.id_sabor == t.Codigo
                                   select Sabor).FirstOrDefault();
                msEntities.tb_sabor.Remove(objSabor);
                msEntities.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public List<SaborEntity> ListarTodos()
        {
            List<SaborEntity> objListaSabor = new List<SaborEntity>();
            try
            {
                var query = msEntities.tb_sabor.ToList();
                foreach (var resultado in query)
                {
                    SaborEntity objSabor = new SaborEntity();
                    objSabor.Codigo = resultado.id_sabor;
                    objSabor.Estado = resultado.flg_estado;
                    objSabor.Nombre = resultado.nombre;
                    objListaSabor.Add(objSabor);
                }
                return objListaSabor;
            }
            catch
            {
                return null;
            }
        }

        public SaborEntity Consultar(object codigo)
        {
            try
            {
                int codigoSabor = int.Parse(codigo.ToString());
                tb_sabor objSabor = (from Sabor in msEntities.tb_sabor
                                   where Sabor.id_sabor == codigoSabor
                                   select Sabor).FirstOrDefault();
                SaborEntity objSaborEntity = new SaborEntity();
                objSaborEntity.Codigo = objSabor.id_sabor;
                objSaborEntity.Estado = objSabor.flg_estado;
                objSaborEntity.Nombre = objSabor.nombre;

                return objSaborEntity;

            }
            catch
            {
                return null;
            }
        }



        public int Insertar(SaborEntity t)
        {
            throw new NotImplementedException();
        }


        public List<SaborEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
