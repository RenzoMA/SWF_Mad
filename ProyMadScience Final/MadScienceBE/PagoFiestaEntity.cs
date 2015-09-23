using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class PagoFiestaEntity
    {
        private int codigoTipoPago;

        public int CodigoTipoPago
        {
            get { return codigoTipoPago; }
            set { codigoTipoPago = value; }
        }

        private int codigoFiesta;

        public int CodigoFiesta
        {
            get { return codigoFiesta; }
            set { codigoFiesta = value; }
        }
        private double monto;

        public double Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        private string nombreTipoPago;

        public string NombreTipoPago
        {
            get { return nombreTipoPago; }
            set { nombreTipoPago = value; }
        }





    }
}
