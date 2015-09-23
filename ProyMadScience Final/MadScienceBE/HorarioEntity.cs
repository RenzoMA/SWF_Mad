using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class HorarioEntity
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string nomDia;

        public string NomDia
        {
            get { return nomDia; }
            set { nomDia = value; }
        }
        private double horaInicio;

        public double HoraInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }
        private double horaFin;

        public double HoraFin
        {
            get { return horaFin; }
            set { horaFin = value; }
        }

        private string horarioCompleto;

        public string HorarioCompleto
        {
            get { return horaInicio+" - "+horaFin; }
        }



    }
}
