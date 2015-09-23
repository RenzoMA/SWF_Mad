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
    public partial class frmManMovilidad : Form
    {
        TipoMovilidadBL objTipo = new TipoMovilidadBL();
        public frmManMovilidad()
        {
            InitializeComponent();
            dgvMovilidad.AutoGenerateColumns = false;
        }

        private void frmManMovilidad_Load(object sender, EventArgs e)
        {
            Enlazar();
        }

        public void Enlazar()
        {
            dgvMovilidad.DataSource = objTipo.listarTodos();
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmManMovilidadCrea frm = new frmManMovilidadCrea();
            frm.ShowDialog();
            Enlazar();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Int16 codigo = Convert.ToInt16(dgvMovilidad.SelectedRows[0].Cells["Column1"].Value.ToString());
            frmManMovilidadActualiza frm = new frmManMovilidadActualiza();
            frm.CodigoMovilidad = codigo;
            frm.ShowDialog();
            Enlazar();
        }
    }
}
