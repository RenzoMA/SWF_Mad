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
    public partial class frmManTipoEventoCrea : Form
    {
        TipoEventoBL objTipoEventoBL = new TipoEventoBL();
        public frmManTipoEventoCrea()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.ToUpper().Trim().Equals(String.Empty))
            {
                TipoEventoEntity objTipoEvento = new TipoEventoEntity();
                objTipoEvento.Nombre = txtNombre.Text.ToUpper().Trim();
                objTipoEvento.Estado = "A";
                if (objTipoEventoBL.Agregar(objTipoEvento))
                {
                    MessageBox.Show("Proceso realizado correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre", "Aviso");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
