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
    public partial class frmManSaborActualiza : Form
    {
        SaborBL objSaborBL = new SaborBL();
        SaborEntity objSabor;
        public frmManSaborActualiza()
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
                if (objSaborBL.ValidarNombre(txtNombre.Text.ToUpper().Trim(), objSabor.Codigo))
                {
                    objSabor.Nombre = txtNombre.Text.ToUpper().Trim();
                    objSabor.Estado = cboEstado.SelectedIndex == 0 ? "A" : "I";
                    if (objSaborBL.Actualizar(objSabor))
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
                    MessageBox.Show("El nombre de Sabor ya existe", "Aviso");
                }
            }
        }

        private void frmManSaborActualiza_Load(object sender, EventArgs e)
        {
            objSabor = objSaborBL.Consultar(codigo);
            txtNombre.Text = objSabor.Nombre;
            cboEstado.SelectedIndex = objSabor.Estado == "A" ? 0 : 1;
        }

    }
    
}
