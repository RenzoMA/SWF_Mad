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
    public partial class frmManTortaActualiza : Form
    {
        TortaBL objTortaBL = new TortaBL();
        TortaEntity objTorta;
        public frmManTortaActualiza()
        {
            InitializeComponent();
        }
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.ToUpper().Trim().Equals(String.Empty))
            {
                if (objTortaBL.ValidarNombre(txtNombre.Text.ToUpper().Trim(), objTorta.Codigo))
                {
                    objTorta.Nombre = txtNombre.Text.ToUpper().Trim();
                    objTorta.Estado = cboEstado.SelectedIndex == 0 ? "A" : "I";
                    if (objTortaBL.Actualizar(objTorta))
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
                    MessageBox.Show("El nombre de torta ya existe", "Aviso");
                }
            }
        }

        private void frmManTortaActualiza_Load(object sender, EventArgs e)
        {
            objTorta = objTortaBL.Consultar(codigo);
            txtNombre.Text = objTorta.Nombre;
            cboEstado.SelectedIndex = objTorta.Estado == "A" ? 0 : 1;

        }

    }
}
