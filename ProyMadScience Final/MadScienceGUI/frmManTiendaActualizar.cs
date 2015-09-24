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
    public partial class frmManTiendaActualizar : Form
    {
        TiendaBL objTiendaBL = new TiendaBL();
        ZonaBL objZonaBL = new ZonaBL();
        TiendaEntity objTienda;
        public frmManTiendaActualizar()
        {
            InitializeComponent();
        }
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        private void frmManTiendaActualizar_Load(object sender, EventArgs e)
        {
            cboZona.DataSource = objZonaBL.ListarTodosCombo();
            cboZona.DisplayMember = "Nombre";
            cboZona.ValueMember = "Codigo";
            objTienda = objTiendaBL.Consultar(codigo);
            txtNombre.Text = objTienda.Nombre;
            txtDireccion.Text = objTienda.Direccion;
            cboZona.SelectedValue = objTienda.CodigoZona == null ? 0 : objTienda.CodigoZona;
            txtCebe.Text = objTienda.CebeTienda;
            switch (objTienda.Estado)
            {
                case "A": cboEstado.SelectedIndex = 0; break;
                case "I": cboEstado.SelectedIndex = 1; break;
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.ToUpper().Trim().Equals(String.Empty))
            {
                objTienda.Nombre = txtNombre.Text.ToUpper().Trim();
                objTienda.Estado = cboEstado.Text == "Activo" ? "A" : "I";
                objTienda.CodigoZona = Convert.ToInt16(cboZona.SelectedValue.ToString());
                objTienda.Direccion = txtDireccion.Text.ToUpper().Trim();
                objTienda.CebeTienda = txtCebe.Text.ToUpper().Trim();
                if (objTiendaBL.Actualizar(objTienda))
                {
                    MessageBox.Show("Registro actualizado correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un problema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
