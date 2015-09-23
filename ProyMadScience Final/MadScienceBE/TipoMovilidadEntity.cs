using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class TipoMovilidadEntity
    {
        private int codigoMovilidad;

        public int CodigoMovilidad
        {
            get { return codigoMovilidad; }
            set { codigoMovilidad = value; }
        }

        private string des_nombre;

        public string Des_nombre
        {
            get { return des_nombre; }
            set { des_nombre = value; }
        }

        private double monto;

        public double Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        private string estado;


        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }



    }
}
