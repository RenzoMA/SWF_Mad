using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class TrabajadorZonaEntity
    {
        private int codigoTrabajador;

        public int CodigoTrabajador
        {
            get { return codigoTrabajador; }
            set { codigoTrabajador = value; }
        }
        private int codigoZona;

        public int CodigoZona
        {
            get { return codigoZona; }
            set { codigoZona = value; }
        }

        private DateTime fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }
        private string usuarioCreacion;

        public string UsuarioCreacion
        {
            get { return usuarioCreacion; }
            set { usuarioCreacion = value; }
        }

    }
}
