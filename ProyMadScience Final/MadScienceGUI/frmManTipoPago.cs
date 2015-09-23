using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MadScienceBL;
using MadScienceBE;

namespace MadScienceGUI
{
    public partial class frmManTipoPago : Form
    {
        TipoPagoBL objTipoPagoBL;
        public frmManTipoPago()
        {
            InitializeComponent();
        }

        private void frmManTipoPago_Load(object sender, EventArgs e)
        {
            Enlazar();
        }
        public void Enlazar()
        {
            objTipoPagoBL = new TipoPagoBL();
            dgvTipoPago.DataSource = objTipoPagoBL.ListarTodos();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmManTipoPagoCrea frm = new frmManTipoPagoCrea();
            frm.ShowDialog();
            Enlazar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvTipoPago.SelectedRows.Count > 0)
            {
                frmManTipoPagoActualizar frm = new frmManTipoPagoActualizar();
                frm.Codigo = Convert.ToInt32(dgvTipoPago.SelectedRows[0].Cells["codigo"].Value.ToString());
                frm.ShowDialog();
                Enlazar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "Aviso");
            }
        }
    }
}
