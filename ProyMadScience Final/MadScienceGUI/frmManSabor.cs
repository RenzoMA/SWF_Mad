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
    public partial class frmManSabor : Form
    {
        SaborBL objSaborBL;
        public frmManSabor()
        {
            InitializeComponent();
        }
        public void Enlazar()
        {
            objSaborBL = new SaborBL();
            dgvSabor.DataSource = objSaborBL.ListarTodo();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvSabor.SelectedRows.Count > 0)
            {
                frmManSaborActualiza frm = new frmManSaborActualiza();
                frm.Codigo = Convert.ToInt16(dgvSabor.SelectedRows[0].Cells["codigo"].Value.ToString());
                frm.ShowDialog();
                Enlazar();
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmManSaborCrea frm = new frmManSaborCrea();
            frm.ShowDialog();
            Enlazar();
        }

        private void frmManSabor_Load(object sender, EventArgs e)
        {
            Enlazar();
        }
    }
}
