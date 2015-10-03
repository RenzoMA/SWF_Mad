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
    public partial class frmManTrabajadorActualizar : Form
    {
        TrabajadorBL objTrabajadorBL = new TrabajadorBL();
        ZonaBL objZonaBL = new ZonaBL();
        TrabajadorEntity objTrabajador;
        public frmManTrabajadorActualizar()
        {
            InitializeComponent();
        }
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private void frmManTrabajadorActualizar_Load(object sender, EventArgs e)
        {
            objTrabajador = objTrabajadorBL.Consultar(codigo);
            txtNombre.Text = objTrabajador.Nombre;
            cboEstado.SelectedIndex = objTrabajador.Estado == "A" ?  0 :  1;
            cboZona.DataSource = objZonaBL.ListarTodos();
            cboZona.DisplayMember = "nombre";
            cboZona.ValueMember = "codigo";
            cboZona.SelectedValue = objTrabajador.CodigoZona;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.Trim().Equals(String.Empty))
            {
                objTrabajador.Nombre = txtNombre.Text.ToUpper().Trim();
                objTrabajador.Estado = cboEstado.SelectedIndex == 0 ? "A" : "I";
                objTrabajador.CodigoZona = Convert.ToInt16(cboZona.SelectedValue.ToString());
                objTrabajador.CodigoPlanilla = txtCodigoPlanilla.Text.ToUpper().Trim();
                if (objTrabajadorBL.Actualizar(objTrabajador))
                {
                    MessageBox.Show("Registro actualizado correctamente", "Aviso");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos", "Aviso");
            }
        }

    }
}
