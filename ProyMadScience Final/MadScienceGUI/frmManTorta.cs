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
    public partial class frmManTorta : Form
    {
        TortaBL objTortaBL;
        public frmManTorta()
        {
            InitializeComponent();
        }

        private void frmManTorta_Load(object sender, EventArgs e)
        {
            Enlazar();
        }
        public void Enlazar()
        {
            objTortaBL = new TortaBL();
            dgvTorta.DataSource = objTortaBL.ListarTodo();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmManTortaCrea frm = new frmManTortaCrea();
            frm.ShowDialog();
            Enlazar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvTorta.SelectedRows.Count > 0)
            {
                frmManTortaActualiza frm = new frmManTortaActualiza();
                frm.Codigo = Convert.ToInt16(dgvTorta.SelectedRows[0].Cells["codigo"].Value.ToString());
                frm.ShowDialog();
                Enlazar();
            }
        }
    }
}
