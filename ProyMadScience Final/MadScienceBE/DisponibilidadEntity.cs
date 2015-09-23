using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class DisponibilidadEntity
    {
        private int codigoHorario;

        public int CodigoHorario
        {
            get { return codigoHorario; }
            set { codigoHorario = value; }
        }
        private int codigoTrabajador;

        public int CodigoTrabajador
        {
            get { return codigoTrabajador; }
            set { codigoTrabajador = value; }
        }

        private DateTime fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }
        private String usuarioCreacion;

        public String UsuarioCreacion
        {
            get { return usuarioCreacion; }
            set { usuarioCreacion = value; }
        }

        private String horario;

        public String Horario
        {
            get { return horario; }
            set { horario = value; }
        }



    }
}
