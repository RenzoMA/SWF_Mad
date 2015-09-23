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
    public partial class frmManZonaActualiza : Form
    {
        ZonaEntity objZona;
        ZonaBL objZonaBL = new ZonaBL();
        public frmManZonaActualiza()
        {
            InitializeComponent();
        }
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.ToUpper().Trim().Equals(String.Empty))
            {
                String estado = cmbEstado.Text;
                switch (estado)
                {
                    case "Activo": objZona.Estado = "A"; break;
                    case "Inactivo": objZona.Estado = "I"; break;
                }
                objZona.Nombre = txtNombre.Text.ToUpper().Trim();
                if (objZonaBL.Actualizar(objZona))
                {
                    MessageBox.Show("Registro actualizado correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error", "Aviso");
                }
                

            }
            else
            {
                MessageBox.Show("Debe completar el nombre", "Aviso");
            }
            
        }

        private void frmManZonaActualiza_Load(object sender, EventArgs e)
        {
           
            objZona = objZonaBL.Consultar(codigo);
            txtNombre.Text = objZona.Nombre;
            switch (objZona.Estado)
            {
                case "A": cmbEstado.SelectedIndex = 0; break;
                case "I": cmbEstado.SelectedIndex = 1; break;
            }


        }
    }
}
