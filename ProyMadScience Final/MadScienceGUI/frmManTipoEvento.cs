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
    public partial class frmManTipoEvento : Form
    {
        TipoEventoBL objTipoEventoBL;
        public frmManTipoEvento()
        {
            InitializeComponent();
        }

        private void frmManTipoEvento_Load(object sender, EventArgs e)
        {
            Enlazar();
        }
        public void Enlazar()
        {
            objTipoEventoBL  = new TipoEventoBL();
            dgvTipoEvento.DataSource = objTipoEventoBL.ListarTodoGrilla();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmManTipoEventoCrea frm = new frmManTipoEventoCrea();
            frm.ShowDialog();
            Enlazar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvTipoEvento.SelectedRows.Count > 0)
            {
                frmManTipoEventoActualizar frm = new frmManTipoEventoActualizar();
                frm.Codigo = Convert.ToInt16(dgvTipoEvento.SelectedRows[0].Cells["Codigo"].Value.ToString());
                frm.ShowDialog();
                Enlazar();
            }


        }
    }
}
