using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class ReportePagoMovilidad
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string tipoFiesta;

        public string TipoFiesta
        {
            get { return tipoFiesta; }
            set { tipoFiesta = value; }
        }
        private int cantidadTipoFiesta;

        public int CantidadTipoFiesta
        {
            get { return cantidadTipoFiesta; }
            set { cantidadTipoFiesta = value; }
        }
        private string tipoPago;

        public string TipoPago
        {
            get { return tipoPago; }
            set { tipoPago = value; }
        }
        private double montoTipoPago;

        private int cantidadTipoPago;

        public int CantidadTipoPago
        {
            get { return cantidadTipoPago; }
            set { cantidadTipoPago = value; }
        }

        public double MontoTipoPago
        {
            get { return montoTipoPago; }
            set { montoTipoPago = value; }
        }
        private string tipoMovilidad;

        public string TipoMovilidad
        {
            get { return tipoMovilidad; }
            set { tipoMovilidad = value; }
        }
        private double montoMovilidad;

        public double MontoMovilidad
        {
            get { return montoMovilidad; }
            set { montoMovilidad = value; }
        }
        private double montoTotal;

        public double MontoTotal
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }

        private string codigoFacturacion;

        public string CodigoFacturacion
        {
            get { return codigoFacturacion; }
            set { codigoFacturacion = value; }
        }



    }
}
