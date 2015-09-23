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
    public partial class frmManSaborCrea : Form
    {
        SaborBL objSaborBL = new SaborBL();
        SaborEntity objSabor = new SaborEntity();
        public frmManSaborCrea()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.ToUpper().Trim().Equals(String.Empty))
            {
                objSabor.Nombre = txtNombre.Text.ToUpper().Trim();
                objSabor.Estado = "A";
                if (objSaborBL.ValidarNombre(objSabor.Nombre, 0))
                {
                    if (objSaborBL.Agregar(objSabor))
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
                    MessageBox.Show("Ya existe una Sabor con este nombre", "Aviso");
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
