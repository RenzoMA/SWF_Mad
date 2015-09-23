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
    public partial class frmManTortaCrea : Form
    {
        TortaBL objTortaBL = new TortaBL();
        TortaEntity objTorta = new TortaEntity();

        public frmManTortaCrea()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.ToUpper().Trim().Equals(String.Empty))
            {
                objTorta.Nombre = txtNombre.Text.ToUpper().Trim();
                objTorta.Estado = "A";
                if (objTortaBL.ValidarNombre(objTorta.Nombre, 0))
                {
                    if (objTortaBL.Agregar(objTorta))
                    {
                        MessageBox.Show("Agregado correctamente", "Aviso");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error", "Aviso");
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe una torta con este nombre", "Aviso");
                }
            }
        }
    }
}
