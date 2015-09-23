using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class EspecialidadEntity
    {
        int codigoFiesta;

        public int CodigoFiesta
        {
            get { return codigoFiesta; }
            set { codigoFiesta = value; }
        }
        int codigoTrabajador;

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

        private string nombreFiesta;

        public string NombreFiesta
        {
            get { return nombreFiesta; }
            set { nombreFiesta = value; }
        }
        private string tipoFiesta;

        public string TipoFiesta
        {
            get { return tipoFiesta; }
            set { tipoFiesta = value; }
        }


    }
}
