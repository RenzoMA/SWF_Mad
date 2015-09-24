using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class TiendaEntity
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        int? codigoZona;

        public int? CodigoZona
        {
            get { return codigoZona; }
            set { codigoZona = value; }
        }

        string nombreZona;

        public string NombreZona
        {
            get { return nombreZona; }
            set { nombreZona = value; }
        }

        string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }



        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string nombreTienda;

        public string NombreTienda
        {
            get { return nombreTienda; }
            set { nombreTienda = value; }
        }

        private string cebeTienda;

        public string CebeTienda
        {
            get { return cebeTienda; }
            set { cebeTienda = value; }
        }

    }
}
