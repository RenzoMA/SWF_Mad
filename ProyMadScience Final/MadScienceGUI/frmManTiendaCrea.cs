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
    public partial class frmManTiendaCrea : Form
    {
        ZonaBL objZonaBL = new ZonaBL();
        TiendaBL objTiendaBL = new TiendaBL();

        public frmManTiendaCrea()
        {
            InitializeComponent();
        }

        private void frmManTiendaCrea_Load(object sender, EventArgs e)
        {
            cboZona.DataSource = objZonaBL.ListarTodosCombo();
            cboZona.DisplayMember = "Nombre";
            cboZona.ValueMember = "Codigo";
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.ToUpper().Trim().Equals(String.Empty))
            {
                TiendaEntity objTienda = new TiendaEntity();
                objTienda.Nombre = txtNombre.Text.ToUpper().Trim();
                objTienda.CodigoZona = Convert.ToInt16(cboZona.SelectedValue.ToString());
                objTienda.Direccion = txtDireccion.Text.ToUpper().Trim();
                objTienda.Estado = "A";
                objTienda.CebeTienda = txtCebe.Text.ToUpper().Trim();
                if (objTiendaBL.Agregar(objTienda))
                {
                    MessageBox.Show("Se realizo el proceso correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hubo un error", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre", "Aviso");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
