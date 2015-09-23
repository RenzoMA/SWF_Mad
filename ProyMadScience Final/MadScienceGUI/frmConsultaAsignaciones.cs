using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MadScienceBL;

namespace MadScienceGUI
{
    public partial class frmConsultaAsignaciones : Form
    {
        AsignacionBL servicioAsignacion = new AsignacionBL();
        

        public frmConsultaAsignaciones()
        {
            InitializeComponent();
        }
        private DateTime fechaCelebracion;

        public DateTime FechaCelebracion
        {
            get { return fechaCelebracion; }
            set { fechaCelebracion = value; }
        }


        private int codigoTrabajador;

        public int CodigoTrabajador
        {
            get { return codigoTrabajador; }
            set { codigoTrabajador = value; }
        }


        private void frmConsultaAsignaciones_Load(object sender, EventArgs e)
        {
            lblFecha.Text = fechaCelebracion.ToShortDateString();
            dgvConsultaAsignaciones.AutoGenerateColumns = false;
            dgvConsultaAsignaciones.DataSource = servicioAsignacion.ListarPorUsuario(codigoTrabajador, fechaCelebracion);
        }

    }
}
