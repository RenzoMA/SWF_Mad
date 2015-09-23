using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class FiestaEventoEntity
    {
        private int codigoTipoEvento;

        public int CodigoTipoEvento
        {
            get { return codigoTipoEvento; }
            set { codigoTipoEvento = value; }
        }
        private int codigoFiesta;

        public int CodigoFiesta
        {
            get { return codigoFiesta; }
            set { codigoFiesta = value; }
        }

        private DateTime fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }

        private string nombreEvento;

        public string NombreEvento
        {
            get { return nombreEvento; }
            set { nombreEvento = value; }
        }


    }
}
