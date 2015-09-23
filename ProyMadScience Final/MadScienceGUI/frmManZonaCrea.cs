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
    public partial class frmManZonaCrea : Form
    {
        public frmManZonaCrea()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.ToUpper().Trim().Equals(String.Empty))
            {
                ZonaEntity objZona = new ZonaEntity();
                objZona.Nombre = txtNombre.Text.ToUpper().Trim();
                objZona.Estado = "A";
                ZonaBL objZonaBL = new ZonaBL();
                if (objZonaBL.Agregar(objZona))
                {
                    MessageBox.Show("Agregado correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre para la zona", "Aviso");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
