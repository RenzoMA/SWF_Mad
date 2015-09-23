using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class TrabajadorHorario
    {
        private int codigoTrabajador;

        public int CodigoTrabajador
        {
            get { return codigoTrabajador; }
            set { codigoTrabajador = value; }
        }
        private String nombreTrabajador;

        public String NombreTrabajador
        {
            get { return nombreTrabajador+" - "+NombreZona; }
            set { nombreTrabajador = value; }
        }


        private String state;

        public String State
        {
            get { return state; }
            set { state = value; }
        }

        private double horaMin;

        public double HoraMin
        {
            get { return horaMin; }
            set { horaMin = value; }
        }
        private double horaMax;

        public double HoraMax
        {
            get { return horaMax; }
            set { horaMax = value; }
        }


        private int cantidadAsignaciones;

        public int CantidadAsignaciones
        {
            get { return cantidadAsignaciones; }
            set { cantidadAsignaciones = value; }
        }

        private int codigoZona;

        public int CodigoZona
        {
            get { return codigoZona; }
            set { codigoZona = value; }
        }
        private string nombreZona;

        public string NombreZona
        {
            get { return nombreZona; }
            set { nombreZona = value; }
        }

    }
}
