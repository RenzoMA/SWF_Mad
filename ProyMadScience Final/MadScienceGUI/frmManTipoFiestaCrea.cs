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
    public partial class frmManTipoFiestaCrea : Form
    {
        TipoFiestaBL objTipoFiestaBL = new TipoFiestaBL();
        public frmManTipoFiestaCrea()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.Trim().Equals(String.Empty))
            {
                TipoFiestaEntity objTipoFiesta = new TipoFiestaEntity();
                objTipoFiesta.Estado = "A";
                objTipoFiesta.FechaCreacion = DateTime.Now;
                objTipoFiesta.Nombre = txtNombre.Text.ToUpper().Trim();
                if (objTipoFiestaBL.Agregar(objTipoFiesta))
                {
                    MessageBox.Show("Proceso realizado satisfactoriamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Debe completar el nombre","Aviso");
            }
        }
    }
}
