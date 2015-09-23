using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class ReportTiendaDetalle
    {
        private string nombreTienda;

        public string NombreTienda
        {
            get { return nombreTienda; }
            set { nombreTienda = value; }
        }
        private string tipoFiesta;

        public string TipoFiesta
        {
            get { return tipoFiesta; }
            set { tipoFiesta = value; }
        }
        private string nombreFiesta;

        public string NombreFiesta
        {
            get { return nombreFiesta; }
            set { nombreFiesta = value; }
        }
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

    }
}
